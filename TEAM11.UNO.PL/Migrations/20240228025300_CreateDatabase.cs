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
                    { new Guid("00d35880-c512-4678-95a5-3b63cbbb7ff1"), "Red", "R4", "Number" },
                    { new Guid("0315628b-e551-43d8-9290-f40cd711024f"), "Yellow", "Reverse", "Action" },
                    { new Guid("068e1ab8-567d-48e6-bb8c-61fb81ebcf54"), "Green", "G9", "Number" },
                    { new Guid("0cd2d42d-5d73-466b-bd37-7bbce4382bfb"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("0dd55f99-fade-468f-9e5a-74b1c46aec73"), "Yellow", "Y8", "Number" },
                    { new Guid("0fea493e-5670-49bb-bc0f-9d7d2f41483b"), "Blue", "Skip", "Action" },
                    { new Guid("13770f24-d954-4a74-9153-5f035d533282"), "Red", "R8", "Number" },
                    { new Guid("15bb66ff-01f8-415a-a560-8d5e55bab93f"), "Yellow", "Y3", "Number" },
                    { new Guid("179b5841-9b5e-4c9c-ad14-d71ec89c62f8"), "Green", "G6", "Number" },
                    { new Guid("227533e4-3178-44b5-bde2-9e132c12e3fa"), "Red", "Skip", "Action" },
                    { new Guid("231da35a-f1ff-4542-9d28-07e3721d4318"), "Blue", "B0", "Number" },
                    { new Guid("23fc303f-d48c-4eab-abfa-111a5a096b91"), "Blue", "B4", "Number" },
                    { new Guid("2a70ca95-4647-48a0-9d3d-047fc4ef4b0e"), "Green", "Reverse", "Action" },
                    { new Guid("3a740208-00b8-4a3b-bca5-2abdef34cf57"), "Green", "G0", "Number" },
                    { new Guid("4970edd2-e40d-4492-ae05-fb201aa3bb48"), "Blue", "B7", "Number" },
                    { new Guid("512d15eb-a55c-4b2d-a675-e7715d54a6f4"), "Red", "Reverse", "Action" },
                    { new Guid("52ba90cd-c065-43de-b5f7-f77d7fbb1799"), "Blue", "B2", "Number" },
                    { new Guid("55297fb7-bef4-4077-b93e-4e506c18667b"), "Blue", "Reverse", "Action" },
                    { new Guid("5cc34d20-9686-4675-b71b-a14a3c6333f8"), "Red", "R3", "Number" },
                    { new Guid("5e1db2c6-ef61-4402-aeaa-d9901acab4f0"), "Blue", "B8", "Number" },
                    { new Guid("66eb5bd9-57c9-4bc5-859e-483e518a1ea6"), "Red", "R5", "Number" },
                    { new Guid("67383112-7d91-46bd-a3f0-a3a0cd9800d6"), "Green", "G2", "Number" },
                    { new Guid("6aefab1b-78cf-436f-a924-6ae5547718fe"), "Wild", "Wild", "Wild" },
                    { new Guid("6c9c67d1-3a3b-4b14-9f00-cfe42894f2a8"), "Red", "DrawTwo", "Action" },
                    { new Guid("7ab3377c-f96b-4c0c-a4d4-093b4b355432"), "Blue", "B9", "Number" },
                    { new Guid("8d2fed3f-2201-4bcc-bc58-499298713cf4"), "Green", "G4", "Number" },
                    { new Guid("9cd58f09-ee28-4376-9f9f-d82e335b69fc"), "Green", "Skip", "Action" },
                    { new Guid("9f64e441-0ba0-4eb5-9790-fb129794ad99"), "Yellow", "Y1", "Number" },
                    { new Guid("a28f90d9-f965-4746-9373-147775c37505"), "Yellow", "Y4", "Number" },
                    { new Guid("a85f7a09-bd26-4f2a-bcf5-73808ca49b61"), "Red", "R6", "Number" },
                    { new Guid("adde9a4e-28e8-42e7-8cd8-c214bd4e320e"), "Yellow", "Y6", "Number" },
                    { new Guid("aea48f55-4bed-49e8-b876-33c2604a8430"), "Yellow", "Y2", "Number" },
                    { new Guid("b0942364-aa60-4af7-8e5a-b7fca02a47e8"), "Blue", "B5", "Number" },
                    { new Guid("b567aff9-7f18-4944-8e04-6a5ba2ffada4"), "Green", "DrawTwo", "Action" },
                    { new Guid("ba7b21ba-825b-4b08-bb8a-0ea2f5edeb4b"), "Green", "G8", "Number" },
                    { new Guid("c0fd2a04-48ab-42fc-b0ab-572bca6fb767"), "Green", "G5", "Number" },
                    { new Guid("c35f0866-97ac-4952-ab66-ccf011cc4c8b"), "Blue", "DrawTwo", "Action" },
                    { new Guid("c46ff354-bfd3-4349-abb5-44da776319a0"), "Yellow", "Y9", "Number" },
                    { new Guid("c4819857-623c-4533-aefd-bb4e959a7468"), "Yellow", "Skip", "Action" },
                    { new Guid("c9744766-8c73-424b-b1e5-bef0a6cee51e"), "Yellow", "Y0", "Number" },
                    { new Guid("ca96c588-4b15-40f5-be92-6b3f77b54834"), "Blue", "B1", "Number" },
                    { new Guid("d21d14c6-ee1d-4aa4-9c0e-2ab2bb2713e2"), "Green", "G3", "Number" },
                    { new Guid("d90b4254-6bbb-4e87-baf2-92df7c1c295f"), "Blue", "B6", "Number" },
                    { new Guid("da49f459-c9d1-40ee-9d7a-5801bc8f3c17"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("deaca2e7-9a92-43c6-a4e5-f4153d045697"), "Red", "R7", "Number" },
                    { new Guid("df111b79-c081-49e9-ae6f-7835bc1e399f"), "Red", "R1", "Number" },
                    { new Guid("e0385216-8eb6-4486-827e-e87bf90b564c"), "Yellow", "Y5", "Number" },
                    { new Guid("e04ed4d6-135d-497a-9d43-5611a76e674f"), "Red", "R2", "Number" },
                    { new Guid("e762b005-88fe-4585-8798-fea1939c45f0"), "Green", "G7", "Number" },
                    { new Guid("eb2c9634-c202-4d16-bd6e-56b7159e440a"), "Red", "R0", "Number" },
                    { new Guid("f1946e04-03d1-4fc0-b45d-cf434eadf18b"), "Yellow", "Y7", "Number" },
                    { new Guid("f3e48aaa-0dfa-4be3-adb1-028ea63cc37f"), "Blue", "B3", "Number" },
                    { new Guid("f70b0dbf-815c-45ee-9168-fc851147b552"), "Green", "G1", "Number" },
                    { new Guid("fe885958-9a1c-4343-ac3f-495acffff3fb"), "Red", "R9", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "CurrentTurnUserId", "IsPaused", "Name" },
                values: new object[,]
                {
                    { new Guid("2a7e2c5c-f56f-473e-9f7f-971e941bef56"), new Guid("8935e450-d982-4e2a-931f-2c45c4deed5a"), true, "Game 3" },
                    { new Guid("7ab98732-4e76-48e0-b318-be1cfc7dbec1"), new Guid("b27a1e23-ace2-43ea-b9a3-e2468038715c"), true, "Game 2" },
                    { new Guid("80aa3513-a6c1-4d5b-9503-a7b93f4f1722"), new Guid("82e4827e-2be9-415c-b566-34326193bd94"), true, "Game 1" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("18069ff5-26d7-48a8-ab5f-148b3d2a6938"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" },
                    { new Guid("4d32d551-416b-41f3-8595-d7289673d0c4"), "Bot", "Bot", "OjGS4nkcV4YYDQImS16TRUBa+n0=", "Bot" },
                    { new Guid("842e1180-cd5d-46e0-bd4e-cd0944a82fa2"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" },
                    { new Guid("dec08658-00c3-414a-b2dc-e583582f981b"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("4694f18d-1737-4c6c-bd6f-060cdaca9c15"), "Game 2 Log", new Guid("7ab98732-4e76-48e0-b318-be1cfc7dbec1"), "1:00pm" },
                    { new Guid("7db0068e-e511-4472-97a1-190ead14cfa7"), "Game 1 Log", new Guid("80aa3513-a6c1-4d5b-9503-a7b93f4f1722"), "12:00pm" },
                    { new Guid("ebbd152a-cea3-49b2-8018-18f9f2b20f29"), "Game 3 Log", new Guid("2a7e2c5c-f56f-473e-9f7f-971e941bef56"), "2:00pm" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[] { new Guid("176a7e96-ad2b-4a25-9f60-7f427a64329a"), new Guid("80aa3513-a6c1-4d5b-9503-a7b93f4f1722"), new Guid("417658d1-6f0a-4e62-9626-0e134175d335") });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("d140daf6-525f-4369-998c-7f9a1eb05115"), new Guid("5cc34d20-9686-4675-b71b-a14a3c6333f8"), new Guid("45b3906f-d48c-408f-be8f-8fa77adbe06d") },
                    { new Guid("ee2adb4f-4907-45c1-b26b-ba76b146b75d"), new Guid("df111b79-c081-49e9-ae6f-7835bc1e399f"), new Guid("c490eb37-b2c7-4891-af40-8eff38f21b98") },
                    { new Guid("fa03c33c-3907-41d0-a307-782dcbc8aba2"), new Guid("e04ed4d6-135d-497a-9d43-5611a76e674f"), new Guid("9ccf76ce-89eb-4756-8087-6d6305e3db42") },
                    { new Guid("b4d50d1e-cf6f-4ff9-8b82-6f3c0f0cec11"), new Guid("eb2c9634-c202-4d16-bd6e-56b7159e440a"), new Guid("176a7e96-ad2b-4a25-9f60-7f427a64329a") }
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
