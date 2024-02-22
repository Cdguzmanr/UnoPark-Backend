using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblPlayerCard : IEntity
    {
        public Guid Id { get; set; }

        // Connection among tables
        public virtual tblCard CardId {  get; set; }
        public virtual tblPlayer PlayerId { get; set; }
    }
}
