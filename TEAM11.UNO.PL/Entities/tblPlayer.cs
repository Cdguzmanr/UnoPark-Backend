using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblPlayer : IEntity
    {
        public Guid Id { get; set; }
        public bool IsComputerPlayer { get; set; }

        // Connection among tables

        // Junction table connectors
        public Guid UserId { get; set; }
        public virtual tblUser User { get; set; }

        public Guid GameId { get; set; }
        public virtual tblGame Game { get; set; }

        public virtual ICollection<tblPlayerCard> Playercards { get; set; }
        public virtual ICollection<tblGame> Games { get; set; }
    }
}
