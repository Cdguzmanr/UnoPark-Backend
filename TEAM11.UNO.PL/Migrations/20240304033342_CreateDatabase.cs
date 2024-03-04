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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGame_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblGame_UserId",
                        column: x => x.UserId,
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
                    { new Guid("01f6835a-afc2-4ef3-8408-e33de52ab062"), "Green", "G3", "Number" },
                    { new Guid("0373a0fe-4d19-4df3-908c-0d184f9d648f"), "Blue", "Skip", "Action" },
                    { new Guid("0520492e-fe1b-4062-bdd8-2b16f60c773e"), "Yellow", "Y4", "Number" },
                    { new Guid("08471f17-187a-4c13-b88f-393ed362247c"), "Red", "Reverse", "Action" },
                    { new Guid("08faec62-e3c3-41af-b5c3-3fd7ea5aee0f"), "Yellow", "Y7", "Number" },
                    { new Guid("09c6e400-1a82-42da-bb43-cd0e02532432"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("0c43456a-e4ab-4538-a480-80fcfb9d49c1"), "Red", "R0", "Number" },
                    { new Guid("13b2d04d-0cb1-4249-aeb6-d40e73114f83"), "Yellow", "Y9", "Number" },
                    { new Guid("14690546-146d-447d-889b-657b21093386"), "Blue", "B8", "Number" },
                    { new Guid("1c1ff67d-5e0b-4737-8e8b-94b27dc21efe"), "Red", "R1", "Number" },
                    { new Guid("1dff2ee0-2fb0-45f8-9fef-8720bfa04099"), "Red", "R3", "Number" },
                    { new Guid("21af14fc-86e2-42bf-8067-aa513eb08485"), "Red", "Skip", "Action" },
                    { new Guid("2714577a-8c68-4816-9859-096aa956ee87"), "Blue", "B4", "Number" },
                    { new Guid("3111ff79-5d54-459b-8f81-315e5188d602"), "Green", "G2", "Number" },
                    { new Guid("3bb40db4-f105-46b6-acd2-f5a6898d3e81"), "Yellow", "Y3", "Number" },
                    { new Guid("3bd5304f-5776-4c2f-9e5e-b5df8e95300b"), "Red", "R9", "Number" },
                    { new Guid("4bb60c55-7541-4f1b-91ef-2c280a181f53"), "Yellow", "Skip", "Action" },
                    { new Guid("5185c055-14b4-4c68-b9fe-596c4ed6d6c0"), "Red", "R6", "Number" },
                    { new Guid("52636386-9de1-4f89-9777-2841b38698b4"), "Blue", "B9", "Number" },
                    { new Guid("53977ba0-1a3f-41d7-9555-96280d913978"), "Blue", "B1", "Number" },
                    { new Guid("55fa18ae-705b-4a27-8bb0-d2a322db5cb3"), "Green", "G4", "Number" },
                    { new Guid("56511d9a-ae65-4052-b169-dbe4e24f9eca"), "Green", "G9", "Number" },
                    { new Guid("57f0a3b0-cc3e-4f62-80bc-3a89592d4548"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("5d248dd8-e022-434d-be46-071d434ebff4"), "Yellow", "Y1", "Number" },
                    { new Guid("60548d3f-cfcb-477e-9ba4-eca96729c2ff"), "Yellow", "Y5", "Number" },
                    { new Guid("61e666c3-0e83-4a3a-a2df-4e949d898e6c"), "Green", "Skip", "Action" },
                    { new Guid("6242acbc-1a95-4a76-b2e4-3043a023fa8d"), "Green", "Reverse", "Action" },
                    { new Guid("630d6dec-75dd-43f2-be64-2b277cf78e07"), "Blue", "B0", "Number" },
                    { new Guid("63238e89-536d-41ef-be0d-200aec0119a0"), "Red", "R4", "Number" },
                    { new Guid("741730ab-b01e-4678-8989-272177fed461"), "Yellow", "Y2", "Number" },
                    { new Guid("88200667-f2e4-4280-9207-bc79847d72dc"), "Red", "R2", "Number" },
                    { new Guid("8c0011ae-2cfc-4bec-8238-278efe902983"), "Yellow", "Y0", "Number" },
                    { new Guid("8e0d6a27-6c1c-48cf-8072-e00bf3d93502"), "Yellow", "Reverse", "Action" },
                    { new Guid("9af7732a-5aba-4d1d-b34f-68338b5e2033"), "Red", "DrawTwo", "Action" },
                    { new Guid("a060585b-2692-4641-b143-6d9aa5ad2b7e"), "Green", "DrawTwo", "Action" },
                    { new Guid("a53df231-ae5e-4ec6-b872-edea8e6dcee7"), "Red", "R8", "Number" },
                    { new Guid("a5dfbbaa-ca13-4817-953b-280929facfcc"), "Green", "G1", "Number" },
                    { new Guid("b854f9b5-8d9b-477b-a1eb-6e2cfd76c431"), "Yellow", "Y6", "Number" },
                    { new Guid("c1b73c02-06e5-4e22-89c5-024cccd2ca9d"), "Blue", "B6", "Number" },
                    { new Guid("c6a62878-549b-4a81-a61c-3ce8fbd5dbf7"), "Blue", "B2", "Number" },
                    { new Guid("c77327a0-c3ef-4450-ab1a-a6ba5fa61ca8"), "Blue", "Reverse", "Action" },
                    { new Guid("c81bcf76-44e1-4f85-ae3e-c5277aa7d5ab"), "Red", "R7", "Number" },
                    { new Guid("d103ce73-efc2-4e6a-a2d0-e7b7284f852a"), "Green", "G0", "Number" },
                    { new Guid("d744c63c-f3b1-430d-8a12-851b6b49366a"), "Red", "R5", "Number" },
                    { new Guid("dfd3063e-d262-4db7-838f-81f89bbb1af6"), "Green", "G7", "Number" },
                    { new Guid("e09af017-2b55-4976-8993-8ae0a4a359c9"), "Blue", "B5", "Number" },
                    { new Guid("e72e3089-d6a9-47b6-86d0-476f9b05dde9"), "Wild", "Wild", "Wild" },
                    { new Guid("e838bd4d-7830-4d86-84ac-84a0e15370b3"), "Green", "G8", "Number" },
                    { new Guid("e9f7354e-af78-4a8d-8883-a9837dd35606"), "Yellow", "Y8", "Number" },
                    { new Guid("f1f1f9e3-326d-47b8-98ba-2f51a7490673"), "Blue", "B3", "Number" },
                    { new Guid("f420cf3a-d074-4155-b9f8-a30d3e2cf964"), "Green", "G6", "Number" },
                    { new Guid("f82c2fde-df82-4c61-8cbc-aee93cbf71bc"), "Blue", "B7", "Number" },
                    { new Guid("fa410ee7-5427-41e7-996e-0569fbbbb09f"), "Blue", "DrawTwo", "Action" },
                    { new Guid("ffcb27b9-165d-445f-a12e-b85348a5e33e"), "Green", "G5", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("3c2bb05f-3775-4b1f-9732-d44c6664bb5a"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" },
                    { new Guid("9138db9e-9a5c-4615-9646-4921a1d129d4"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" },
                    { new Guid("bf1ca6cc-6aaa-40c9-9ff4-bb92dab8eede"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "IsPaused", "Name", "UserId" },
                values: new object[] { new Guid("a8f6c609-0115-42b9-a063-363f617e5264"), false, "TestGame", new Guid("9138db9e-9a5c-4615-9646-4921a1d129d4") });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[] { new Guid("9cf67242-e6a9-47fd-9a0d-02f448a74ef7"), "TestGameLog", new Guid("a8f6c609-0115-42b9-a063-363f617e5264"), "TestStamp" });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[] { new Guid("efaaa344-8886-409a-aff6-13ec37cca380"), new Guid("a8f6c609-0115-42b9-a063-363f617e5264"), new Guid("9138db9e-9a5c-4615-9646-4921a1d129d4") });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[] { new Guid("a2609044-5448-4495-a87f-a99b859e4ece"), new Guid("0c43456a-e4ab-4538-a480-80fcfb9d49c1"), new Guid("efaaa344-8886-409a-aff6-13ec37cca380") });

            migrationBuilder.CreateIndex(
                name: "IX_tblGame_UserId",
                table: "tblGame",
                column: "UserId");

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
