using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblUser : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        
        // Might want to hash this password in database
        public string Password { get; set; }

        // Added in properties based on Meeting #2 with Brian
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Connection among tables
        public virtual ICollection<tblPlayer> Players { get; set; }
        public virtual ICollection<tblGame> Games { get; set; }
    }
}
