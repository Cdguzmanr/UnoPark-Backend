﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL
{
    public class GameLogManager : GenericManager<tblGameLog>
    {

        public GameLogManager(DbContextOptions<UNOEntities> options) : base(options)
        {
        }
    }
}