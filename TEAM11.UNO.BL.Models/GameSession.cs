using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL.Models
{
    
    // Class is static since there will only be 1 Game Session to handle all Users connected and games running
    public static class GameSession
    {
        public static List<User> UsersInSession { get; set; } = new List<User>();

        public static List<Game> GamesInSession { get; set; } = new List<Game>();

    }
}
