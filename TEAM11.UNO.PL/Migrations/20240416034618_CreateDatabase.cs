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
                    CurrentTurnUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    { new Guid("021cf323-e3b9-47c6-bd57-59339eca19c6"), "Blue", "B5", "Number" },
                    { new Guid("04831419-88b0-43ab-9391-65478ffb55e8"), "Red", "R8", "Number" },
                    { new Guid("0c2a09ec-0d0d-45b8-82fc-e546eb0d8179"), "Yellow", "Y3", "Number" },
                    { new Guid("0f7ef2e6-5d7a-4904-ae79-b56f358dbece"), "Blue", "B4", "Number" },
                    { new Guid("10a16a33-5447-4d72-a024-4d40c25d2923"), "Wild", "Wild", "Wild" },
                    { new Guid("11c9e169-f14b-4343-8bcd-281ceb166e99"), "Yellow", "Y4", "Number" },
                    { new Guid("13d23095-660a-4967-817b-2c9f6a0d2355"), "Red", "Reverse", "Action" },
                    { new Guid("19170dc6-207f-47e3-8d3d-39f0bfaae131"), "Green", "G0", "Number" },
                    { new Guid("1d9972eb-642e-44e4-86b0-0ffdd8aaa852"), "Blue", "B7", "Number" },
                    { new Guid("2c3db21e-04eb-4477-9463-ccb9fb9c31a1"), "Green", "G8", "Number" },
                    { new Guid("2c4f3132-ea0c-4f4c-8c26-7f60e4977e98"), "Yellow", "Y0", "Number" },
                    { new Guid("2d49315d-96ea-4c7a-b05a-1f21b22029e5"), "Green", "Skip", "Action" },
                    { new Guid("370714df-7c94-47ae-aa8f-e3abd4a10148"), "Red", "R9", "Number" },
                    { new Guid("3c44d0b5-ed19-4aed-9267-9e09123bde60"), "Yellow", "Skip", "Action" },
                    { new Guid("442b5fa9-7e52-4dc4-bb44-90c9e7e5cac6"), "Yellow", "Y8", "Number" },
                    { new Guid("4fb17afe-ee43-4fc3-9354-015b3c467c67"), "Red", "Skip", "Action" },
                    { new Guid("53ada8ff-22b8-42dc-be4b-a3c798efc023"), "Red", "R1", "Number" },
                    { new Guid("57dcbf6e-85ff-4d23-800c-89cd7b670682"), "Red", "R4", "Number" },
                    { new Guid("58b9bcae-fab6-41db-8e4f-2c4865ec031f"), "Green", "G5", "Number" },
                    { new Guid("64aa1635-d13a-4e29-87c3-9cd5f293d6e9"), "Green", "DrawTwo", "Action" },
                    { new Guid("64d3be1d-553e-41fc-9e5b-c592ff13e162"), "Red", "R3", "Number" },
                    { new Guid("6b582133-9e08-4770-b74c-08974c7f44cd"), "Yellow", "Y1", "Number" },
                    { new Guid("76a3d3a2-4612-486b-82d6-a9b06763d2f5"), "Blue", "B8", "Number" },
                    { new Guid("76ef468d-9fe9-4bc9-a855-b260aaa63d12"), "Blue", "B3", "Number" },
                    { new Guid("7cc127e7-8a28-45d9-b3be-99c6858b6e89"), "Yellow", "Y5", "Number" },
                    { new Guid("80ebbe2d-2db0-459d-9a06-26ad51aac6f4"), "Green", "G3", "Number" },
                    { new Guid("836472b9-68a0-4d99-a12a-25dceaaf8543"), "Blue", "B9", "Number" },
                    { new Guid("841f12b3-8fb0-4fa8-9c3c-8ace98887f9e"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("864a5c3c-64a5-4acb-84b5-e4f839e31fd0"), "Blue", "Skip", "Action" },
                    { new Guid("8739ee4b-8c11-4af3-98a7-9f03ee2934dd"), "Blue", "B0", "Number" },
                    { new Guid("89e7c53c-cc5b-4737-a75a-6b844c7c62c5"), "Green", "G1", "Number" },
                    { new Guid("90c247e4-347e-42f2-b76a-0b42f2ab9bd4"), "Green", "G6", "Number" },
                    { new Guid("943bb375-ff20-4f2a-8069-5948ae261181"), "Red", "R5", "Number" },
                    { new Guid("98dd316c-4c6a-46f1-ad9d-146284bea69e"), "Yellow", "Reverse", "Action" },
                    { new Guid("9f9d0230-193d-4735-8970-ce4865f048cb"), "Red", "R0", "Number" },
                    { new Guid("a5446b93-a580-4769-92bd-640898075abe"), "Green", "G7", "Number" },
                    { new Guid("a5728676-c293-4d5a-8ea5-1f767b7ee16c"), "Green", "G4", "Number" },
                    { new Guid("aff1e2b7-0d81-4884-8bd1-c7dd219a7e46"), "Green", "G2", "Number" },
                    { new Guid("b993d517-e03e-433c-af75-e59e89abfdde"), "Blue", "DrawTwo", "Action" },
                    { new Guid("c5a77811-eb5d-49be-94c4-d4523cc582fc"), "Blue", "B1", "Number" },
                    { new Guid("ca1adeaf-e26d-4deb-972f-9415c9c1abd3"), "Yellow", "Y6", "Number" },
                    { new Guid("ccc97e47-52b9-4d8e-bda0-0c7a720b82a3"), "Red", "R7", "Number" },
                    { new Guid("cda14202-af6d-4a72-ac48-c864f6b17ffc"), "Green", "Reverse", "Action" },
                    { new Guid("dd4e0636-6603-4d73-b1a9-b9f1e2d41025"), "Blue", "Reverse", "Action" },
                    { new Guid("de0950a4-02b6-4ab1-b1a1-0d3de0f2f98d"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("e9595196-4d38-4b6c-9590-45e8d0aae4c8"), "Yellow", "Y2", "Number" },
                    { new Guid("ec298186-f8b4-4552-90bb-dca169f947cd"), "Green", "G9", "Number" },
                    { new Guid("edf0483a-3844-48f8-8f76-503508a98ef2"), "Red", "DrawTwo", "Action" },
                    { new Guid("ef0ae620-71a8-478d-8289-09bd7b5c60af"), "Yellow", "Y7", "Number" },
                    { new Guid("efefd2ba-87a9-4be8-a36f-5da15e4b11fe"), "Red", "R2", "Number" },
                    { new Guid("f426913c-1c47-42b5-8dc0-45286429174f"), "Blue", "B2", "Number" },
                    { new Guid("f4ca0700-da9b-444e-a717-65b019802519"), "Yellow", "Y9", "Number" },
                    { new Guid("f7d1206f-30e1-4ff7-bd01-785eaef313b9"), "Red", "R6", "Number" },
                    { new Guid("f9d3652a-40a9-4f42-a4bc-bd9eacab4a82"), "Blue", "B6", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "CurrentTurnUserId", "IsPaused", "Name", "tblPlayerId", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("21ab6236-252c-4fea-b2ac-4daa49fc13e1"), new Guid("d670c893-a3e7-465b-8ecc-4c53eb6682de"), false, "Test Game 3", null, null },
                    { new Guid("2479c7de-df6c-4e51-bc11-b0dd36de2e0e"), new Guid("e4181791-678c-47b5-a9a5-d1452639b90c"), false, "Test Game 1", null, null },
                    { new Guid("5a81e4c5-3fb4-4651-8f17-e57f016f20e0"), new Guid("07b444b1-4d9e-4b5f-8177-2f8f29c1285c"), false, "Test Game 2", null, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("07b444b1-4d9e-4b5f-8177-2f8f29c1285c"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "cguzman" },
                    { new Guid("48ac6cb5-969d-45e9-b814-3950e1840024"), "NPC", "NPC", "8M1CByOq6EARbI7321yvHg3/Ku8=", "nonplayercharacter" },
                    { new Guid("d670c893-a3e7-465b-8ecc-4c53eb6682de"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "bfoote" },
                    { new Guid("e4181791-678c-47b5-a9a5-d1452639b90c"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "asteffes" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("335bdf3e-7ded-42c4-8cfc-199b47e2081c"), "Test Game Log 1", new Guid("2479c7de-df6c-4e51-bc11-b0dd36de2e0e"), "Test Stamp 1" },
                    { new Guid("6dadc7cb-a048-4161-b52b-9e2a47229589"), "Test Game Log 2", new Guid("5a81e4c5-3fb4-4651-8f17-e57f016f20e0"), "Test Stamp 2" },
                    { new Guid("f88f72e7-3855-4f87-add3-7f0b02e1bab9"), "Test Game Log 3", new Guid("21ab6236-252c-4fea-b2ac-4daa49fc13e1"), "Test Stamp 3" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "IsComputerPlayer", "UserId" },
                values: new object[,]
                {
                    { new Guid("05c6b452-740e-41b0-a2ea-80e28a6d43aa"), new Guid("5a81e4c5-3fb4-4651-8f17-e57f016f20e0"), true, new Guid("48ac6cb5-969d-45e9-b814-3950e1840024") },
                    { new Guid("36f5fe6d-c8cb-4823-b0b5-eb79a5f73410"), new Guid("21ab6236-252c-4fea-b2ac-4daa49fc13e1"), true, new Guid("48ac6cb5-969d-45e9-b814-3950e1840024") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3a327e95-174e-4e9d-b0c9-36661a33824b"), new Guid("2479c7de-df6c-4e51-bc11-b0dd36de2e0e"), new Guid("e4181791-678c-47b5-a9a5-d1452639b90c") },
                    { new Guid("62b9c491-f338-482a-a80d-99e87ea4042b"), new Guid("21ab6236-252c-4fea-b2ac-4daa49fc13e1"), new Guid("d670c893-a3e7-465b-8ecc-4c53eb6682de") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "IsComputerPlayer", "UserId" },
                values: new object[] { new Guid("6f7344fe-5f42-43d5-9acf-df7d488c49d7"), new Guid("2479c7de-df6c-4e51-bc11-b0dd36de2e0e"), true, new Guid("48ac6cb5-969d-45e9-b814-3950e1840024") });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[] { new Guid("9c5e0720-8676-4eb3-acb1-0f9696849846"), new Guid("5a81e4c5-3fb4-4651-8f17-e57f016f20e0"), new Guid("07b444b1-4d9e-4b5f-8177-2f8f29c1285c") });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("6173860b-ff39-47c7-8683-27cfe08ba896"), new Guid("efefd2ba-87a9-4be8-a36f-5da15e4b11fe"), new Guid("62b9c491-f338-482a-a80d-99e87ea4042b") },
                    { new Guid("63476741-dc73-4821-8891-29fa910162f1"), new Guid("9f9d0230-193d-4735-8970-ce4865f048cb"), new Guid("3a327e95-174e-4e9d-b0c9-36661a33824b") },
                    { new Guid("712b97e3-873b-47b7-98f2-9a413a52339f"), new Guid("53ada8ff-22b8-42dc-be4b-a3c798efc023"), new Guid("9c5e0720-8676-4eb3-acb1-0f9696849846") }
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
