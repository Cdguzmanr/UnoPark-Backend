using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.Reporting;

namespace TEAM11.UNO.BL.Test
{
    [TestClass]
    public class utGame : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Game> games = new GameManager(options).Load();

            int expected = 3;

            Assert.AreEqual(expected, games.Count);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            Game game = new GameManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new GameManager(options).LoadById(game.Id).Id, game.Id);
        }
        [TestMethod]
        public void InsertTest()
        {
            Game game = new Game
            {
                Name = "Test",
                IsPaused = true,
            };

            int result = new GameManager(options).Insert(game, true);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Game game = new GameManager(options).Load().FirstOrDefault();
            game.Name = "BipityBoBopBop";

            Assert.IsTrue(new GameManager(options).Update(game, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Game game = new GameManager(options).Load().LastOrDefault();

            Assert.IsTrue(new GameManager(options).Delete(game.Id, true) > 0);
        }

        [TestMethod]
        public void ReportGameTest()
        {
            var games = new GameManager(options).Load();
            string[] columns = { "Name" };
            var data = GameManager.ConvertData<Game>(games, columns);

            Excel.Export("games.xlsx", data);
        }
    }
}
