using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblGameLog : IEntity
    {
        public Guid Id { get; set; }
        public string Description {  get; set; }
        public string Timestamp { get; set; }

        // Connection among tables
        public Guid GameId { get; set; }
        public virtual tblGame Game { get; set; }
    }
}
