using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.BL;
using TEAM11.UNO.BL.Models;

namespace TEAM11.UNO.API.Test
{
    [TestClass]
    public class utGame : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Game>();
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            Game game = new Game { Name = "Test", IsPaused = true };
            await base.InsertTestAsync<Game>(game);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<Game>(new KeyValuePair<string, string>("Name", "Test Game 1"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Game>(new KeyValuePair<string, string>("Name", "Test Game 1"));
        }

        [TestMethod]
        public async Task UpdateTestAsync()
        {
            Game game = new Game { Name = "Test", IsPaused = false, Gamelogs = new List<GameLog>(), Players = new List<Player>() };
            await base.UpdateTestAsync<Game>(new KeyValuePair<string, string>("Name", "Test Game 1"), game);

        }
    }
}
