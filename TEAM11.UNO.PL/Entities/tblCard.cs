using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }

        // Connection among tables
        public virtual ICollection<tblPlayerCard> Playercards { get; set; }


    }
}
