using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblGame
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPaused {  get; set; }

        // Connection among tables.
        public Guid UserId { get; set; }
        public virtual tblUser CurrentTurnUserId { get; set; }

        public virtual ICollection<tblGameLog> Gamelogs { get; set; }
        public virtual ICollection<tblPlayer> Players { get; set; }
    }
}
