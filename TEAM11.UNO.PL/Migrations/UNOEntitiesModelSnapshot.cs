﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEAM11.UNO.PL.Data;

#nullable disable

namespace TEAM11.UNO.PL.Migrations
{
    [DbContext(typeof(UNOEntities))]
    partial class UNOEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblCard", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_tblCard_Id");

                    b.ToTable("tblCard", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6ea7b011-475a-482b-8abd-7bd8633086e5"),
                            Color = "Red",
                            Name = "R0",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("578e4f52-6ac3-464c-8b6a-a9e6030556fe"),
                            Color = "Red",
                            Name = "R1",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("db2092cc-76c1-4361-94d3-3e6281b95009"),
                            Color = "Red",
                            Name = "R2",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("85d89e42-358a-4feb-ad11-10096ef3221f"),
                            Color = "Red",
                            Name = "R3",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("f6362289-b5b7-4231-81d3-155f0dd380d9"),
                            Color = "Red",
                            Name = "R4",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("5c25bcc8-1098-427b-b760-d5bfc6ea0cd3"),
                            Color = "Red",
                            Name = "R5",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("da583c0c-003c-4a9a-85db-a616fb4b77f7"),
                            Color = "Red",
                            Name = "R6",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("7b413f17-7ecb-4100-9873-66a5d21d3bb5"),
                            Color = "Red",
                            Name = "R7",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("88b747f3-5e79-4adc-be01-15d3d0ab27aa"),
                            Color = "Red",
                            Name = "R8",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("7a830362-9736-49da-a00e-674223bc1a47"),
                            Color = "Red",
                            Name = "R9",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("9bb2cdbc-638b-4718-87bc-e1fcfbe3a270"),
                            Color = "Blue",
                            Name = "B0",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("cacc6cb5-29a9-4bd9-8ef5-c672e628b577"),
                            Color = "Blue",
                            Name = "B1",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("cc532621-820c-450c-9da0-b286e621d476"),
                            Color = "Blue",
                            Name = "B2",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("09d7e46e-9c9f-4896-81b8-fe8023b12edb"),
                            Color = "Blue",
                            Name = "B3",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("1a87130b-c662-417a-8d4c-788567ad619b"),
                            Color = "Blue",
                            Name = "B4",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("3199c101-d608-4c70-aa5e-37f64a321bf7"),
                            Color = "Blue",
                            Name = "B5",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("47e706d2-eaf6-440b-b751-33d717c2e31a"),
                            Color = "Blue",
                            Name = "B6",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("7740f5e5-af1c-46ff-9dde-3095e18e9d58"),
                            Color = "Blue",
                            Name = "B7",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("fe5231f0-c6c9-493b-8151-57654cb75dbf"),
                            Color = "Blue",
                            Name = "B8",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("de0f9384-2a8c-4362-97d7-b2fcfe8f9ac1"),
                            Color = "Blue",
                            Name = "B9",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("7174497e-41cb-42ec-9d90-6a0cebef32fd"),
                            Color = "Yellow",
                            Name = "Y0",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("a8cf9083-724b-4864-be12-ab54e2243cdf"),
                            Color = "Yellow",
                            Name = "Y1",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("09cedbc8-6078-4b74-a593-4e79ce01fc3b"),
                            Color = "Yellow",
                            Name = "Y2",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("e002ef75-3af7-4aae-9dd1-8a7428344c3e"),
                            Color = "Yellow",
                            Name = "Y3",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("9b98d458-e504-40fe-b2fe-04538ada7f0f"),
                            Color = "Yellow",
                            Name = "Y4",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("1bdb4c9d-9c70-4b6a-af36-94d641b517a9"),
                            Color = "Yellow",
                            Name = "Y5",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("a39f955c-4c77-43fc-9bc8-b2b09c3e1b10"),
                            Color = "Yellow",
                            Name = "Y6",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("039e430f-6218-4b7a-b4d4-ccf89e35f2e0"),
                            Color = "Yellow",
                            Name = "Y7",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("f00810e9-7c67-481e-ace6-d81c7170c6b1"),
                            Color = "Yellow",
                            Name = "Y8",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("184de25e-e72e-4425-a20e-dcd714892390"),
                            Color = "Yellow",
                            Name = "Y9",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("a9d1451b-e3c4-470a-8aa9-6ea8073bb191"),
                            Color = "Green",
                            Name = "G0",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("3c92ccf6-1793-41cc-8754-2fcf123241b5"),
                            Color = "Green",
                            Name = "G1",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("0f727c17-06ba-4c56-a83d-57790044c1e6"),
                            Color = "Green",
                            Name = "G2",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("0afef1c4-fa70-45f1-b637-c6588d57c22b"),
                            Color = "Green",
                            Name = "G3",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("cc681382-9aa2-4896-a67d-c8fde0e402c8"),
                            Color = "Green",
                            Name = "G4",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("a98cf121-8c44-4630-ac55-a98ad3f30d86"),
                            Color = "Green",
                            Name = "G5",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("fd874b18-f395-4815-b9e5-3f5d7287eff0"),
                            Color = "Green",
                            Name = "G6",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("f0996e59-cc22-4fc7-9ced-3ba9b753fcbb"),
                            Color = "Green",
                            Name = "G7",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("3e8c013c-9884-4980-8bd3-b5396a2c6536"),
                            Color = "Green",
                            Name = "G8",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("df89b4c6-522a-4331-9e5d-eaeea3781242"),
                            Color = "Green",
                            Name = "G9",
                            Type = "Number"
                        },
                        new
                        {
                            Id = new Guid("2a648108-2f87-4ded-be9b-b09200c0bfb0"),
                            Color = "Red",
                            Name = "Skip",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("16e9d7ba-006b-4d8c-bfdc-cb0df6ae5d56"),
                            Color = "Red",
                            Name = "Reverse",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("16635160-17c7-433a-83e8-6668b34b5a31"),
                            Color = "Red",
                            Name = "DrawTwo",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("e1871e2f-8ba9-44ea-8080-c073a0e71c3a"),
                            Color = "Blue",
                            Name = "Skip",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("62a49e36-ba37-4943-b1b8-ace3c5ae705d"),
                            Color = "Blue",
                            Name = "Reverse",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("85bc4a5c-2f11-4efe-97f3-4302485db0c5"),
                            Color = "Blue",
                            Name = "DrawTwo",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("86aa2f43-6e84-4ff9-b9c7-3735272449ae"),
                            Color = "Yellow",
                            Name = "Skip",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("e0e4855f-f2e9-4d95-8bad-f3d6ee89254b"),
                            Color = "Yellow",
                            Name = "Reverse",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("f2a4801a-a5c9-40d0-bed1-1ee11e23cbe7"),
                            Color = "Yellow",
                            Name = "DrawTwo",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("5e6c00e8-c4f1-48d2-8d29-5df2e52c84cc"),
                            Color = "Green",
                            Name = "Skip",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("14fede7b-0cad-4b17-95c0-b7ce150fa228"),
                            Color = "Green",
                            Name = "Reverse",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("db5fa18a-bbd0-4dd7-a566-3a465839eaee"),
                            Color = "Green",
                            Name = "DrawTwo",
                            Type = "Action"
                        },
                        new
                        {
                            Id = new Guid("48dbbce9-e630-40dc-b02c-8620cffebf54"),
                            Color = "Wild",
                            Name = "Wild",
                            Type = "Wild"
                        },
                        new
                        {
                            Id = new Guid("1ad6bd64-0f28-4a8f-8490-28cf62f9e750"),
                            Color = "Wild",
                            Name = "Wild Draw Four",
                            Type = "Wild"
                        });
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblGame", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPaused")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblGame_Id");

                    b.HasIndex("UserId");

                    b.ToTable("tblGame", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("08ce4503-c094-4142-b810-eb63d3122f88"),
                            IsPaused = true,
                            Name = "Game 1",
                            UserId = new Guid("d7059aae-7259-41a6-8c93-cbb95beb0cbc")
                        },
                        new
                        {
                            Id = new Guid("a39d5161-0d17-499d-9cc3-3307ce1e26eb"),
                            IsPaused = true,
                            Name = "Game 2",
                            UserId = new Guid("6ccf0a27-06eb-4ba8-a9de-4d70b6793425")
                        },
                        new
                        {
                            Id = new Guid("425328a8-6237-46b2-b188-e737d5b99edb"),
                            IsPaused = true,
                            Name = "Game 3",
                            UserId = new Guid("99932bc6-9167-4b11-9b12-57e3493bf385")
                        });
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblGameLog", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Timestamp")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_tblGameLog_Id");

                    b.HasIndex("GameId");

                    b.ToTable("tblGameLog", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("019d2138-2146-41c6-a266-f0f14ee57f13"),
                            Description = "Game 1 Log",
                            GameId = new Guid("08ce4503-c094-4142-b810-eb63d3122f88"),
                            Timestamp = "12:00pm"
                        },
                        new
                        {
                            Id = new Guid("d4be755d-7c6a-4d64-8fd8-b0cdf5af6442"),
                            Description = "Game 2 Log",
                            GameId = new Guid("a39d5161-0d17-499d-9cc3-3307ce1e26eb"),
                            Timestamp = "1:00pm"
                        },
                        new
                        {
                            Id = new Guid("885b37b6-bae0-4ba3-8ae5-be0c64f0cb8f"),
                            Description = "Game 3 Log",
                            GameId = new Guid("425328a8-6237-46b2-b188-e737d5b99edb"),
                            Timestamp = "2:00pm"
                        });
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblPlayer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsComputerPlayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblPlayer_Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("tblPlayer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("05e3fee9-10b0-43b0-94f7-b565b1ae8e9d"),
                            GameId = new Guid("08ce4503-c094-4142-b810-eb63d3122f88"),
                            IsComputerPlayer = false,
                            UserId = new Guid("d7059aae-7259-41a6-8c93-cbb95beb0cbc")
                        });
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblPlayerCard", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblPlayerCard_Id");

                    b.HasIndex("CardId");

                    b.HasIndex("PlayerId");

                    b.ToTable("tblPlayerCard", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c481c75c-8f24-4251-bbd5-aa423ef2e632"),
                            CardId = new Guid("6ea7b011-475a-482b-8abd-7bd8633086e5"),
                            PlayerId = new Guid("05e3fee9-10b0-43b0-94f7-b565b1ae8e9d")
                        },
                        new
                        {
                            Id = new Guid("175274cd-825a-4ace-a1db-72682cc83cb7"),
                            CardId = new Guid("578e4f52-6ac3-464c-8b6a-a9e6030556fe"),
                            PlayerId = new Guid("e699a7b1-51eb-4652-afa2-645cc1a22669")
                        },
                        new
                        {
                            Id = new Guid("0af356be-7f26-41d2-b7d4-d2fb906bb49a"),
                            CardId = new Guid("db2092cc-76c1-4361-94d3-3e6281b95009"),
                            PlayerId = new Guid("4e7cca10-751e-4de4-a527-c115a5703ffa")
                        },
                        new
                        {
                            Id = new Guid("276c76b2-85ef-44ac-b55f-f40810a31841"),
                            CardId = new Guid("85d89e42-358a-4feb-ad11-10096ef3221f"),
                            PlayerId = new Guid("2ff9f337-6070-4081-a71d-ccc8078398f0")
                        });
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_tblUser_Id");

                    b.ToTable("tblUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("71a95b24-b212-4f9b-8a18-e546f9cea4bc"),
                            FirstName = "Austin",
                            LastName = "Steffes",
                            Password = "Wwbx8IUDtOY0aSZmfTGPD51+n9E=",
                            Username = "Austin"
                        },
                        new
                        {
                            Id = new Guid("31bf8e51-855b-44e0-8038-728e080a5f56"),
                            FirstName = "Carlos",
                            LastName = "Guzman",
                            Password = "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=",
                            Username = "Carlos"
                        },
                        new
                        {
                            Id = new Guid("c08001ea-66a0-47dc-8d5a-8c84a8b0cc58"),
                            FirstName = "Brian",
                            LastName = "Foote",
                            Password = "dcRQw/ljvvuRLuefC2PlY2UngPA=",
                            Username = "Brian"
                        },
                        new
                        {
                            Id = new Guid("6ddda626-1da0-435d-88c4-b19b3b10d1ed"),
                            FirstName = "Bot",
                            LastName = "Bot",
                            Password = "OjGS4nkcV4YYDQImS16TRUBa+n0=",
                            Username = "Bot"
                        });
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblGame", b =>
                {
                    b.HasOne("TEAM11.UNO.PL.Entities.tblUser", "CurrentTurnUserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tblGame_UserId");

                    b.Navigation("CurrentTurnUserId");
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblGameLog", b =>
                {
                    b.HasOne("TEAM11.UNO.PL.Entities.tblGame", "Game")
                        .WithMany("Gamelogs")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tblGameLog_GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblPlayer", b =>
                {
                    b.HasOne("TEAM11.UNO.PL.Entities.tblGame", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tblPlayer_GameId");

                    b.HasOne("TEAM11.UNO.PL.Entities.tblUser", "User")
                        .WithMany("Players")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tblPlayer_UserId");

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblPlayerCard", b =>
                {
                    b.HasOne("TEAM11.UNO.PL.Entities.tblCard", "Card")
                        .WithMany("Playercards")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tblPlayerCard_CardId");

                    b.HasOne("TEAM11.UNO.PL.Entities.tblPlayer", "Player")
                        .WithMany("Playercards")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tblPlayerCard_PlayerId");

                    b.Navigation("Card");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblCard", b =>
                {
                    b.Navigation("Playercards");
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblGame", b =>
                {
                    b.Navigation("Gamelogs");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblPlayer", b =>
                {
                    b.Navigation("Playercards");
                });

            modelBuilder.Entity("TEAM11.UNO.PL.Entities.tblUser", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
