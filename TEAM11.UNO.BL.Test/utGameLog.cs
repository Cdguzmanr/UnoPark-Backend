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
    public class utGameLogLog : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<GameLog> gameLogs = new GameLogManager(options).Load();

            int expected = 3;

            Assert.AreEqual(expected, gameLogs.Count);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            GameLog gameLog = new GameLogManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new GameLogManager(options).LoadById(gameLog.Id).Id, gameLog.Id);
        }
        //[TestMethod]
        //public void InsertTest()
        //{
        //    GameLog gameLog = new GameLog
        //    {
        //        Description = "Test",
        //        Timestamp = "10/31/24",
        //    };

        //    int result = new GameLogManager(options).Insert(gameLog, true);
        //    Assert.IsTrue(result > 0);
        //}
        [TestMethod]
        public void UpdateTest()
        {
            GameLog gameLog = new GameLogManager(options).Load().FirstOrDefault();
            gameLog.Description = "BipityBoBopBop";

            Assert.IsTrue(new GameLogManager(options).Update(gameLog, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            GameLog gameLog = new GameLogManager(options).Load().LastOrDefault();

            Assert.IsTrue(new GameLogManager(options).Delete(gameLog.Id, true) > 0);
        }

        [TestMethod]
        public void ReportGameLogTest()
        {
            var gamelogs = new GameLogManager(options).Load();
            string[] columns = { "Description", "Timestamp" };
            var data = GameLogManager.ConvertData<GameLog>(gamelogs, columns);

            Excel.Export("gamelogs.xlsx", data);
        }
    }
}
