using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Test
{
    [TestClass]
    public class utPlayer : utBase<tblPlayer>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 6;
            var player = base.LoadTest();
            Assert.AreEqual(expected, player.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblPlayer row = new tblPlayer();
            row.Id = Guid.NewGuid();
            row.IsComputerPlayer = false;
            row.UserId = base.LoadTest().FirstOrDefault().UserId; // Foreign Key
            row.GameId = base.LoadTest().FirstOrDefault().GameId; // Foreign Key

            int results = base.InsertTest(row);
            Assert.IsTrue(results > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblPlayer row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.IsComputerPlayer = true;
                int results = base.UpdateTest(row);
                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblPlayer row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                int results = base.DeleteTest(row);
                Assert.IsTrue(results > 0);
            }
        }
    }
}
