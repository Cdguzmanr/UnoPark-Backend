using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
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
        // Ain't got a clue about the "size" of the guid that we need. How do we figure that out?

        Guid[] cardId = new Guid[1];
        Guid[] gameId = new Guid[1];
        Guid[] gamelogId = new Guid[1];
        Guid[] playerId = new Guid[1];
        Guid[] playercardId = new Guid[1];
        Guid[] userId = new Guid[1];

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
            for (int i = 0; i < cardId.Length; i++)
                cardId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblCard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblCard_Id");

                entity.ToTable("tblCard");

                // Since we are using guids and foreach them above, we do not need to generate on creation. That's why this is set to Never.
                entity.Property(e => e.Id).ValueGeneratedNever();

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
                    new tblCard { Name = "DrawTwo", Color = "Red", Type = "Action" },
                    new tblCard { Name = "Skip", Color = "Blue", Type = "Action" },
                    new tblCard { Name = "Reverse", Color = "Blue", Type = "Action" },
                    new tblCard { Name = "DrawTwo", Color = "Blue", Type = "Action" },
                    new tblCard { Name = "Skip", Color = "Yellow", Type = "Action" },
                    new tblCard { Name = "Reverse", Color = "Yellow", Type = "Action" },
                    new tblCard { Name = "DrawTwo", Color = "Yellow", Type = "Action" },
                    new tblCard { Name = "Skip", Color = "Green", Type = "Action" },
                    new tblCard { Name = "Reverse", Color = "Green", Type = "Action" },
                    new tblCard { Name = "DrawTwo", Color = "Green", Type = "Action" },

                    // Wild cards
                    new tblCard { Name = "Wild", Color = "Wild", Type = "Wild" },
                    new tblCard { Name = "Wild Draw Four", Color = "Wild", Type = "Wild" }

                };
                modelBuilder.Entity<tblCard>().HasData(cards);
            });
        }

        private void CreateGames(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < gameId.Length; i++)
                gameId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblGame>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblGame_Id");

                entity.ToTable("tblGame");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsPaused)
                    .IsRequired()
                    .HasDefaultValue(false);

                // Double checking here, CurrentTurnUserId is a foreign key to Id in the User table?
                // Right since we need to get the "current" player.

                entity.HasOne(d => d.CurrentTurnUserId)
                  .WithMany(p => p.Games)

                  // Is this suppose to be CurrentTurnUserId or Id, I think Id.
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("fk_tblGame_UserId");

                List<tblGame> games = new List<tblGame>
                {
                    new tblGame { Name = "Game1", IsPaused = true },
                    new tblGame { Name = "Game2", IsPaused = true },
                    new tblGame { Name = "Game3", IsPaused = true },
                };

                modelBuilder.Entity<tblGame>().HasData(games);

            });
        }

        private void CreateGameLogs(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < gamelogId.Length; i++)
                gamelogId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblGameLog>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblGameLog_Id");

                entity.ToTable("tblGameLog");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Game)
                  .WithMany(p => p.Gamelogs)
                  .HasForeignKey(d => d.GameId)
                  .HasConstraintName("fk_tblGameLog_GameId");

                List<tblGameLog> gamelogs = new List<tblGameLog>
                {
                    new tblGameLog { Description = "Game 1 Log", Timestamp = "12:00pm" },
                    new tblGameLog { Description = "Game 2 Log", Timestamp = "1:00pm" },
                    new tblGameLog { Description = "Game 3 Log", Timestamp = "2:00pm" }
                };

                modelBuilder.Entity<tblGame>().HasData(gamelogs);

            });
        }

        private void CreatePlayers(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < playerId.Length; i++)
                playerId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblPlayer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblPlayer_Id");

                entity.ToTable("tblPlayer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsComputerPlayer)
                    .IsRequired()
                    .HasDefaultValue(false);

                entity.HasOne(d => d.User)
                  .WithMany(p => p.Players)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("fk_tblUser_Id");

                entity.HasOne(d => d.Game)
                  .WithMany(p => p.Players)
                  .HasForeignKey(d => d.GameId)
                  .HasConstraintName("fk_tblGame_Id");

                List<tblPlayer> players = new List<tblPlayer>
                {
                    new tblPlayer { IsComputerPlayer = false },
                    new tblPlayer { IsComputerPlayer = false },
                    new tblPlayer { IsComputerPlayer = false },
                    new tblPlayer { IsComputerPlayer = true }
                };

                modelBuilder.Entity<tblPlayer>().HasData(players);
            });
        }

        private void CreatePlayerCards(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < playercardId.Length; i++)
                playercardId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblPlayerCard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblPlayerCard_Id");

                entity.ToTable("tblPlayerCard");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Player)
                  .WithMany(p => p.Playercards)
                  .HasForeignKey(d => d.PlayerId)
                  .HasConstraintName("fk_tblPlayerCard_PlayerId");

                entity.HasOne(d => d.Card)
                  .WithMany(p => p.Playercards)
                  .HasForeignKey(d => d.CardId)
                  .HasConstraintName("fk_tblPlayerCard_CardId");

                List<tblPlayerCard> playerCards = new List<tblPlayerCard>
                {
                    
                };

                modelBuilder.Entity<tblPlayerCard>().HasData(playerCards);
            });
        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < userId.Length; i++)
                userId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblUser_Id");

                entity.ToTable("tblUser");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                List<tblUser> users = new List<tblUser>
                {
                    new tblUser { Username = "Austin", Password = GetHash("Austin"), FirstName = "Austin", LastName = "Steffes"},
                    new tblUser { Username = "Carlos", Password = GetHash("Carlos"), FirstName = "Carlos", LastName = "Guzman"},
                    new tblUser { Username = "Brian", Password = GetHash("Brian"), FirstName = "Brian", LastName = "Foote"}
                };

                modelBuilder.Entity<tblUser>().HasData(users);
            });
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
