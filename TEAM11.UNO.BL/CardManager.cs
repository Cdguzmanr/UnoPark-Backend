using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.BL.Models;

namespace TEAM11.UNO.BL
{
    public class CardManager : GenericManager<tblCard>
    {

        public CardManager(DbContextOptions<UNOEntities> options) : base(options)
        {
        }


        public int Insert(Card card, bool rollback = false)
        {
            try
            {
                tblCard row = new tblCard { Id = card.Id, Number = card.Number, Color = card.Color }; // Name, Color, Type
                card.Id = row.Id;
                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Card card, bool rollback = false)
        {
            try
            {
                return base.Update(new tblCard
                {
                    Id = card.Id,
                    Number = card.Number,
                    Color = card.Color,
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
        public List<Card> Load()
        {
            try
            {
                List<Card> rows = new List<Card>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Card
                        {
                            Id = d.Id,
                            Number = d.Number,
                            Color = d.Color
                        }));

                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Card LoadById(Guid id)
        {
            try
            {

                tblCard row = base.LoadById(id);

                if (row != null)
                {
                    Card card = new Card
                    {
                        Id = row.Id,
                        Number = row.Number,
                        Color = row.Color
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
