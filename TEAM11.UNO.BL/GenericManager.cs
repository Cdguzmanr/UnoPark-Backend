using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.PL.Data;

namespace TEAM11.UNO.BL
{ 
    public abstract class GenericManager<T> where T : class, IEntity
    {
        protected DbContextOptions<UNOEntities> options;

        public GenericManager(DbContextOptions<UNOEntities> options)
        {
            this.options = options;
        }

        public GenericManager() { }

        public static string[,] ConvertData<U>(List<U> entities, string[] columns) where U : class
        {
            string[,] data = new string[entities.Count + 1, columns.Length];

            int counter = 0;
            for (int i = 0; i < columns.Length; i++)
            {
                data[counter, i] = columns[i];
            }
            counter++;


            foreach (var entity in entities)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    data[counter, i] = entity.GetType().GetProperty(columns[i]).GetValue(entity, null).ToString();
                }
                counter++;
            }
            return data;
        }

        public List<T> Load()
        {
            try
            {
                return new UNOEntities(options)
                    .Set<T>()
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public T LoadById(Guid id)
        {
            try
            {
                var row = new UNOEntities(options).Set<T>().Where(t => t.Id == id).FirstOrDefault();
                return row;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (UNOEntities dc = new UNOEntities(options))
                {
                    // Check if genre already exists - do not allow ....
                    //bool inUse = dc.tblGenres.Any(e => e.Description.Trim().ToUpper() == entity.Description.Trim().ToUpper());

                    //if (inUse && !rollback)
                    //{
                    //    throw new Exception("This entity already exists.");
                    //}

                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    entity.Id = Guid.NewGuid();

                    dc.Set<T>().Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (UNOEntities dc = new UNOEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    dc.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (UNOEntities dc = new UNOEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    T row = dc.Set<T>().FirstOrDefault(t => t.Id == id);

                    if (row != null)
                    {
                        dc.Set<T>().Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
