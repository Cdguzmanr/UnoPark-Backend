using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TEAM11.UNO.PL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCard_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsPaused = table.Column<bool>(type: "bit", nullable: false),
                    CurrentTurnUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGame_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblGame_CurrentTurnUserId",
                        column: x => x.CurrentTurnUserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblGameLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Timestamp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGameLog_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblGameLog_GameId",
                        column: x => x.GameId,
                        principalTable: "tblGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPlayer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsComputerPlayer = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPlayer_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblPlayer_GameId",
                        column: x => x.GameId,
                        principalTable: "tblGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tblPlayer_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPlayerCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPlayerCard_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblPlayerCard_CardId",
                        column: x => x.CardId,
                        principalTable: "tblCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tblPlayerCard_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "tblPlayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "Color", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("04f3efb5-1422-4bea-a194-98e7e26f2a1c"), "Green", "G9", "Number" },
                    { new Guid("08c8cb79-c74d-46f8-9f73-0f3f0659879e"), "Green", "G5", "Number" },
                    { new Guid("0a857abf-af8c-48ad-8cdc-08d9506e82a0"), "Blue", "B5", "Number" },
                    { new Guid("0b254543-651c-467e-b405-2a84fd01ce6a"), "Green", "G6", "Number" },
                    { new Guid("25bdba97-856e-4b46-86d0-7c8412aea258"), "Yellow", "Reverse", "Action" },
                    { new Guid("362bb8f0-23e1-48b4-8d29-b43525e41f7f"), "Yellow", "Y6", "Number" },
                    { new Guid("378e495e-c8f2-41a9-a759-3c2bd929fccc"), "Blue", "B1", "Number" },
                    { new Guid("4a924450-1485-47f8-a2ee-ea34a084b26b"), "Red", "R4", "Number" },
                    { new Guid("4ac5810b-52c6-44f0-8081-0aad3c39acc5"), "Green", "G4", "Number" },
                    { new Guid("566a834a-0f8d-4d61-b533-d756b302f994"), "Green", "G2", "Number" },
                    { new Guid("56f1584d-0ee0-4f40-bc6e-607bf8820b5b"), "Green", "G1", "Number" },
                    { new Guid("5ae0638b-79e8-4fc6-9b5f-63b8b114228c"), "Yellow", "Y7", "Number" },
                    { new Guid("5c249c9f-3db3-49d7-90e0-bb16b0100580"), "Yellow", "Y1", "Number" },
                    { new Guid("5c92449c-e480-42a3-b738-37747059672e"), "Yellow", "Skip", "Action" },
                    { new Guid("5cc0af94-7df4-4dbe-8727-5c19afb9d5bd"), "Yellow", "Y5", "Number" },
                    { new Guid("5f8a0ff7-fda1-4e86-9c16-b0a92c6ef07c"), "Yellow", "Y2", "Number" },
                    { new Guid("677ffb76-9cc9-426e-8cbb-67f197b18619"), "Red", "R9", "Number" },
                    { new Guid("689e9a98-a4a7-49f5-919c-34aa92005817"), "Green", "Skip", "Action" },
                    { new Guid("7330b2c6-e199-4419-abf6-ea781a461eda"), "Red", "R1", "Number" },
                    { new Guid("7465734d-0b2d-4119-9225-6c371b4734e1"), "Green", "Reverse", "Action" },
                    { new Guid("788d6820-8f92-43b1-9d37-f7175902e32e"), "Blue", "B0", "Number" },
                    { new Guid("7aaa4331-d6ea-4fed-925f-50fd0412cb57"), "Red", "DrawTwo", "Action" },
                    { new Guid("7b2a5a36-230f-4e36-a718-2f1767d94360"), "Yellow", "Y8", "Number" },
                    { new Guid("7e952559-d3eb-4a6f-b339-f2229928ec88"), "Yellow", "Y9", "Number" },
                    { new Guid("82ce1671-2cd6-4cf5-b384-0da35838b918"), "Blue", "DrawTwo", "Action" },
                    { new Guid("86bdfce8-2b8c-497f-b927-19be6b118155"), "Blue", "B7", "Number" },
                    { new Guid("8df37899-2edd-410e-9142-1dd3d6c17ee9"), "Blue", "Skip", "Action" },
                    { new Guid("8ed12283-e83a-47c4-b8eb-1065da1a9ecb"), "Red", "R0", "Number" },
                    { new Guid("8ef0604b-3b20-45a3-ba56-23601e5d230f"), "Green", "G0", "Number" },
                    { new Guid("97e423e0-2e51-4550-992c-e547d09fce20"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("99926afe-18fd-4375-92ae-58724ddfaf03"), "Wild", "Wild", "Wild" },
                    { new Guid("a31cf900-152d-4de5-b113-4a6d0e8023c2"), "Green", "G7", "Number" },
                    { new Guid("a32ad6da-1569-44c7-a4f2-5ebd923bd72d"), "Red", "R6", "Number" },
                    { new Guid("a7b46dad-8b44-43fb-b27c-adfd455c6eed"), "Blue", "B2", "Number" },
                    { new Guid("a93860a1-385b-4f55-8c1f-476bd55706f4"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("acb45178-ccf3-4dd5-945f-8d990872e8e3"), "Yellow", "Y0", "Number" },
                    { new Guid("ae0a3b13-bcd0-4f45-b17b-2ff93a44e9e3"), "Blue", "B4", "Number" },
                    { new Guid("bcad1f07-38a5-490b-9143-5d6c9734541e"), "Green", "G3", "Number" },
                    { new Guid("beca98e7-0145-46b0-a80d-5f1a4329c3f2"), "Red", "R5", "Number" },
                    { new Guid("bf974281-f393-4075-b632-3c4279bbaa1d"), "Red", "R2", "Number" },
                    { new Guid("c365b2e4-4923-4915-844e-1263484d5708"), "Yellow", "Y4", "Number" },
                    { new Guid("c41ee893-d479-4eb1-809d-2c63aa240c83"), "Yellow", "Y3", "Number" },
                    { new Guid("cc5ab6ab-0e49-4b70-99dd-d02e62cbdda5"), "Green", "G8", "Number" },
                    { new Guid("cf91378a-3eb4-4cb9-bcb4-c737c8b7b4f3"), "Blue", "Reverse", "Action" },
                    { new Guid("d0ff2336-2de0-4ee1-a6a8-c558019817db"), "Red", "R7", "Number" },
                    { new Guid("d55388bf-76f6-4692-b60b-e3b78437fc2f"), "Red", "Reverse", "Action" },
                    { new Guid("d7d4ebe4-2b92-4578-8e3f-209621a754d7"), "Blue", "B6", "Number" },
                    { new Guid("d891738b-00e2-4271-acf4-6cef6a0d5cdc"), "Blue", "B9", "Number" },
                    { new Guid("e8dec34a-fe6d-4398-9db4-0e5595f6a45c"), "Blue", "B3", "Number" },
                    { new Guid("ecf7735d-b887-45c6-8206-0feb3eb24bcd"), "Red", "R3", "Number" },
                    { new Guid("f1982bfb-f6fa-461b-ab43-b6b7ab778032"), "Green", "DrawTwo", "Action" },
                    { new Guid("f2049347-7298-4b18-8261-c4a4d577e16d"), "Red", "Skip", "Action" },
                    { new Guid("fb5c4fbb-7be9-456e-ae62-1096e1ddefc0"), "Blue", "B8", "Number" },
                    { new Guid("ff37fd44-e053-4d27-aff7-0be8e180c2c5"), "Red", "R8", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "CurrentTurnUserId", "IsPaused", "Name" },
                values: new object[,]
                {
                    { new Guid("5b34913e-55f9-467b-9d4d-0fd001705f60"), new Guid("76a6ab59-d7ed-441f-bd99-78c0c76fda74"), true, "Game 2" },
                    { new Guid("6cf61197-9e20-473b-bdac-a519966269c2"), new Guid("cbb644a5-cfc3-40c7-b040-53a4d18f449e"), true, "Game 1" },
                    { new Guid("7ed005b7-bcde-43f1-966d-657eb89bc308"), new Guid("cec2c1a1-1c72-4a9c-8724-76aa74a03396"), true, "Game 3" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("434b40b7-aa4d-4aeb-b719-178706cb90cb"), "Bot", "Bot", "OjGS4nkcV4YYDQImS16TRUBa+n0=", "Bot" },
                    { new Guid("84826276-af90-4f04-a43c-33ccb0d4a668"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" },
                    { new Guid("9297a543-3d3d-4372-8ff0-3233d28571f3"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" },
                    { new Guid("d0d9b86c-d4c4-475d-abd9-5b67ce137eb7"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("69770706-a303-4f31-94ce-ba82356510fc"), "Game 3 Log", new Guid("7ed005b7-bcde-43f1-966d-657eb89bc308"), "2:00pm" },
                    { new Guid("a810c34a-7798-4a2a-a176-e390bd1352a3"), "Game 1 Log", new Guid("6cf61197-9e20-473b-bdac-a519966269c2"), "12:00pm" },
                    { new Guid("fa2b64ee-47e3-451a-8570-18cd65d5bfee"), "Game 2 Log", new Guid("5b34913e-55f9-467b-9d4d-0fd001705f60"), "1:00pm" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4dcabcc3-f34f-48c8-b037-021b2f4993cb"), new Guid("5b34913e-55f9-467b-9d4d-0fd001705f60"), new Guid("d0d9b86c-d4c4-475d-abd9-5b67ce137eb7") },
                    { new Guid("58413ad9-2faf-4f69-8aa2-8a830d50de14"), new Guid("6cf61197-9e20-473b-bdac-a519966269c2"), new Guid("d0d9b86c-d4c4-475d-abd9-5b67ce137eb7") },
                    { new Guid("87441425-7c40-433d-9561-c228e0e59d5a"), new Guid("7ed005b7-bcde-43f1-966d-657eb89bc308"), new Guid("d0d9b86c-d4c4-475d-abd9-5b67ce137eb7") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("05f7c37b-ee84-4c80-8ca4-8eadbb767667"), new Guid("ecf7735d-b887-45c6-8206-0feb3eb24bcd"), new Guid("7387595f-6e37-432a-be37-298449e8947b") },
                    { new Guid("42303d56-a373-48ad-9fcc-95593dbfa335"), new Guid("bf974281-f393-4075-b632-3c4279bbaa1d"), new Guid("87441425-7c40-433d-9561-c228e0e59d5a") },
                    { new Guid("6532b3e9-a048-4483-b8e3-168e1a247d8b"), new Guid("8ed12283-e83a-47c4-b8eb-1065da1a9ecb"), new Guid("58413ad9-2faf-4f69-8aa2-8a830d50de14") },
                    { new Guid("d586c189-6e5f-4f3b-9d63-bc677033bba9"), new Guid("7330b2c6-e199-4419-abf6-ea781a461eda"), new Guid("4dcabcc3-f34f-48c8-b037-021b2f4993cb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblGame_CurrentTurnUserId",
                table: "tblGame",
                column: "CurrentTurnUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameLog_GameId",
                table: "tblGameLog",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPlayer_GameId",
                table: "tblPlayer",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPlayer_UserId",
                table: "tblPlayer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPlayerCard_CardId",
                table: "tblPlayerCard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPlayerCard_PlayerId",
                table: "tblPlayerCard",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblGameLog");

            migrationBuilder.DropTable(
                name: "tblPlayerCard");

            migrationBuilder.DropTable(
                name: "tblCard");

            migrationBuilder.DropTable(
                name: "tblPlayer");

            migrationBuilder.DropTable(
                name: "tblGame");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
