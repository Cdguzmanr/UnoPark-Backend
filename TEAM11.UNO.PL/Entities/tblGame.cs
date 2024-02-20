using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.PL.Entities
{
    public class tblGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentTurnUserId {  get; set; }
        public bool IsPaused {  get; set; }
    }
}
