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
                    { new Guid("01b6c29a-4da3-4391-a3ea-ff7384bd9a04"), "Red", "Skip", "Action" },
                    { new Guid("0745cad7-3d11-4e73-9543-00d5edbda252"), "Yellow", "Y8", "Number" },
                    { new Guid("12559925-9194-40cf-8f0c-fa544d3d71ac"), "Yellow", "Y0", "Number" },
                    { new Guid("1314f5f5-9c5e-47ab-8e26-c9ca17612483"), "Blue", "B2", "Number" },
                    { new Guid("13f81e42-f546-4a94-a9b5-486018c3d78b"), "Green", "G5", "Number" },
                    { new Guid("174f50a6-75ee-40a6-b1e6-b50abaafdcc9"), "Yellow", "Y5", "Number" },
                    { new Guid("17e0ff0b-dcd1-4677-9ceb-c3fddea020c6"), "Blue", "Skip", "Action" },
                    { new Guid("1a1a5de9-2719-4189-b9ec-08ba44412429"), "Red", "R1", "Number" },
                    { new Guid("1b4b372f-3cb4-43d7-ad73-b402c524f791"), "Yellow", "Skip", "Action" },
                    { new Guid("242797cf-a2b6-491f-9b05-4df3117fbf95"), "Blue", "B8", "Number" },
                    { new Guid("2503cd32-fc01-4e1f-977b-4a16f65f3050"), "Red", "R9", "Number" },
                    { new Guid("2889092f-d5dd-4c80-870b-17532d8ba6a0"), "Green", "G0", "Number" },
                    { new Guid("31b633f6-a4fa-439b-9979-77203715c695"), "Blue", "B7", "Number" },
                    { new Guid("344e92f3-28b1-4b24-af1a-cf1acd4ad21c"), "Yellow", "Y3", "Number" },
                    { new Guid("44c60e31-1f97-41d8-a70a-f28e03040ea0"), "Green", "G9", "Number" },
                    { new Guid("5540b2a9-8289-438c-a0ec-625ec6716edb"), "Green", "G1", "Number" },
                    { new Guid("592cbd51-3b40-4c6e-a715-382d5d7e3342"), "Yellow", "Y1", "Number" },
                    { new Guid("59ab68d3-7056-4693-8c95-650257c3e38d"), "Red", "R7", "Number" },
                    { new Guid("612cff23-7d0d-4063-becc-2e87afa35e81"), "Red", "R4", "Number" },
                    { new Guid("6874f56e-2ae1-4205-b2b2-043f07323e38"), "Yellow", "Y4", "Number" },
                    { new Guid("789bad19-ce2f-47e5-9692-e3d7a828c549"), "Green", "G8", "Number" },
                    { new Guid("7c1ba5ff-5a54-4700-9296-a7d694685c0b"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("7d67059f-314e-4454-8721-36051cbeb8b5"), "Blue", "B1", "Number" },
                    { new Guid("8046eb04-cf2a-437b-8de2-d4521b00855c"), "Yellow", "Reverse", "Action" },
                    { new Guid("86592130-bb28-4876-80c9-c1ebb8dc0d46"), "Red", "R8", "Number" },
                    { new Guid("86b06265-5f0f-4f4d-8586-d8f1f82d18c2"), "Green", "Skip", "Action" },
                    { new Guid("8bbce6fc-27d6-475a-ac59-50f84da37db8"), "Red", "R2", "Number" },
                    { new Guid("8d27a4d0-3719-4b16-b751-ad25fd45569c"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("9c8476e8-2f74-4d04-94ef-9e32160cc808"), "Blue", "B5", "Number" },
                    { new Guid("9f8836cd-4f84-40b9-a41e-992f63640e13"), "Blue", "B9", "Number" },
                    { new Guid("a7368ad0-3616-4d10-a7f1-e3ac244058b0"), "Blue", "Reverse", "Action" },
                    { new Guid("aaf1318c-eda3-45bf-a7a3-6f0ae5e32da5"), "Yellow", "Y6", "Number" },
                    { new Guid("acc7d658-e072-472b-a9ae-a9acff2c4b98"), "Blue", "B6", "Number" },
                    { new Guid("ae3cbf1b-afbe-4990-a9c1-3abfca4b000c"), "Green", "G2", "Number" },
                    { new Guid("b0061c95-8443-43ac-a6d0-6a74c69941e1"), "Yellow", "Y2", "Number" },
                    { new Guid("b1283884-ebef-4ee2-b443-4751978a1e57"), "Green", "G4", "Number" },
                    { new Guid("b58655e7-2d33-4621-aebc-28b6aea6e70a"), "Red", "R3", "Number" },
                    { new Guid("c3686a8f-0867-4242-ae91-68f33c00cee5"), "Yellow", "Y7", "Number" },
                    { new Guid("c7a2c582-4c6f-4d93-934c-b215e36ee835"), "Blue", "DrawTwo", "Action" },
                    { new Guid("cbe71899-3176-45e3-9dc1-30401d7e1b8c"), "Yellow", "Y9", "Number" },
                    { new Guid("d13ea90f-c8e6-49d9-83cb-fc17e1f1147f"), "Green", "G7", "Number" },
                    { new Guid("e371fef0-ff08-4a69-9020-26322bb56a3b"), "Red", "R6", "Number" },
                    { new Guid("e374b540-7da3-4494-84fc-1bd6fabbe9dd"), "Red", "R5", "Number" },
                    { new Guid("e4cfb20d-cbaa-400c-b81c-bbc8cd636937"), "Red", "R0", "Number" },
                    { new Guid("e52e11c8-a3a7-472b-b20e-5b3afe44c5ef"), "Blue", "B4", "Number" },
                    { new Guid("e6e7e504-4cfa-4dea-a21a-123e96d0fa5b"), "Green", "DrawTwo", "Action" },
                    { new Guid("e7c2705d-14a1-472f-9f24-d0c3c107dd81"), "Green", "Reverse", "Action" },
                    { new Guid("ea87906a-376e-42a1-a2dd-d0e6daa37414"), "Wild", "Wild", "Wild" },
                    { new Guid("ede7e38d-4280-44be-8137-7a421b8b4931"), "Red", "Reverse", "Action" },
                    { new Guid("ef9536d4-963d-4574-8d75-3e73630350ac"), "Red", "DrawTwo", "Action" },
                    { new Guid("f2d9b367-feb4-4796-b3cf-8cfbee17d317"), "Green", "G3", "Number" },
                    { new Guid("f39a5044-6185-487c-a7fb-a2331393fd7e"), "Blue", "B0", "Number" },
                    { new Guid("fb5195ac-9548-42d7-8c96-6206f9d540c5"), "Blue", "B3", "Number" },
                    { new Guid("fcabd3be-f31a-404b-8ba8-a4d33e845d04"), "Green", "G6", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "CurrentTurnUserId", "IsPaused", "Name" },
                values: new object[,]
                {
                    { new Guid("493840d6-297f-491d-9ba7-4e2873f7f2d8"), new Guid("86509782-5c97-4c3a-a323-9e71c31b7c1a"), true, "Game 3" },
                    { new Guid("76782e5f-d778-4372-bc85-1a485c8870cf"), new Guid("cc9042a3-88e0-452c-8c41-7933369d74e2"), true, "Game 2" },
                    { new Guid("c2c000aa-d2d7-48f8-9d25-f2d51698ba1c"), new Guid("97abf067-89b3-4bf9-84e3-22957dd328a2"), true, "Game 1" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("093c9300-9b1a-41c5-9b1a-c7602484e79c"), "Bot", "Bot", "OjGS4nkcV4YYDQImS16TRUBa+n0=", "Bot" },
                    { new Guid("6b7b4763-43a0-4d50-9a17-d8cc7a7aa383"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" },
                    { new Guid("7a382949-07dd-4365-b0c4-e798e9b1a31f"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" },
                    { new Guid("863e81dd-7cdd-48c9-b814-0cc3c339a1e9"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("271f92f9-b58b-4990-95b1-93cf8c3b99f2"), "Game 1 Log", new Guid("c2c000aa-d2d7-48f8-9d25-f2d51698ba1c"), "12:00pm" },
                    { new Guid("45e0672f-867c-4533-8a71-11bdd1718b18"), "Game 3 Log", new Guid("493840d6-297f-491d-9ba7-4e2873f7f2d8"), "2:00pm" },
                    { new Guid("d182307f-5303-403c-af1a-ad0c5350af42"), "Game 2 Log", new Guid("76782e5f-d778-4372-bc85-1a485c8870cf"), "1:00pm" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("71da6c30-3ba0-4888-82f8-60e203ad3213"), new Guid("c2c000aa-d2d7-48f8-9d25-f2d51698ba1c"), new Guid("6b7b4763-43a0-4d50-9a17-d8cc7a7aa383") },
                    { new Guid("a4d3f636-4688-45e2-b7a2-2aa7d1e632b3"), new Guid("493840d6-297f-491d-9ba7-4e2873f7f2d8"), new Guid("6b7b4763-43a0-4d50-9a17-d8cc7a7aa383") },
                    { new Guid("b5143a2a-0933-47f4-b776-d719023ca5ba"), new Guid("76782e5f-d778-4372-bc85-1a485c8870cf"), new Guid("6b7b4763-43a0-4d50-9a17-d8cc7a7aa383") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("34ade6fb-87dd-4d95-ad3b-1256cc6c3cea"), new Guid("b58655e7-2d33-4621-aebc-28b6aea6e70a"), new Guid("5f465ec3-0d6e-422c-8f57-d458bc97c0a1") },
                    { new Guid("6e619d23-0a63-4e91-9797-129214646dd1"), new Guid("e4cfb20d-cbaa-400c-b81c-bbc8cd636937"), new Guid("71da6c30-3ba0-4888-82f8-60e203ad3213") },
                    { new Guid("bbd4a514-5c53-4d48-a101-3c149ed7121d"), new Guid("8bbce6fc-27d6-475a-ac59-50f84da37db8"), new Guid("a4d3f636-4688-45e2-b7a2-2aa7d1e632b3") },
                    { new Guid("fc0ae598-69aa-482a-ae10-555ad316d2fb"), new Guid("1a1a5de9-2719-4189-b9ec-08ba44412429"), new Guid("b5143a2a-0933-47f4-b776-d719023ca5ba") }
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
