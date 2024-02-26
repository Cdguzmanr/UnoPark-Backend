using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Test
{
    [TestClass]
    public class utPlayerCard : utBase<tblPlayerCard>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var playerCards = base.LoadTest();
            Assert.AreEqual(expected, playerCards.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = InsertTest(new tblPlayerCard
            {
                Id = Guid.NewGuid(),
                CardId = base.LoadTest().FirstOrDefault().CardId, // Foreign Key
                PlayerId = base.LoadTest().FirstOrDefault().PlayerId // Foreign Key
            });
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblPlayerCard row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.CardId = base.LoadTest().FirstOrDefault().CardId; // Foreign Key
                row.PlayerId = base.LoadTest().FirstOrDefault().PlayerId; // Foreign Key
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblPlayerCard row = dc.tblPlayerCards.FirstOrDefault();

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
