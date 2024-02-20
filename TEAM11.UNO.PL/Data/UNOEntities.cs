using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM11.UNO.PL.Entities;

namespace TEAM11.UNO.PL.Data
{
    public class UNOEntities : DbContext
    {
        public virtual DbSet<tblCard> tblCards { get; set; }
        public virtual DbSet<tblGame> tblGames { get; set; }
        public virtual DbSet<tblGameLog> tblGameLogs { get; set; }
        public virtual DbSet<tblPlayer> tblPlayers { get; set; }
        public virtual DbSet<tblPlayerCard> tblPlayerCards { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }

        public UNOEntities(DbContextOptions<UNOEntities> options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public UNOEntities()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            CreateCards(modelBuilder);
            CreateGames(modelBuilder);
            CreateGameLogs(modelBuilder);
            CreatePlayers(modelBuilder);
            CreatePlayerCards(modelBuilder);
            CreateUsers(modelBuilder);

        }



    }
}
