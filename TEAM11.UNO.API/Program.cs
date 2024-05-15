using TEAM11.UNO.API.Hubs;
using TEAM11.UNO.PL.Data;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Ui.MsSqlServerProvider;
using Serilog.Ui.Web;
using System.Reflection;
using WebApi.Helpers;
using WebApi.Services;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSignalR()
            .AddJsonProtocol(options =>
            {
                options.PayloadSerializerOptions.PropertyNamingPolicy = null;
            });

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        // 
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Uno Game API",
                Version = "v1.5",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Austin, Carlos",
                    Email = "Microsoft Teams",
                    Url = new Uri("https://fvtc.edu")
                }
            });

            var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);
            c.IncludeXmlComments(xmlpath);
        });

        // Getting secret.
        string connectionString = GetSecret("WebAPIKey").Result;

        // Add database connection information.
        builder.Services.AddDbContextPool<UNOEntities>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("UNOConnection1"));
            //options.UseSqlServer(connectionString);
            options.UseLazyLoadingProxies();
        });


        // ----------
        // configure strongly typed settings object
        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
        // configure DI for application services
        builder.Services.AddScoped<IUserService, UserService>();
        // --------

        string connection = builder.Configuration.GetConnectionString("UNOConnection1");
        
        builder.Services.AddSerilogUi(options =>
        {
            options.UseSqlServer(connection, "Logs");
        });

        // Features for Logging the database.

        // Grabbing configuration file.
        var configsettings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // Add in Log message feature.
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configsettings)
            .CreateLogger();

        // This is just a feature that you want to turn on.
        builder.Services
            .AddLogging(c => c.AddDebug())
            .AddLogging(c => c.AddSerilog())
            .AddLogging(c => c.AddEventLog())
            .AddLogging(c => c.AddConsole());


        // This build line is important, everything above is going to be put into a package.
        var app = builder.Build();

        // Logging feature after the build.
        app.UseSerilogUi(options =>
        {
            options.RoutePrefix = "logs";
        });

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || true) // NOTE: Added this line: || true
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // custom jwt auth middleware
        app.UseMiddleware<JwtMiddleware>();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        //app.MapControllers();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<UnoHub>("/UnoHub");
        });

        app.Run();
    }
    public static async Task<string> GetSecret(string secretName)
    {
        try
        {
            //const string secretName = "DVDCentral-ConnectionString";
            var keyVaultName = "kv-300079087";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            //using var client = GetClient();
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine(secret.Value.Value.ToString());
            return secret.Value.Value.ToString();
            //return (await client.GetSecretAsync(kvUri, secretName)).Value.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

}