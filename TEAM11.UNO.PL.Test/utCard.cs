using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Test
{
    [TestClass]
    public class utCard : utBase<tblCard>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 54;
            var cards = base.LoadTest();
            Assert.AreEqual(expected, cards.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCard row = new tblCard();
            row.Id = Guid.NewGuid();
            row.Number = "Test";
            row.Color = "Red";

            int results = base.InsertTest(row);
            Assert.IsTrue(results > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblCard row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.Number = "UpdateTest";
                int results = base.UpdateTest(row);
                Assert.IsTrue(results > 0);
            }            
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblCard row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                int results = base.DeleteTest(row);
                Assert.IsTrue(results > 0);
            }
        }

    }
}
