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

        Guid[] cardId = new Guid[54];
        Guid[] gameId = new Guid[4];
        Guid[] gamelogId = new Guid[3];
        Guid[] playerId = new Guid[4];
        Guid[] playercardId = new Guid[4];
        Guid[] userId = new Guid[4];

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
                    new tblCard { Id = cardId[0], Name = "R0", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[1], Name = "R1", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[2], Name = "R2", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[3], Name = "R3", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[4], Name = "R4", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[5], Name = "R5", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[6], Name = "R6", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[7], Name = "R7", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[8], Name = "R8", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[9], Name = "R9", Color = "Red", Type = "Number" },
                    new tblCard { Id = cardId[10], Name = "B0", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[11], Name = "B1", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[12], Name = "B2", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[13], Name = "B3", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[14], Name = "B4", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[15], Name = "B5", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[16], Name = "B6", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[17], Name = "B7", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[18], Name = "B8", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[19], Name = "B9", Color = "Blue", Type = "Number" },
                    new tblCard { Id = cardId[20], Name = "Y0", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[21], Name = "Y1", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[22], Name = "Y2", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[23], Name = "Y3", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[24], Name = "Y4", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[25], Name = "Y5", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[26], Name = "Y6", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[27], Name = "Y7", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[28], Name = "Y8", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[29], Name = "Y9", Color = "Yellow", Type = "Number" },
                    new tblCard { Id = cardId[30], Name = "G0", Color = "Green", Type = "Number" },
                    new tblCard { Id = cardId[31], Name = "G1", Color = "Green", Type = "Number" },
                    new tblCard { Id = cardId[32], Name = "G2", Color = "Green", Type = "Number" },
                    new tblCard { Id = cardId[33], Name = "G3", Color = "Green", Type = "Number" },
                    new tblCard { Id = cardId[34], Name = "G4", Color = "Green", Type = "Number" },
                    new tblCard { Id = cardId[35], Name = "G5", Color = "Green", Type = "Number" },
                    new tblCard { Id = cardId[36], Name = "G6", Color = "Green", Type = "Number" },
                    new tblCard { Id = cardId[37], Name = "G7", Color = "Green", Type = "Number" },
                    new tblCard { Id = cardId[38], Name = "G8", Color = "Green", Type = "Number" },
                    new tblCard { Id = cardId[39], Name = "G9", Color = "Green", Type = "Number" },

                    // Action cards

                    // What names would we like these cards to be below? The ones above makes sense for LETTER (COLOR) then Number...
                    // But what about the cards below?

                    new tblCard { Id = cardId[40], Name = "Skip", Color = "Red", Type = "Action" },
                    new tblCard { Id = cardId[41], Name = "Reverse", Color = "Red", Type = "Action" },
                    new tblCard { Id = cardId[42], Name = "DrawTwo", Color = "Red", Type = "Action" },
                    new tblCard { Id = cardId[43], Name = "Skip", Color = "Blue", Type = "Action" },
                    new tblCard { Id = cardId[44], Name = "Reverse", Color = "Blue", Type = "Action" },
                    new tblCard { Id = cardId[45], Name = "DrawTwo", Color = "Blue", Type = "Action" },
                    new tblCard { Id = cardId[46], Name = "Skip", Color = "Yellow", Type = "Action" },
                    new tblCard { Id = cardId[47], Name = "Reverse", Color = "Yellow", Type = "Action" },
                    new tblCard { Id = cardId[48], Name = "DrawTwo", Color = "Yellow", Type = "Action" },
                    new tblCard { Id = cardId[49], Name = "Skip", Color = "Green", Type = "Action" },
                    new tblCard { Id = cardId[50], Name = "Reverse", Color = "Green", Type = "Action" },
                    new tblCard { Id = cardId[51], Name = "DrawTwo", Color = "Green", Type = "Action" },

                    // Wild cards
                    new tblCard { Id = cardId[52], Name = "Wild", Color = "Wild", Type = "Wild" },
                    new tblCard { Id = cardId[53], Name = "Wild Draw Four", Color = "Wild", Type = "Wild" }

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
                    .IsRequired();
                    

                // Double checking here, CurrentTurnUserId is a foreign key to Id in the User table?
                // Right since we need to get the "current" player.

                // Ensure that the relationship is correctly defined

                entity.HasOne(d => d.CurrentTurnUser)
                    .WithMany()
                    .HasForeignKey(d => d.CurrentTurnUserId)
                    .HasConstraintName("fk_tblGame_CurrentTurnUserId")
                    .OnDelete(DeleteBehavior.Restrict);


                List<tblGame> games = new List<tblGame>
                {
                    new tblGame { Id = gameId[0], Name = "Game 1", IsPaused = true, CurrentTurnUserId = playerId[0] },
                    new tblGame { Id = gameId[1], Name = "Game 2", IsPaused = true, CurrentTurnUserId = playerId[1] },
                    new tblGame { Id = gameId[2], Name = "Game 3", IsPaused = true, CurrentTurnUserId = playerId[2] },
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
                    new tblGameLog { Id = gamelogId[0], Description = "Game 1 Log", Timestamp = "12:00pm", GameId = gameId[0] },
                    new tblGameLog { Id = gamelogId[1], Description = "Game 2 Log", Timestamp = "1:00pm", GameId = gameId[1] },
                    new tblGameLog { Id = gamelogId[2], Description = "Game 3 Log", Timestamp = "2:00pm", GameId = gameId[2] }
                };

                modelBuilder.Entity<tblGameLog>().HasData(gamelogs);

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
                    .HasConstraintName("fk_tblPlayer_UserId")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("fk_tblPlayer_GameId")
                    .OnDelete(DeleteBehavior.Restrict);

                List<tblPlayer> players = new List<tblPlayer>
                {
                    new tblPlayer { Id = playerId[0], IsComputerPlayer = false, UserId = userId[0], GameId = gameId[0] },
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
                    new tblPlayerCard { Id = Guid.NewGuid(), CardId = cardId[0], PlayerId = playerId[0] },
                    new tblPlayerCard { Id = Guid.NewGuid(), CardId = cardId[1], PlayerId = playerId[1] },
                    new tblPlayerCard { Id = Guid.NewGuid(), CardId = cardId[2], PlayerId = playerId[2] },
                    new tblPlayerCard { Id = Guid.NewGuid(), CardId = cardId[3], PlayerId = playerId[3] },
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
                    new tblUser { Id = userId[0], Username = "Austin", Password = GetHash("Austin"), FirstName = "Austin", LastName = "Steffes"},
                    new tblUser { Id = userId[1], Username = "Carlos", Password = GetHash("Carlos"), FirstName = "Carlos", LastName = "Guzman"},
                    new tblUser { Id = userId[2], Username = "Brian", Password = GetHash("Brian"), FirstName = "Brian", LastName = "Foote"},
                    new tblUser { Id = userId[3], Username = "Bot", Password = GetHash("Bot"), FirstName = "Bot", LastName = "Bot"}
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
