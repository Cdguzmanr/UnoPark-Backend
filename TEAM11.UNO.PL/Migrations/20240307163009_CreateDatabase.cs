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
                    { new Guid("084ee47a-3c4c-4c8c-8532-a68a154d026a"), "Green", "Skip", "Action" },
                    { new Guid("11e6b002-4052-4416-91b3-7ca8e69fc1c3"), "Red", "DrawTwo", "Action" },
                    { new Guid("13bf0ce7-b685-4bc8-9fdd-e5f7581497ba"), "Yellow", "Y0", "Number" },
                    { new Guid("16a1797e-69cc-4b03-a6d1-fea4566486b0"), "Blue", "B0", "Number" },
                    { new Guid("1b7337ba-46f1-43bd-9e19-a63020389246"), "Red", "R9", "Number" },
                    { new Guid("262db16d-af53-4c2d-ae2f-3ad7d1243681"), "Red", "R0", "Number" },
                    { new Guid("2868994b-69d8-417f-9a25-ffb2cf1ad9f3"), "Yellow", "Y2", "Number" },
                    { new Guid("2ff0fd18-cc36-4144-9724-b4765448f613"), "Blue", "B9", "Number" },
                    { new Guid("3a5c1d71-b85e-4b29-9f59-b2f0d5ee9eb6"), "Red", "R8", "Number" },
                    { new Guid("3d260ead-36f9-47c7-ab37-f36bab3c802a"), "Blue", "DrawTwo", "Action" },
                    { new Guid("442f394a-809b-4552-b441-db24de1a87ca"), "Yellow", "Y7", "Number" },
                    { new Guid("45f4d942-8489-4a33-8d97-911062d2cb7c"), "Blue", "B6", "Number" },
                    { new Guid("469ef501-12e7-4c8f-9605-9210ca0f1b73"), "Yellow", "Y5", "Number" },
                    { new Guid("471a0e77-3933-4027-8a1b-a889be1a4962"), "Green", "G0", "Number" },
                    { new Guid("47a3f208-15b6-469c-aacf-c16dad8100bc"), "Yellow", "Y3", "Number" },
                    { new Guid("4b3628c1-b48f-4e17-88ad-3d54f66bc797"), "Red", "R6", "Number" },
                    { new Guid("51aee0a1-6ac2-4e64-86bb-515dcfbbbdf4"), "Wild", "Wild", "Wild" },
                    { new Guid("52004eb5-9b07-4998-b631-32227d5bee79"), "Yellow", "Reverse", "Action" },
                    { new Guid("53dd91f5-d302-4890-8c83-e6fde1b6ee3d"), "Yellow", "Y8", "Number" },
                    { new Guid("67146f41-56ee-4915-9298-04fe29019496"), "Yellow", "Y1", "Number" },
                    { new Guid("67682896-d7ec-4967-8cdf-987e771afc07"), "Green", "G2", "Number" },
                    { new Guid("67f12dbb-2c34-43df-bf5e-96a81237c894"), "Green", "Reverse", "Action" },
                    { new Guid("6a316fc4-f677-419f-9dcb-ce363cec0c9e"), "Green", "G9", "Number" },
                    { new Guid("6c718b80-fcc5-4230-803f-bc9d4e61d6a9"), "Blue", "B7", "Number" },
                    { new Guid("6dc1f19d-f118-4934-b3b8-c03636fb3250"), "Red", "Reverse", "Action" },
                    { new Guid("6e856b67-a729-4d2e-9c9f-40d3e3be9a62"), "Blue", "B2", "Number" },
                    { new Guid("6f2129f7-9b85-4057-9e0a-a5c295f023dd"), "Yellow", "Y6", "Number" },
                    { new Guid("752756c7-bc9d-4225-962e-cf7e7b936c2f"), "Blue", "B5", "Number" },
                    { new Guid("76d19ac6-b1d9-4bc0-9dfe-40ac61305dbb"), "Green", "G7", "Number" },
                    { new Guid("7cb465e3-d0f0-4f08-86cb-dc56572dcaa5"), "Red", "Skip", "Action" },
                    { new Guid("819e9a06-c943-48c3-90a1-06942c07eacd"), "Green", "G5", "Number" },
                    { new Guid("82cc29bb-85a9-4488-8643-3c7460ba8346"), "Green", "DrawTwo", "Action" },
                    { new Guid("8958a514-cb64-4c56-aac1-39c8e58f2580"), "Red", "R7", "Number" },
                    { new Guid("8f277115-cc7a-4788-862e-f1cbceced82e"), "Yellow", "Skip", "Action" },
                    { new Guid("94046f74-d212-4fde-a35c-3e1c94d96054"), "Blue", "B1", "Number" },
                    { new Guid("959ebf8d-7f46-432f-8f47-37aeeb91e8f5"), "Red", "R2", "Number" },
                    { new Guid("976b60d7-f8bc-40d4-bdac-bacde7b1ba8e"), "Blue", "B4", "Number" },
                    { new Guid("a12fdbdf-ba30-4374-ba4b-c42a3e618dc9"), "Red", "R4", "Number" },
                    { new Guid("ac29d53f-bf8b-4662-9ab6-92261c94501a"), "Yellow", "Y9", "Number" },
                    { new Guid("adae4ec5-54c3-442a-ab6c-5642578ff295"), "Green", "G3", "Number" },
                    { new Guid("b31b80da-92ee-4799-ab46-7409326a6be0"), "Green", "G8", "Number" },
                    { new Guid("b4b4d06d-4246-4a59-868c-05fb787f2f8d"), "Yellow", "Y4", "Number" },
                    { new Guid("bb19e71a-b963-431e-b6e6-7add5bf69756"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("c997374a-1b77-4d13-aac2-7835f8c06351"), "Green", "G6", "Number" },
                    { new Guid("d8fe45ed-3782-4bbd-979e-ade60be549ba"), "Blue", "B3", "Number" },
                    { new Guid("da579f9c-33a0-4a44-9ac4-15ea122041b3"), "Blue", "Reverse", "Action" },
                    { new Guid("db297066-3397-4cb0-af8a-eaa88d220007"), "Red", "R3", "Number" },
                    { new Guid("e16be3fc-b881-406f-998c-f41ae9ef1ec2"), "Red", "R1", "Number" },
                    { new Guid("ea6191eb-773e-4b31-bf96-a080537d9644"), "Green", "G4", "Number" },
                    { new Guid("ed5ee3af-28ed-4f0c-9a22-8120277cd1c2"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("f11c3a16-6aa6-4658-ba4b-c09eb62cb70e"), "Green", "G1", "Number" },
                    { new Guid("f7684dee-9e19-4824-ab27-b9abf96753b5"), "Red", "R5", "Number" },
                    { new Guid("f9650cde-1e44-4a93-8c99-d4449ffb07a0"), "Blue", "Skip", "Action" },
                    { new Guid("fcd279d2-0ac5-4e0f-8256-8464c27ce191"), "Blue", "B8", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "IsPaused", "Name", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("65e93e29-855c-45d1-91ec-2950397a5f1a"), false, "TestGame3", null },
                    { new Guid("90b95faa-cb23-45a6-a9f2-99935b52fc50"), false, "TestGame2", null },
                    { new Guid("b4df33eb-df78-426d-b655-d7da7f28be9f"), false, "TestGame", null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("2abd9301-31f2-4e4a-b58a-125c14529b2c"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" },
                    { new Guid("aa43fc93-df2b-40c5-a4fd-c97baaf0d86c"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" },
                    { new Guid("bcbcfef3-fbc9-40ea-8d43-9e23cf4b8fff"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("8240d4f6-63b7-45f7-a004-71b0d4da2b24"), "TestGameLog2", new Guid("90b95faa-cb23-45a6-a9f2-99935b52fc50"), "TestStamp2" },
                    { new Guid("9d1cbd8a-6eb5-4fd4-b543-12ec02cef081"), "TestGameLog3", new Guid("65e93e29-855c-45d1-91ec-2950397a5f1a"), "TestStamp3" },
                    { new Guid("c740bf0f-5809-4870-a306-6a61e439fdf1"), "TestGameLog", new Guid("b4df33eb-df78-426d-b655-d7da7f28be9f"), "TestStamp" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2555215f-a31b-466c-bcfb-5f6ce6eca06b"), new Guid("b4df33eb-df78-426d-b655-d7da7f28be9f"), new Guid("aa43fc93-df2b-40c5-a4fd-c97baaf0d86c") },
                    { new Guid("8b88e38f-a92c-4e26-8f5d-aa9533979be9"), new Guid("90b95faa-cb23-45a6-a9f2-99935b52fc50"), new Guid("2abd9301-31f2-4e4a-b58a-125c14529b2c") },
                    { new Guid("d36317c4-c381-43de-8ff7-ed0fa16f384b"), new Guid("65e93e29-855c-45d1-91ec-2950397a5f1a"), new Guid("bcbcfef3-fbc9-40ea-8d43-9e23cf4b8fff") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("2c9ba87b-591a-48b2-be73-7fb5e7fe2aee"), new Guid("e16be3fc-b881-406f-998c-f41ae9ef1ec2"), new Guid("8b88e38f-a92c-4e26-8f5d-aa9533979be9") },
                    { new Guid("ef11076a-8ab6-4bc7-8318-d60e6ceed188"), new Guid("262db16d-af53-4c2d-ae2f-3ad7d1243681"), new Guid("2555215f-a31b-466c-bcfb-5f6ce6eca06b") },
                    { new Guid("fd531db6-e8d5-4d05-9c3a-61a7d24275c8"), new Guid("959ebf8d-7f46-432f-8f47-37aeeb91e8f5"), new Guid("d36317c4-c381-43de-8ff7-ed0fa16f384b") }
                });

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
