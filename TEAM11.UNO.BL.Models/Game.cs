using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPaused { get; set; }

        // Connection among tables.
        public Guid UserId { get; set; }

        // TODO: Verify if this property is needed.
       /* public tblUser User { get; set; }*/

        public List<GameLog> Gamelogs { get; set; }
        public List<Player> Players { get; set; }
    }
}
