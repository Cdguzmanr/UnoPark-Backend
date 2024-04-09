using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.BL.Models;

namespace TEAM11.UNO.API.Test
{
    public class utCard : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Card>();
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            Card card = new Card { Name = "Test", Color = "Test", Type = "Test" };
            await base.InsertTestAsync<Card>(card);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<Card>(new KeyValuePair<string, string>("Name", "R0"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Card>(new KeyValuePair<string, string>("Name", "R0"));
        }

        [TestMethod]
        public async Task UpdateTestAsync()
        {
            Card card = new Card { Name = "Test" };
            await base.UpdateTestAsync<Card>(new KeyValuePair<string, string>("Name", "R0"), card);

        }
    }
}
