using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.BL.Models;

namespace TEAM11.UNO.BL
{
    public class PlayerManager : GenericManager<tblPlayer>
    {

        public PlayerManager(DbContextOptions<UNOEntities> options) : base(options)
        {
        }


        public int Insert(Player player, bool rollback = false)
        {
            try
            {
                tblPlayer row = new tblPlayer { Id = player.Id, IsComputerPlayer = player.IsComputerPlayer, UserId = player.UserId, GameId = player.GameId };
                
                // Todo: Verify conflict with suer and game objects
                
                player.Id = row.Id;
                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Player player, bool rollback = false)
        {
            try
            {
                return base.Update(new tblPlayer
                {
                    Id = player.Id,
                    IsComputerPlayer = player.IsComputerPlayer,
                    UserId = player.UserId,
                    GameId = player.GameId
                },
                rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return base.Delete(id, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Player> Load()
        {
            try
            {
                List<Player> rows = new List<Player>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Player
                        {
                            Id = d.Id,
                            IsComputerPlayer = d.IsComputerPlayer,
                            UserId = d.UserId,
                            GameId = d.GameId
                        }));

                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Player LoadById(Guid id)
        {
            try
            {

                tblPlayer row = base.LoadById(id);

                if (row != null)
                {
                    Player player = new Player
                    {
                        Id = row.Id,
                        IsComputerPlayer = row.IsComputerPlayer,
                        UserId = row.UserId,
                        GameId = row.GameId
                    };
                    return player;
                }
                else
                {
                    throw new Exception("Row was not found.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
