using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL
{
    public class PlayerManager : GenericManager<tblPlayer>
    {

        public PlayerManager(DbContextOptions<UNOEntities> options) : base(options)
        {
        }
    }
}
