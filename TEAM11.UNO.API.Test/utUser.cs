using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.BL.Models;

namespace TEAM11.UNO.API.Test
{
    [TestClass]
    public class utUser : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<User>();
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            User user = new User { Username = "Test", Password = "Test", FirstName = "Test", LastName = "Test" };
            await base.InsertTestAsync<User>(user);

        }

        //[TestMethod]
        //public async Task DeleteTestAsync()
        //{
        //    await base.DeleteTestAsync<User>(new KeyValuePair<string, string>("Username", "asteffes"));
        //}

        //[TestMethod]
        //public async Task LoadByIdTestAsync()
        //{
        //    await base.LoadByIdTestAsync<User>(new KeyValuePair<string, string>("Username", "asteffes"));
        //}

        //[TestMethod]
        //public async Task UpdateTestAsync()
        //{
        //    User user = new User { Username = "Test", FirstName = "Test", LastName = "Test", Password = "Test" };
        //    await base.UpdateTestAsync<User>(new KeyValuePair<string, string>("Username", "asteffes"), user);
        //}
    }
}
