using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.BL.Models;

namespace TEAM11.UNO.API.Test
{
    [TestClass]
    public class utGameLog : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<GameLog>();
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            GameLog gameLog = new GameLog { Description = "Test", Timestamp = "Test" };
            await base.InsertTestAsync<GameLog>(gameLog);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<GameLog>(new KeyValuePair<string, string>("Description", "Test Game Log 1"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<GameLog>(new KeyValuePair<string, string>("Description", "Test Game Log 1"));
        }

        // Conflicts with a foreign key relationship / problem.

        //[TestMethod]
        //public async Task UpdateTestAsync()
        //{
        //    GameLog gameLog = new GameLog { Description = "Test", Timestamp = "Test", GameId = new Game().Id };
        //    await base.UpdateTestAsync<GameLog>(new KeyValuePair<string, string>("Description", "Test Game Log 1"), gameLog);

        //}
    }
}
