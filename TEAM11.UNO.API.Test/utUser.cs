using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.BL.Models;

namespace TEAM11.UNO.API.Test
{
    public class utUser : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Card>();
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            Card card = new Card { Description = "Test" };
            await base.InsertTestAsync<Card>(card);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<Card>(new KeyValuePair<string, string>("Description", "DVD"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Card>(new KeyValuePair<string, string>("Description", "DVD"));
        }

        [TestMethod]
        public async Task UpdateTestAsync()
        {
            Card card = new Card { Description = "Test" };
            await base.UpdateTestAsync<Card>(new KeyValuePair<string, string>("Description", "DVD"), format);

        }
    }
}
