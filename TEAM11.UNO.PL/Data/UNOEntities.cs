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

        Guid[] cardId = new Guid[56];
        Guid[] gameId = new Guid[4];
        Guid[] gamelogId = new Guid[3];
        Guid[] playerId = new Guid[6];
        Guid[] playercardId = new Guid[4];
        Guid[] userId = new Guid[5];

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


            // Todo: Verify the order of creation of the tables. There ight be an error. 

            // Goes first, has no connections to other tables.
            CreateCards(modelBuilder); 
            CreateUsers(modelBuilder);
            CreateGames(modelBuilder);

            // Goes later, has connections to other tables.
            CreatePlayers(modelBuilder);
            CreatePlayerCards(modelBuilder);
            CreateGameLogs(modelBuilder);            

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
                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                // Create default data now.
                List<tblCard> cards = new List<tblCard>
                {
                    // Blue
                    new tblCard { Id = cardId[0], Number = "1", Color = "Blue" },
                    new tblCard { Id = cardId[1], Number = "2", Color = "Blue" },
                    new tblCard { Id = cardId[2], Number = "3", Color = "Blue" },
                    new tblCard { Id = cardId[3], Number = "4", Color = "Blue" },
                    new tblCard { Id = cardId[4], Number = "5", Color = "Blue" },
                    new tblCard { Id = cardId[5], Number = "6", Color = "Blue" },
                    new tblCard { Id = cardId[6], Number = "7", Color = "Blue" },
                    new tblCard { Id = cardId[7], Number = "8", Color = "Blue" },
                    new tblCard { Id = cardId[8], Number = "9", Color = "Blue" },

                    new tblCard { Id = cardId[9], Number = "10", Color = "Blue" },
                    new tblCard { Id = cardId[10], Number = "11", Color = "Blue" },
                    new tblCard { Id = cardId[11], Number = "12", Color = "Blue" },
                    new tblCard { Id = cardId[12], Number = "13", Color = "Blue" },
                    new tblCard { Id = cardId[13], Number = "14", Color = "Blue" },

                    // Red
                    new tblCard { Id = cardId[14], Number = "1", Color = "Red" },
                    new tblCard { Id = cardId[15], Number = "2", Color = "Red" },
                    new tblCard { Id = cardId[16], Number = "3", Color = "Red" },
                    new tblCard { Id = cardId[17], Number = "4", Color = "Red" },
                    new tblCard { Id = cardId[18], Number = "5", Color = "Red" },
                    new tblCard { Id = cardId[19], Number = "6", Color = "Red" },
                    new tblCard { Id = cardId[20], Number = "7", Color = "Red" },
                    new tblCard { Id = cardId[21], Number = "8", Color = "Red" },
                    new tblCard { Id = cardId[22], Number = "9", Color = "Red" },

                    new tblCard { Id = cardId[23], Number = "10", Color = "Red" },
                    new tblCard { Id = cardId[24], Number = "11", Color = "Red" },
                    new tblCard { Id = cardId[25], Number = "12", Color = "Red" },
                    new tblCard { Id = cardId[26], Number = "13", Color = "Red" },
                    new tblCard { Id = cardId[27], Number = "14", Color = "Red" },

                    // Yellow
                    new tblCard { Id = cardId[28], Number = "1", Color = "Yellow" },
                    new tblCard { Id = cardId[29], Number = "2", Color = "Yellow" },
                    new tblCard { Id = cardId[30], Number = "3", Color = "Yellow" },
                    new tblCard { Id = cardId[31], Number = "4", Color = "Yellow" },
                    new tblCard { Id = cardId[32], Number = "5", Color = "Yellow" },
                    new tblCard { Id = cardId[33], Number = "6", Color = "Yellow" },
                    new tblCard { Id = cardId[34], Number = "7", Color = "Yellow" },
                    new tblCard { Id = cardId[35], Number = "8", Color = "Yellow" },
                    new tblCard { Id = cardId[36], Number = "9", Color = "Yellow" },

                    new tblCard { Id = cardId[37], Number = "10", Color = "Yellow" },
                    new tblCard { Id = cardId[38], Number = "11", Color = "Yellow" },
                    new tblCard { Id = cardId[39], Number = "12", Color = "Yellow" },
                    new tblCard { Id = cardId[40], Number = "13", Color = "Yellow" },
                    new tblCard { Id = cardId[41], Number = "14", Color = "Yellow" },

                    // Green
                    new tblCard { Id = cardId[42], Number = "1", Color = "Green" },
                    new tblCard { Id = cardId[43], Number = "2", Color = "Green" },
                    new tblCard { Id = cardId[44], Number = "3", Color = "Green" },
                    new tblCard { Id = cardId[45], Number = "4", Color = "Green" },
                    new tblCard { Id = cardId[46], Number = "5", Color = "Green" },
                    new tblCard { Id = cardId[47], Number = "6", Color = "Green" },
                    new tblCard { Id = cardId[48], Number = "7", Color = "Green" },
                    new tblCard { Id = cardId[49], Number = "8", Color = "Green" },
                    new tblCard { Id = cardId[50], Number = "9", Color = "Green" },

                    new tblCard { Id = cardId[51], Number = "10", Color = "Green" },
                    new tblCard { Id = cardId[52], Number = "11", Color = "Green" },
                    new tblCard { Id = cardId[53], Number = "12", Color = "Green" },
                    new tblCard { Id = cardId[54], Number = "13", Color = "Green" },
                    new tblCard { Id = cardId[55], Number = "14", Color = "Green" }

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

                List<tblGame> games = new List<tblGame>
                {   
                    new tblGame { Id = gameId[0], Name = "Test Game 1", CurrentTurnUserId = userId[0], IsPaused = false },
                    new tblGame { Id = gameId[1], Name = "Test Game 2", CurrentTurnUserId = userId[1], IsPaused = false },
                    new tblGame { Id = gameId[2], Name = "Test Game 3", CurrentTurnUserId = userId[2], IsPaused = false }
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
                    new tblGameLog { Id = gamelogId[0], Description = "Test Game Log 1", Timestamp = "Test Stamp 1", GameId = gameId[0] },
                    new tblGameLog { Id = gamelogId[1], Description = "Test Game Log 2", Timestamp = "Test Stamp 2", GameId = gameId[1] },
                    new tblGameLog { Id = gamelogId[2], Description = "Test Game Log 3", Timestamp = "Test Stamp 3", GameId = gameId[2] },
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

                // Junction table User and Game.

                // User

                entity.HasOne(d => d.User)
                .WithMany(p => p.Players)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_tblPlayer_UserId")
                .OnDelete(DeleteBehavior.Restrict);

                // Game

                entity.HasOne(d => d.Game)
                .WithMany(p => p.Players)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("fk_tblPlayer_GameId");

                List<tblPlayer> players = new List<tblPlayer>
                {
                    new tblPlayer { Id = playerId[0], IsComputerPlayer = false, UserId = userId[0], GameId = gameId[0]  },
                    new tblPlayer { Id = playerId[1], IsComputerPlayer = false, UserId = userId[1], GameId = gameId[1]  },
                    new tblPlayer { Id = playerId[2], IsComputerPlayer = false, UserId = userId[2], GameId = gameId[2]  },

                    new tblPlayer { Id = playerId[3], IsComputerPlayer = true, UserId = userId[3], GameId = gameId[0]  },
                    new tblPlayer { Id = playerId[4], IsComputerPlayer = true, UserId = userId[3], GameId = gameId[1]  },
                    new tblPlayer { Id = playerId[5], IsComputerPlayer = true, UserId = userId[3], GameId = gameId[2]  },
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

                // Junction table Card and Player.

                // Card 

                entity.HasOne(d => d.Card)
                .WithMany(p => p.Playercards)
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("fk_tblPlayerCard_CardId");

                // Player

                entity.HasOne(d => d.Player)
                .WithMany(p => p.Playercards)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("fk_tblPlayerCard_PlayerId");


                List<tblPlayerCard> playerCards = new List<tblPlayerCard>
                {
                    new tblPlayerCard { Id = playercardId[0], CardId = cardId[0], PlayerId = playerId[0], },
                    new tblPlayerCard { Id = playercardId[1], CardId = cardId[1], PlayerId = playerId[1], },
                    new tblPlayerCard { Id = playercardId[2], CardId = cardId[2], PlayerId = playerId[2], }
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
                    new tblUser { Id = userId[0], Username = "asteffes", Password = GetHash("Austin"), FirstName = "Austin", LastName = "Steffes"},
                    new tblUser { Id = userId[1], Username = "cguzman", Password = GetHash("Carlos"), FirstName = "Carlos", LastName = "Guzman"},
                    new tblUser { Id = userId[2], Username = "bfoote", Password = GetHash("maple"), FirstName = "Brian", LastName = "Foote"},
                    new tblUser { Id = userId[3], Username = "nonplayercharacter", Password = GetHash("NPC"), FirstName = "NPC", LastName = "NPC"}
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
