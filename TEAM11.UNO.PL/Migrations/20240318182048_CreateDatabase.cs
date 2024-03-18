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
                    tblPlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tblUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGame_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblGame_tblUser_tblUserId",
                        column: x => x.tblUserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
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
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("005be997-3f9e-417c-87dd-53eba21b128e"), "Red", "R3", "Number" },
                    { new Guid("00a9fa99-83b0-4f7b-823e-18db4eb6b6fc"), "Red", "Skip", "Action" },
                    { new Guid("01f31309-f207-462e-a6e7-f61f929a22d1"), "Green", "G5", "Number" },
                    { new Guid("04e60b05-fd4d-423b-9c3b-23ed3343b4fe"), "Green", "Skip", "Action" },
                    { new Guid("06951e5a-ac87-4184-a5f3-e003eaae4814"), "Blue", "B9", "Number" },
                    { new Guid("07035940-3b7d-4180-af9e-e93d03da6514"), "Blue", "B3", "Number" },
                    { new Guid("0b9fa0d5-b8e2-41f3-b4c3-3dcef6f7b224"), "Yellow", "Y0", "Number" },
                    { new Guid("0ee3a9af-656b-4223-b483-143629d3e02e"), "Red", "R9", "Number" },
                    { new Guid("0ef5b1b6-1b58-4b19-93bc-a65e8643ea39"), "Blue", "B0", "Number" },
                    { new Guid("1786faca-dd4f-454a-9fb5-a66f22d5af3b"), "Wild", "Wild", "Wild" },
                    { new Guid("189e3669-55dd-49f1-8741-f814b853083c"), "Red", "R7", "Number" },
                    { new Guid("18fd16eb-426b-42a6-af46-9238e16005db"), "Green", "G6", "Number" },
                    { new Guid("1927c2dc-11d0-439c-8e4e-bf4140d4759e"), "Red", "R6", "Number" },
                    { new Guid("1e2ae1f2-0a41-414a-a912-aecb1f6a8bc7"), "Yellow", "Y1", "Number" },
                    { new Guid("243e8140-2c5b-47c7-90da-7dd7ea1f5086"), "Yellow", "Y3", "Number" },
                    { new Guid("25a9371d-5bbe-463e-be39-0b2e4cfb9314"), "Green", "G1", "Number" },
                    { new Guid("2fb21530-d491-4852-8077-ef645cab47da"), "Yellow", "Y7", "Number" },
                    { new Guid("316c9600-6a5b-4434-9515-7bf0d0468ce0"), "Green", "G8", "Number" },
                    { new Guid("317f26e6-e6b1-4498-a5da-4037657252a4"), "Blue", "B6", "Number" },
                    { new Guid("3879e895-5337-4f22-bd6c-ef640630c4c1"), "Red", "R0", "Number" },
                    { new Guid("3bbd7dc3-e8f4-47a7-b0bf-aa05846b58a8"), "Yellow", "Y2", "Number" },
                    { new Guid("3d7f1d2c-a845-4ae4-89ab-b40522131614"), "Yellow", "Reverse", "Action" },
                    { new Guid("4ea58f20-d972-477e-a3cd-86b4cd9a8054"), "Red", "R1", "Number" },
                    { new Guid("5098992f-b19b-4d4e-adef-e974a5f23c7a"), "Red", "Reverse", "Action" },
                    { new Guid("51bd92d7-f459-4a92-8e76-dc208edcd238"), "Yellow", "Y6", "Number" },
                    { new Guid("5cb432e8-ee95-472e-840e-c90d14351248"), "Green", "G4", "Number" },
                    { new Guid("5e2d8d78-99f5-4db2-8504-8c9ab743eab3"), "Red", "R5", "Number" },
                    { new Guid("5f2e8866-2bc8-4185-8b98-79c11811bd37"), "Green", "G9", "Number" },
                    { new Guid("6fcf47eb-c777-4a90-af08-de68033cd498"), "Yellow", "Skip", "Action" },
                    { new Guid("79273477-0e2e-4b41-849f-1db836973d12"), "Green", "G7", "Number" },
                    { new Guid("81acb208-014d-4bfb-8d3a-d2b6655ba17f"), "Blue", "Reverse", "Action" },
                    { new Guid("8356d5b7-0453-4898-b613-f0f317bf0585"), "Red", "R8", "Number" },
                    { new Guid("9400889b-3da9-4dde-9824-8cdc12ada4ce"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("95499411-d3b6-4fef-81e3-5ca67683ba8a"), "Blue", "Skip", "Action" },
                    { new Guid("9faf327b-7ea8-4b7a-8a93-f26e0f8cb4be"), "Yellow", "Y9", "Number" },
                    { new Guid("a4d65fb7-76e9-4a32-9226-a763a0725735"), "Green", "Reverse", "Action" },
                    { new Guid("b1aba15b-9f3a-479c-a72e-21b2b1e1d99a"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("b28ce706-42f1-4f32-b184-541e4f96c928"), "Red", "R2", "Number" },
                    { new Guid("b30f0180-5248-44c0-8305-25026d214ab5"), "Green", "G0", "Number" },
                    { new Guid("bc496d8d-768a-4e25-9ff6-a99461d919b6"), "Green", "DrawTwo", "Action" },
                    { new Guid("bd706ee8-7618-401a-9a24-d2004fdcfcc6"), "Red", "DrawTwo", "Action" },
                    { new Guid("c1d0e3e1-546f-4227-9581-14040f7922d9"), "Blue", "B2", "Number" },
                    { new Guid("c2640988-74a7-4192-8544-61bffdd5db04"), "Blue", "B7", "Number" },
                    { new Guid("d38a2e6f-7968-488d-9911-748523baeba6"), "Blue", "DrawTwo", "Action" },
                    { new Guid("dc298c72-6ba4-4a63-ae29-7026ed95649f"), "Yellow", "Y8", "Number" },
                    { new Guid("ddced8ab-d182-421e-8d2a-2cc2d77d4c92"), "Yellow", "Y5", "Number" },
                    { new Guid("dfd18ed8-cc4d-45c5-93a0-c3811d3bfa5e"), "Blue", "B1", "Number" },
                    { new Guid("e63cf21a-5a64-4ea4-8509-56b9fd058adf"), "Blue", "B8", "Number" },
                    { new Guid("ec8a275b-dfdd-4ec1-9921-8956e9694aff"), "Red", "R4", "Number" },
                    { new Guid("f0ad5c83-1f91-497b-8e52-2f74286c7321"), "Yellow", "Y4", "Number" },
                    { new Guid("f7ad886d-0fbe-40af-9860-a20d57759211"), "Blue", "B5", "Number" },
                    { new Guid("f9c257f9-725d-4173-8feb-d066921fd57e"), "Green", "G2", "Number" },
                    { new Guid("fb8d0e39-a4e8-4c9c-84b3-e9460b6b22c7"), "Blue", "B4", "Number" },
                    { new Guid("fc5b941e-2de1-47df-a67e-5101e44c126b"), "Green", "G3", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "IsPaused", "Name", "tblPlayerId", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("0ed6a3ea-cc17-4f12-8985-9ccbcd62e824"), false, "Test Game 3", null, null },
                    { new Guid("343c4a33-34c0-47e6-8a94-8506b15d2849"), false, "Test Game 2", null, null },
                    { new Guid("8d3caa94-dfdc-4ae0-b18b-f25454b40fb1"), false, "Test Game 1", null, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("0408af3b-2af1-4fa3-bfc9-035a7df913ab"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" },
                    { new Guid("0e029853-c2ee-44ad-be27-8db17b9a9ddf"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" },
                    { new Guid("3e77bbd5-f983-4ccf-a8ee-b04cf08de746"), "NPC", "NPC", "8M1CByOq6EARbI7321yvHg3/Ku8=", "NPC" },
                    { new Guid("8feee8c9-8129-4d7d-9cd0-2218c47b13da"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("a6b05d6f-e4cf-492c-b862-b35b6277b27d"), "Test Game Log 2", new Guid("343c4a33-34c0-47e6-8a94-8506b15d2849"), "Test Stamp 2" },
                    { new Guid("b58bfa3b-2b0d-48ec-9ecd-cb3cb7b78435"), "Test Game Log 3", new Guid("0ed6a3ea-cc17-4f12-8985-9ccbcd62e824"), "Test Stamp 3" },
                    { new Guid("c11472b9-13c5-4df5-893a-46cf4e3901a7"), "Test Game Log 1", new Guid("8d3caa94-dfdc-4ae0-b18b-f25454b40fb1"), "Test Stamp 1" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "IsComputerPlayer", "UserId" },
                values: new object[,]
                {
                    { new Guid("1a876cbc-8fe0-4a5f-980c-65f8a7c2c6f8"), new Guid("0ed6a3ea-cc17-4f12-8985-9ccbcd62e824"), true, new Guid("3e77bbd5-f983-4ccf-a8ee-b04cf08de746") },
                    { new Guid("40d75b96-caab-4cf1-b514-f470883f347a"), new Guid("8d3caa94-dfdc-4ae0-b18b-f25454b40fb1"), true, new Guid("3e77bbd5-f983-4ccf-a8ee-b04cf08de746") },
                    { new Guid("5205c7e6-c7ec-4b43-91fa-f3d817efc9f5"), new Guid("343c4a33-34c0-47e6-8a94-8506b15d2849"), true, new Guid("3e77bbd5-f983-4ccf-a8ee-b04cf08de746") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("70360972-df6f-4730-9511-31d4df683c10"), new Guid("343c4a33-34c0-47e6-8a94-8506b15d2849"), new Guid("0e029853-c2ee-44ad-be27-8db17b9a9ddf") },
                    { new Guid("8a2f6b5f-5418-4995-ac4c-d53cb4c104ff"), new Guid("8d3caa94-dfdc-4ae0-b18b-f25454b40fb1"), new Guid("0408af3b-2af1-4fa3-bfc9-035a7df913ab") },
                    { new Guid("c41496f2-903e-48c4-b0ed-c22da7b4342d"), new Guid("0ed6a3ea-cc17-4f12-8985-9ccbcd62e824"), new Guid("8feee8c9-8129-4d7d-9cd0-2218c47b13da") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("4167a096-97e1-41c6-b898-947ff0559112"), new Guid("4ea58f20-d972-477e-a3cd-86b4cd9a8054"), new Guid("70360972-df6f-4730-9511-31d4df683c10") },
                    { new Guid("4d8e839d-81bd-430f-94c4-068fea1bb46a"), new Guid("b28ce706-42f1-4f32-b184-541e4f96c928"), new Guid("c41496f2-903e-48c4-b0ed-c22da7b4342d") },
                    { new Guid("c79baff2-6031-4a30-beed-0c4c8b7901ee"), new Guid("3879e895-5337-4f22-bd6c-ef640630c4c1"), new Guid("8a2f6b5f-5418-4995-ac4c-d53cb4c104ff") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblGame_tblPlayerId",
                table: "tblGame",
                column: "tblPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGame_tblUserId",
                table: "tblGame",
                column: "tblUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tblGame_tblPlayer_tblPlayerId",
                table: "tblGame",
                column: "tblPlayerId",
                principalTable: "tblPlayer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblGame_tblPlayer_tblPlayerId",
                table: "tblGame");

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
