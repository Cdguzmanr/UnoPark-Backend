
using Castle.Core.Resource;
using Microsoft.Extensions.Options;
using TEAM11.UNO.BL;

namespace TEAM11.UNO.BL.Test
{
    // Commit message.
    [TestClass]
    public class utCard : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Card> cards = new CardManager(options).Load();

            int expected = 54;

            Assert.AreEqual(expected, cards.Count);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            Card card = new CardManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new CardManager(options).LoadById(card.Id).Id, card.Id);
        }
        [TestMethod]
        public void InsertTest()
        {
            Card card = new Card
            {
                Name = "Test",
                Color = "Magenta",
                Type = "Kewl"
            };

            int result = new CardManager(options).Insert(card, true);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Card card = new CardManager(options).Load().FirstOrDefault();
            card.Name = "BipityBoBopBop";

            Assert.IsTrue(new CardManager(options).Update(card, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Card card = new CardManager(options).Load().LastOrDefault();

            Assert.IsTrue(new CardManager(options).Delete(card.Id, true) > 0);
        }
    }
}
