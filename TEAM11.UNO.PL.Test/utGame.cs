using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Test
{
    [TestClass]
    public class utGame : utBase<tblGame>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var games = base.LoadTest();
            Assert.AreEqual(expected, games.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = InsertTest(new tblGame
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                IsPaused = false,
                CurrentTurnUserId = base.LoadTest().FirstOrDefault().CurrentTurnUserId

            });
            Assert.AreEqual(1, rowsAffected);

        }

        [TestMethod]
        public void UpdateTest()
        {
            tblGame row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.Name = "UpdateTest";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblGame row = dc.tblGames.FirstOrDefault();

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }

    }
}
