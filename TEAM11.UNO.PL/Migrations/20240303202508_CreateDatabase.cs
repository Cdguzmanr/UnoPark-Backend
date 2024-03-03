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
                    { new Guid("077cfaf2-f9bd-4486-9365-7d748d0d9141"), "Green", "G4", "Number" },
                    { new Guid("09fa981c-8937-4ce1-aa8f-28cd5df9d677"), "Blue", "B2", "Number" },
                    { new Guid("0c3c11e1-71b4-48d7-8922-d28899f06812"), "Blue", "B8", "Number" },
                    { new Guid("0f63993b-fa5c-4ae0-83c9-df7dc777e5e2"), "Red", "R5", "Number" },
                    { new Guid("17396ef8-5a15-4e58-9b41-ff9acebd4105"), "Green", "G3", "Number" },
                    { new Guid("1da8d0a2-ba51-4fb6-abdc-a2deb82bda80"), "Blue", "DrawTwo", "Action" },
                    { new Guid("231a7fdd-738b-4d12-99ad-40548338646d"), "Blue", "B4", "Number" },
                    { new Guid("28a5f492-71d3-4a81-9dbe-cd6537adc7bd"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("295e2a45-15b1-452c-8696-f1620d585377"), "Blue", "B1", "Number" },
                    { new Guid("2e7bdcfe-2e5d-40c0-8558-92f65e65cf95"), "Yellow", "Y7", "Number" },
                    { new Guid("2f3ee085-f6fc-4583-b9f8-1d2fb91bbe54"), "Yellow", "Y5", "Number" },
                    { new Guid("305f3547-07ac-4f2b-a26b-eeb6d936c0b1"), "Blue", "B0", "Number" },
                    { new Guid("30a69896-a5c3-47ed-9196-44511dfd8047"), "Yellow", "Skip", "Action" },
                    { new Guid("425d646a-11c7-4ff0-be88-6f8ad3365c0a"), "Red", "Reverse", "Action" },
                    { new Guid("44d84bae-bb8f-4e89-bf7d-1aa5e3c3181b"), "Green", "G7", "Number" },
                    { new Guid("464d9aae-9840-4ea9-bb0b-bdfbeaf11397"), "Blue", "Reverse", "Action" },
                    { new Guid("4b64d36f-48c8-4265-931e-323b697945fd"), "Blue", "B3", "Number" },
                    { new Guid("4d72b1bd-f8b2-407a-8090-76526a035bd6"), "Blue", "B5", "Number" },
                    { new Guid("4d9cee6e-7e27-418f-b234-9dd583b73a58"), "Yellow", "Y1", "Number" },
                    { new Guid("4e968d6a-594b-471c-a24a-e4aba20ee5a9"), "Green", "G5", "Number" },
                    { new Guid("4eeafc68-0e4e-4718-953f-827948e2399a"), "Blue", "B7", "Number" },
                    { new Guid("4f8a4f5b-c847-4ad6-80a4-4d5abb5c8434"), "Yellow", "Y2", "Number" },
                    { new Guid("58b89255-7a1e-4a1f-9590-47317bccc717"), "Yellow", "Reverse", "Action" },
                    { new Guid("5a60d8fc-a7e7-4be3-b2d1-77a9917135f2"), "Green", "Skip", "Action" },
                    { new Guid("5dd0b093-1dec-48bf-add3-b3226710453f"), "Green", "G6", "Number" },
                    { new Guid("697e2ed2-fdf1-4019-b583-eb28ba6bd66f"), "Yellow", "Y9", "Number" },
                    { new Guid("6ba6b6be-e52f-472f-8baa-991a4a75b477"), "Yellow", "Y4", "Number" },
                    { new Guid("762288c0-8d0b-4add-b840-98dfb3180137"), "Red", "R8", "Number" },
                    { new Guid("86132ca1-55d4-45f6-94c8-9900e41760ac"), "Green", "G2", "Number" },
                    { new Guid("8e9da32a-641d-4b31-8a21-2f33f250a28c"), "Green", "G8", "Number" },
                    { new Guid("9301525a-e5d5-4e00-a6e7-cedef990865a"), "Red", "R6", "Number" },
                    { new Guid("97d8fc9e-2501-4df5-913f-338ec6096bf1"), "Yellow", "Y0", "Number" },
                    { new Guid("a092e10b-77f3-47d7-8dd8-50ffec147997"), "Blue", "B6", "Number" },
                    { new Guid("a458f5bf-ee2e-4fb4-a10e-613a3ad67ac3"), "Red", "DrawTwo", "Action" },
                    { new Guid("a46626b0-9bfd-4e2b-afc5-4ca3c6182f14"), "Yellow", "Y3", "Number" },
                    { new Guid("a513a1f4-0667-4d0c-9b0f-3f89f8bfa9f7"), "Red", "R1", "Number" },
                    { new Guid("a72592f9-a2e4-41b8-90fe-f1e3ba262432"), "Blue", "Skip", "Action" },
                    { new Guid("a76e0a9c-5b45-4710-8471-0f68f110e32c"), "Green", "DrawTwo", "Action" },
                    { new Guid("a7f66ffe-cc69-4bc9-a5d5-479adced6b3b"), "Red", "Skip", "Action" },
                    { new Guid("ab6cfadb-5f0a-4553-9356-7a30fb8af703"), "Red", "R7", "Number" },
                    { new Guid("abbd4482-b574-4ae6-be3a-9f7ecd96907e"), "Green", "G9", "Number" },
                    { new Guid("adf5f708-ad29-4ba2-a048-c4e3aa782bea"), "Green", "G1", "Number" },
                    { new Guid("c4662da9-65e7-4ee4-bf2e-fcff24399506"), "Red", "R0", "Number" },
                    { new Guid("c6339a6f-6d05-4934-97eb-22bec6db16bd"), "Yellow", "Y6", "Number" },
                    { new Guid("cb047450-9c52-4a9b-ad0a-88acc3bba478"), "Wild", "Wild", "Wild" },
                    { new Guid("d4117139-7111-47af-a897-e61e7d08e6cb"), "Blue", "B9", "Number" },
                    { new Guid("d5f21607-5c76-412c-bda9-84692581f1e9"), "Red", "R9", "Number" },
                    { new Guid("d700333b-3155-48ab-b0a5-06b76a598485"), "Green", "G0", "Number" },
                    { new Guid("e34054e7-0f71-4572-8853-9e23e07651b7"), "Green", "Reverse", "Action" },
                    { new Guid("e3cadff8-4e18-4d0d-b037-96491009652d"), "Red", "R4", "Number" },
                    { new Guid("f03e44ea-2d75-4612-adaa-e9441e41f2cd"), "Yellow", "Y8", "Number" },
                    { new Guid("f088b868-c878-4283-8213-5478ce322fb6"), "Red", "R2", "Number" },
                    { new Guid("f4f0dabe-8448-461b-befa-3b1e47ee672c"), "Red", "R3", "Number" },
                    { new Guid("f665cec4-d8b2-4269-b218-0327acfb3d3f"), "Yellow", "DrawTwo", "Action" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("0099bf3f-6997-42b4-b5a0-5ff1d1890c71"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" },
                    { new Guid("27ecdd25-8acf-43c2-a271-206b39ed2f03"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" },
                    { new Guid("e73e7c0f-3feb-40bf-b1e1-2297381671d8"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "IsPaused", "Name", "UserId" },
                values: new object[] { new Guid("c1c2ee94-2520-4df0-b57f-83cbcbb2d952"), false, "TestGame", new Guid("0099bf3f-6997-42b4-b5a0-5ff1d1890c71") });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[] { new Guid("7d33dc9c-bd84-4820-a725-6758f353283a"), "TestGameLog", new Guid("c1c2ee94-2520-4df0-b57f-83cbcbb2d952"), "TestStamp" });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[] { new Guid("372ea42d-0a66-439e-a473-029708bba214"), new Guid("c1c2ee94-2520-4df0-b57f-83cbcbb2d952"), new Guid("0099bf3f-6997-42b4-b5a0-5ff1d1890c71") });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[] { new Guid("50fdd604-99f2-4926-a2a7-ad6a112a49d7"), new Guid("c4662da9-65e7-4ee4-bf2e-fcff24399506"), new Guid("372ea42d-0a66-439e-a473-029708bba214") });

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
