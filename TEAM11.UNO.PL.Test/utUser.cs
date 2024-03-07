namespace TEAM11.UNO.PL.Test
{
    [TestClass]
    public class utUser : utBase<tblUser>
    {

        [TestMethod]
        public void LoadTest()
        {
            Assert.IsTrue(base.LoadTest().Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblUser newRow = new tblUser();

            newRow.Id = Guid.NewGuid();
            newRow.FirstName = "Joe";
            newRow.LastName = "Billings";
            newRow.Username = "XXXXXX";
            newRow.Password = "YYYYY";

            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblUser row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.FirstName = "Sarah";
                row.LastName = "Vicchiollo";
                int rowsAffected = UpdateTest(row);

                Assert.AreEqual(1, rowsAffected);
            }
        }


        // Todo: Add foreach loop to delete all the players related to the user before delete the user
        [TestMethod]
        public void DeleteTest()
        {
            tblUser userRow = base.LoadTest().FirstOrDefault();
            tblPlayer playerRow = dc.tblPlayers.FirstOrDefault(p => p.UserId == userRow.Id);

            if (userRow != null && playerRow != null)
            {
                dc.tblPlayers.Remove(playerRow); // Need to remove the Players related to the user before delete user
                
                int userRowsAffected = DeleteTest(userRow);
                Assert.IsTrue(userRowsAffected > 0);
            }

        }
    }
}
