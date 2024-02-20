using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        
        // Might want to hash this password in database
        public string Password { get; set; }
    }
}
