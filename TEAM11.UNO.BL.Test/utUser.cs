using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL.Test
{
    [TestClass]
    public class utUser : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<User> users = new UserManager(options).Load();

            int expected = 4;

            Assert.AreEqual(expected, users.Count);
        }
        //[TestMethod]
        //public void LoadByIdTest()
        //{
        //    User user = new UserManager(options).Load().FirstOrDefault();
        //    Assert.AreEqual(new UserManager(options).LoadById(user.Id).Id, user.Id);
        //}
        [TestMethod]
        public void InsertTest()
        {
            User user = new User
            {
                Username = "Test",
                Password = "Test",
                FirstName = "Test",
                LastName = "Test",
            };

            int result = new UserManager(options).Insert(user, true);
            Assert.IsTrue(result > 0);
        }
        //[TestMethod]
        //public void UpdateTest()
        //{
        //    User user = new UserManager(options).Load().FirstOrDefault();
        //    user.FirstName = "Nemo";

        //    Assert.IsTrue(new UserManager(options).Update(user, true) > 0);
        //}
        //[TestMethod]
        //public void DeleteTest()
        //{
        //    User user = new UserManager(options).Load().LastOrDefault();

        //    Assert.IsTrue(new UserManager(options).Delete(user.Id, true) > 0);
        //}

        [TestMethod]
        public void LoginSuccess()
        {
            User user = new User { FirstName = "Austin", LastName = "Steffes", Username = "asteffes", Password = "Austin" };
            bool result = new UserManager(options).Login(user);
            Assert.IsTrue(result);
        }

        // This method is suppose to fail since its attempting to log in with a bad user.
        //[TestMethod]
        //public void LoginFail()
        //{
        //    try
        //    {
        //        User user = new User { FirstName = "Brian", LastName = "Foote", Username = "bfoote", Password = "xxxxx" };
        //        new UserManager(options).Login(user);
        //        Assert.Fail();
        //    }
        //    catch (LoginFailureException)
        //    {
        //        Assert.IsTrue(true);
        //    }
        //    catch (Exception)
        //    {
        //        Assert.Fail();
        //    }
        //}
    }
}
