using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL.Test
{
    [TestClass]
    public class utPlayer : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Player> players = new PlayerManager(options).Load();

            int expected = 6;

            Assert.AreEqual(expected, players.Count);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            Player player = new PlayerManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new PlayerManager(options).LoadById(player.Id).Id, player.Id);
        }
        //[TestMethod]
        //public void InsertTest()
        //{
        //    Player player = new Player
        //    {
        //        IsComputerPlayer = false,
        //    };

        //    int result = new PlayerManager(options).Insert(player, true);
        //    Assert.IsTrue(result > 0);
        //}
        [TestMethod]
        public void UpdateTest()
        {
            Player player = new PlayerManager(options).Load().FirstOrDefault();
            player.IsComputerPlayer = true;

            Assert.IsTrue(new PlayerManager(options).Update(player, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Player player = new PlayerManager(options).Load().LastOrDefault();

            Assert.IsTrue(new PlayerManager(options).Delete(player.Id, true) > 0);
        }
    }
}
