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


        public int Insert(GameLog card, bool rollback = false)
        {
            try
            {
                tblGameLog row = new tblGameLog { Id = card.Id, GameId = card.GameId, Description = card.Description, Timestamp = card.Timestamp}; // GameId, Description, Timestamp
                card.Id = row.Id;
                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(GameLog card, bool rollback = false)
        {
            try
            {
                return base.Update(new tblGameLog
                {
                    Id = card.Id,
                    GameId = card.GameId,
                    Description = card.Description,
                    Timestamp = card.Timestamp
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
                    GameLog card = new GameLog
                    {
                        Id = row.Id,
                        GameId = row.GameId,
                        Description = row.Description,
                        Timestamp = row.Timestamp
                    };
                    return card;
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

