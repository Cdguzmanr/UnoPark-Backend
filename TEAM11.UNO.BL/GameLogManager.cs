using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM11.UNO.BL
{
    public class GameLogManager : GenericManager<tblGameLog>
    {

        public GameLogManager(DbContextOptions<UNOEntities> options) : base(options)
        {
        }


        public int Insert(GameLog gameLog, bool rollback = false)
        {
            try
            {
                tblGameLog row = new tblGameLog { Id = gameLog.Id, GameId = gameLog.GameId, Description = gameLog.Description, Timestamp = gameLog.Timestamp}; // GameId, Description, Timestamp
                gameLog.Id = row.Id;
                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(GameLog gameLog, bool rollback = false)
        {
            try
            {
                return base.Update(new tblGameLog
                {
                    Id = gameLog.Id,
                    GameId = gameLog.GameId,
                    Description = gameLog.Description,
                    Timestamp = gameLog.Timestamp
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
        public List<GameLog> Load()
        {
            try
            {
                List<GameLog> rows = new List<GameLog>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new GameLog
                        {
                            Id = d.Id,
                            GameId = d.GameId,
                            Description = d.Description,
                            Timestamp = d.Timestamp
                        }));

                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GameLog LoadById(Guid id)
        {
            try
            {

                tblGameLog row = base.LoadById(id);

                if (row != null)
                {
                    GameLog gameLog = new GameLog
                    {
                        Id = row.Id,
                        GameId = row.GameId,
                        Description = row.Description,
                        Timestamp = row.Timestamp
                    };
                    return gameLog;
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

