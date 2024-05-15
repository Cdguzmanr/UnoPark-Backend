using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblCard : IEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }

        // Connection among tables
        public virtual ICollection<tblPlayerCard> Playercards { get; set; }

    }
}
