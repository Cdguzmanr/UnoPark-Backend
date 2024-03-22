using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public bool IsComputerPlayer { get; set; }

        // Connection among tables
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }

        public string Username { get; set; } // This is the name of the player.
        
        //public string GameName { get; set; } // This is the name of the game the player is playing.

        public List<Card> Playercards { get; set; }
    }
}
