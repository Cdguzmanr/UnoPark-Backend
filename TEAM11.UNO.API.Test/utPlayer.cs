﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.BL.Models;

namespace TEAM11.UNO.API.Test
{
    public class utPlayer : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Player>();
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            Player player = new Player {  };
            await base.InsertTestAsync<Player>(player);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<Player>(new KeyValuePair<string, string>("", ""));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Player>(new KeyValuePair<string, string>("", ""));
        }

        [TestMethod]
        public async Task UpdateTestAsync()
        {
            Player player = new Player { };
            await base.UpdateTestAsync<Player>(new KeyValuePair<string, string>("", ""), player);

        }
    }
}
