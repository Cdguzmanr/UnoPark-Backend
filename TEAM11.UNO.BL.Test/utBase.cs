using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;

namespace TEAM11.UNO.BL.Test
{
    [TestClass]
    public abstract class utBase
    {
        protected UNOEntities dc;  // declare the DataContext
        protected IDbContextTransaction transaction;
        public IConfigurationRoot _configuration;
        public DbContextOptions<UNOEntities> options;

        public utBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            options = new DbContextOptionsBuilder<UNOEntities>()
                .UseSqlServer(_configuration.GetConnectionString("UNOConnection"))
                .UseLazyLoadingProxies()
                .Options;

            dc = new UNOEntities(options);

        }


        [TestInitialize]
        public void TestInitialize()
        {
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;
        }
    }
}
