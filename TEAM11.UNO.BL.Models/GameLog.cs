using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL.Models
{
    public class GameLog
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Timestamp { get; set; }

        // Connection among tables
        public Guid GameId { get; set; }
    }
}
