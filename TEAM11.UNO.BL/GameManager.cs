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
                
                // Insert objects in Lists (Gamelogs, Players)
/*                if (game.Gamelogs != null)
                {
                    foreach (GameLog gamelog in game.Gamelogs)
                    {
                        row.Gamelogs.Add(new tblGameLog { Id = gamelog.Id, Description = gamelog.Description, Timestamp = gamelog.Timestamp, GameId = gamelog.GameId });
                    }
                }
                if (game.Players != null)
                {
                    foreach (Player player in game.Players)
                    {
                        row.Players.Add(new tblPlayer { Id = player.Id, IsComputerPlayer = player.IsComputerPlayer, UserId = player.UserId, GameId = player.GameId }); // Todo: add the rest of the properties (Username, GameName, Playercards)
                    }
                }*/
                
                game.Id = row.Id;
                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Game game, bool rollback = false)
        {
            try
            {
                return base.Update(new tblGame
                {
                    Id = game.Id,
                    Name = game.Name,
                    IsPaused = game.IsPaused,
                    // Todo: Add the rest of the properties 
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
        public List<Game> Load()
        {
            try
            {
                List<Game> rows = new List<Game>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Game
                        {
                            Id = d.Id,
                            Name = d.Name,
                            IsPaused = d.IsPaused,
                            // Todo: Add the rest of the properties
                        }));

                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Game LoadById(Guid id)
        {
            try
            {

                tblGame row = base.LoadById(id);

                if (row != null)
                {
                    Game game = new Game
                    {
                        Id = row.Id,
                        Name = row.Name,
                        IsPaused = row.IsPaused,
                        // Todo: Add the rest of the properties
                    };
                    return game;
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
