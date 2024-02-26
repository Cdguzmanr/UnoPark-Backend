using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Test
{
    [TestClass]
    public class utGameLog : utBase<tblGameLog>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var gameLog = base.LoadTest();
            Assert.AreEqual(expected, gameLog.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblGameLog row = new tblGameLog();
            row.Id = Guid.NewGuid();
            row.Description = "Test";
            row.Timestamp = "2021-01-01 00:00:00";
            row.GameId = base.LoadTest().FirstOrDefault().GameId; // Foreign Key

            int results = base.InsertTest(row);
            Assert.IsTrue(results > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblGameLog row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.Description = "UpdateTest";
                int results = base.UpdateTest(row);
                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblGameLog row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                int results = base.DeleteTest(row);
                Assert.IsTrue(results > 0);
            }
        }
    }
}
