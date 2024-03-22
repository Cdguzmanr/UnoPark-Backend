using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblGame : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPaused {  get; set; }

        // Added in CurrentTurnUserId
        public Guid CurrentTurnUserId { get; set; }
        public virtual ICollection<tblGameLog> Gamelogs { get; set; }
        public virtual ICollection<tblPlayer> Players { get; set; }
    }
}
