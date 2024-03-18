using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL
{
    public class GameManager : GenericManager<tblGame>
    {

        public GameManager(DbContextOptions<UNOEntities> options) : base(options)
        {
        }

        public int Insert(Game game, bool rollback = false)
        {
            try
            {
                tblGame row = new tblGame { Id = game.Id, Name = game.Name, IsPaused = game.IsPaused};
                game.Id = row.Id;
                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
