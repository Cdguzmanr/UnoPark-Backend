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

        private void CreateCards(ModelBuilder modelBuilder)
        {
            // Guessing we need to change this to work with Id instead of Guid, but it might create the Id for us automatically? 

            //for (int i = 0; i < formatId.Length; i++)
            //    formatId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblCard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblCard_Id");

                entity.ToTable("tblCard");

                // Going to need to change this since we are using Int and not Guids (that's what the foreach does above)
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                // Otherwise, just creating the properties from the Entities folder.
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                // Create default data now.
                List<tblCard> cards = new List<tblCard>
                {
                    // Number cards
                    new tblCard { Name = "0", Color = "Red", Type = "Number" },
                    new tblCard { Name = "1", Color = "Red", Type = "Number" },
                    new tblCard { Name = "2", Color = "Red", Type = "Number" },
                    new tblCard { Name = "3", Color = "Red", Type = "Number" },
                    new tblCard { Name = "4", Color = "Red", Type = "Number" },
                    new tblCard { Name = "5", Color = "Red", Type = "Number" },
                    new tblCard { Name = "6", Color = "Red", Type = "Number" },
                    new tblCard { Name = "7", Color = "Red", Type = "Number" },
                    new tblCard { Name = "8", Color = "Red", Type = "Number" },
                    new tblCard { Name = "9", Color = "Red", Type = "Number" },
                    new tblCard { Name = "0", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "1", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "2", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "3", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "4", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "5", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "6", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "7", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "8", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "9", Color = "Blue", Type = "Number" },

                    // Action cards
                    new tblCard { Name = "Skip", Color = "Red", Type = "Action" },
                    new tblCard { Name = "Reverse", Color = "Red", Type = "Action" },
                    new tblCard { Name = "Draw Two", Color = "Red", Type = "Action" },
                    new tblCard { Name = "Skip", Color = "Blue", Type = "Action" },
                    new tblCard { Name = "Reverse", Color = "Blue", Type = "Action" },
                    new tblCard { Name = "Draw Two", Color = "Blue", Type = "Action" },

                    // Wild cards
                    new tblCard { Name = "Wild", Color = "Wild", Type = "Wild" },
                    new tblCard { Name = "Wild Draw Four", Color = "Wild", Type = "Wild" }

                };
                modelBuilder.Entity<tblCard>().HasData(cards);

            });
        }

        private void CreateGames(ModelBuilder modelBuilder)
        {

        }

        private void CreateGameLogs(ModelBuilder modelBuilder)
        {

        }

        private void CreatePlayers(ModelBuilder modelBuilder)
        {

        }

        private void CreatePlayerCards(ModelBuilder modelBuilder)
        {

        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {

        }

        private static string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }

    }
}
