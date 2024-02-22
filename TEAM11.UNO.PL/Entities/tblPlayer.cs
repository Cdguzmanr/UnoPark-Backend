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
        public virtual tblUser UserId { get; set; }
        public virtual tblGame GameId {  get; set; }
    }
}
