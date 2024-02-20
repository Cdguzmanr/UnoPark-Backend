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
                    new tblCard { Name = "R0", Color = "Red", Type = "Number" },
                    new tblCard { Name = "R1", Color = "Red", Type = "Number" },
                    new tblCard { Name = "R2", Color = "Red", Type = "Number" },
                    new tblCard { Name = "R3", Color = "Red", Type = "Number" },
                    new tblCard { Name = "R4", Color = "Red", Type = "Number" },
                    new tblCard { Name = "R5", Color = "Red", Type = "Number" },
                    new tblCard { Name = "R6", Color = "Red", Type = "Number" },
                    new tblCard { Name = "R7", Color = "Red", Type = "Number" },
                    new tblCard { Name = "R8", Color = "Red", Type = "Number" },
                    new tblCard { Name = "R9", Color = "Red", Type = "Number" },
                    new tblCard { Name = "B0", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "B1", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "B2", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "B3", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "B4", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "B5", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "B6", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "B7", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "B8", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "B9", Color = "Blue", Type = "Number" },
                    new tblCard { Name = "Y0", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "Y1", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "Y2", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "Y3", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "Y4", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "Y5", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "Y6", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "Y7", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "Y8", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "Y9", Color = "Yellow", Type = "Number" },
                    new tblCard { Name = "G0", Color = "Green", Type = "Number" },
                    new tblCard { Name = "G1", Color = "Green", Type = "Number" },
                    new tblCard { Name = "G2", Color = "Green", Type = "Number" },
                    new tblCard { Name = "G3", Color = "Green", Type = "Number" },
                    new tblCard { Name = "G4", Color = "Green", Type = "Number" },
                    new tblCard { Name = "G5", Color = "Green", Type = "Number" },
                    new tblCard { Name = "G6", Color = "Green", Type = "Number" },
                    new tblCard { Name = "G7", Color = "Green", Type = "Number" },
                    new tblCard { Name = "G8", Color = "Green", Type = "Number" },
                    new tblCard { Name = "G9", Color = "Green", Type = "Number" },

                    // Action cards

                    // What names would we like these cards to be below? The ones above makes sense for LETTER (COLOR) then Number...
                    // But what about the cards below?

                    new tblCard { Name = "Skip", Color = "Red", Type = "Action" },
                    new tblCard { Name = "Reverse", Color = "Red", Type = "Action" },
                    new tblCard { Name = "Draw Two", Color = "Red", Type = "Action" },
                    new tblCard { Name = "Skip", Color = "Blue", Type = "Action" },
                    new tblCard { Name = "Reverse", Color = "Blue", Type = "Action" },
                    new tblCard { Name = "Draw Two", Color = "Blue", Type = "Action" },
                    new tblCard { Name = "Skip", Color = "Yellow", Type = "Action" },
                    new tblCard { Name = "Reverse", Color = "Yellow", Type = "Action" },
                    new tblCard { Name = "Draw Two", Color = "Yellow", Type = "Action" },
                    new tblCard { Name = "Skip", Color = "Green", Type = "Action" },
                    new tblCard { Name = "Reverse", Color = "Green", Type = "Action" },
                    new tblCard { Name = "Draw Two", Color = "Green", Type = "Action" },

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
