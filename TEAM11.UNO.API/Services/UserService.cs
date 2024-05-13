namespace WebApi.Services;

using TEAM11.UNO.BL;
using TEAM11.UNO.BL.Models;
using TEAM11.UNO.PL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Helpers;
using WebApi.Models;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(Guid id);
}

public class UserService : IUserService
{
    List<User> _users;

    private readonly AppSettings _appSettings;
    private readonly DbContextOptions<UNOEntities> dbOptions;

    public UserService(IOptions<AppSettings> appSettings, 
                       DbContextOptions<UNOEntities> options)
    {
        _appSettings = appSettings.Value;
        dbOptions = options;
        
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = new UserManager(dbOptions)
                        .Load()
                        .SingleOrDefault(x => x.Username == model.Username 
                                        && x.Password == UserManager.GetHash(model.Password));

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<User> GetAll()
    {
        _users = new UserManager(dbOptions).Load();
        return _users;
    }

    public User GetById(Guid id)
    {
        return new UserManager(dbOptions).Load().FirstOrDefault(x => x.Id == id);
    }

    // helper methods

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}