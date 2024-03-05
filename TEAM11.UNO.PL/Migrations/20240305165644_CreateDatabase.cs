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
                    { new Guid("016324d8-1297-49cf-a86c-243af019fec9"), "Green", "G1", "Number" },
                    { new Guid("029b114b-8fa1-4312-855d-f509caf62c2b"), "Blue", "B1", "Number" },
                    { new Guid("0544c4b9-55f8-41dc-b638-a61f128c2624"), "Wild", "Wild", "Wild" },
                    { new Guid("05cc0ce0-0b74-4758-b052-a3ef9237397a"), "Red", "R4", "Number" },
                    { new Guid("083df5b9-e028-46fd-afe9-0b2de80c8d83"), "Green", "G9", "Number" },
                    { new Guid("0db09282-f734-4c50-b5d6-95965f5c9263"), "Green", "G4", "Number" },
                    { new Guid("100a34bf-e388-419f-80e7-f09d3935bb8a"), "Blue", "B9", "Number" },
                    { new Guid("14f4da50-1567-40bb-ba38-fcddf4b9ebc5"), "Green", "G0", "Number" },
                    { new Guid("18050b40-1924-497f-823b-d18a4c9d5fdb"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("182f41bb-f005-47d5-81e8-6b7f08adc6d6"), "Yellow", "Y8", "Number" },
                    { new Guid("1ab5fdf1-2cbe-4071-85ce-b2ec6d0efced"), "Green", "DrawTwo", "Action" },
                    { new Guid("1d354a47-0284-4ff5-9946-089119b1906f"), "Green", "G2", "Number" },
                    { new Guid("2d9b05f1-ec6d-4d6e-9a4e-b69ffdedf98a"), "Green", "G3", "Number" },
                    { new Guid("2f0a1088-b133-471e-b57f-28a58d74b3e4"), "Yellow", "Y4", "Number" },
                    { new Guid("335edc21-f149-4b5d-92ea-a2da82dfb9d6"), "Yellow", "Y0", "Number" },
                    { new Guid("34246102-df15-47af-9c8d-42a1e67c3415"), "Green", "Reverse", "Action" },
                    { new Guid("3cbdbb79-942c-4798-b15a-ef84996eaba1"), "Green", "G5", "Number" },
                    { new Guid("43c872d1-5a1d-42c3-898d-3f5b7f223a45"), "Red", "R3", "Number" },
                    { new Guid("447ed376-47ea-4c17-960b-27a74873ed2b"), "Yellow", "Y1", "Number" },
                    { new Guid("452e9358-a5f0-48cf-9d75-10d787fa21e9"), "Blue", "B6", "Number" },
                    { new Guid("47ce2299-d617-4b9b-9268-fdd30e550787"), "Blue", "Reverse", "Action" },
                    { new Guid("482c3f0a-c30b-48cb-b083-28c811e06ec2"), "Blue", "B2", "Number" },
                    { new Guid("49858f7a-5c88-445f-ad15-f00ca6ffeeb5"), "Yellow", "Y6", "Number" },
                    { new Guid("52b4d84c-b061-4833-a761-38b0a654e356"), "Yellow", "Reverse", "Action" },
                    { new Guid("539cfa88-1413-424d-bc56-d8b479f76fef"), "Red", "DrawTwo", "Action" },
                    { new Guid("562bbd81-861e-407c-a2ea-eacf38fa142d"), "Red", "R7", "Number" },
                    { new Guid("5cb57450-7a35-42d9-8c2a-f7391446bb14"), "Red", "R8", "Number" },
                    { new Guid("6203b75c-11bf-49f1-a055-e274ca2ab208"), "Yellow", "Skip", "Action" },
                    { new Guid("6847f76f-363f-4639-a95c-4d1b325b0892"), "Yellow", "Y7", "Number" },
                    { new Guid("6bcd5d09-0269-4ee8-9983-e6e8fc5c587a"), "Green", "G7", "Number" },
                    { new Guid("6d35720a-df67-49b5-a4c5-56e7a56bf54d"), "Yellow", "Y9", "Number" },
                    { new Guid("76256d1e-a189-4059-8589-137407e1cf78"), "Red", "Reverse", "Action" },
                    { new Guid("76d91608-0728-4b10-85f9-b2504d62a61a"), "Blue", "B4", "Number" },
                    { new Guid("845cf0cc-7c71-4b66-bade-cbc6f84976b8"), "Yellow", "Y3", "Number" },
                    { new Guid("990886bd-3495-4e1f-a22c-76d001b6bfb1"), "Blue", "DrawTwo", "Action" },
                    { new Guid("9a2e3df2-bf6a-44f4-80d4-4d8dec197a09"), "Green", "G6", "Number" },
                    { new Guid("9f899f28-8f4a-478f-a47f-93c474fc2496"), "Red", "R0", "Number" },
                    { new Guid("a23ca2ae-585f-4f11-b567-12ebbd029e5f"), "Red", "R9", "Number" },
                    { new Guid("b9454e57-0abf-4840-a86c-f0b812a29b32"), "Red", "R5", "Number" },
                    { new Guid("b985a860-4791-42ab-b74a-e54a59aa1adc"), "Yellow", "Y2", "Number" },
                    { new Guid("bb6e31d0-bfb6-4c6a-afc7-23d6f8aee9f1"), "Blue", "Skip", "Action" },
                    { new Guid("bba28299-0320-4341-bc06-cc0fc7191e33"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("c1746a64-d9d4-43cf-a979-b78be1520a7f"), "Blue", "B7", "Number" },
                    { new Guid("c6c32c77-c516-41ae-8c79-4805d2470e8e"), "Red", "R6", "Number" },
                    { new Guid("c7d7e1b4-0a9e-4c80-be3d-5983c7424314"), "Blue", "B0", "Number" },
                    { new Guid("ce174874-a568-4366-b2fa-7118048e18c6"), "Red", "Skip", "Action" },
                    { new Guid("d3f4aa6d-02d2-4c39-9429-8683dd632bef"), "Blue", "B3", "Number" },
                    { new Guid("d4bf07c5-0a84-402c-b0d1-31d5e8b96926"), "Green", "G8", "Number" },
                    { new Guid("d89f8cd6-5ea5-405a-8130-fdc102f3bcd9"), "Blue", "B5", "Number" },
                    { new Guid("dd8aabf9-13b8-480a-b769-3a5a81eb23fd"), "Green", "Skip", "Action" },
                    { new Guid("ef08f33e-b750-489c-a0c7-473ab9ab513b"), "Yellow", "Y5", "Number" },
                    { new Guid("fa46662b-d423-4208-9d21-f1d8dede9847"), "Red", "R2", "Number" },
                    { new Guid("fb5f567f-74c4-440a-84b6-c601c7b871ab"), "Blue", "B8", "Number" },
                    { new Guid("fc0ecf49-7fe8-4859-99bf-fb66e79a9a31"), "Red", "R1", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("93360e10-1e96-4a00-93da-2bbde22319da"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" },
                    { new Guid("a4f16549-5089-4148-a034-9e5d04d27177"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" },
                    { new Guid("f3c14cd4-5a3a-433c-8e43-400ac28c9472"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "IsPaused", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("46024ade-f7ce-48a1-b6da-d991367a8a7c"), false, "TestGame3", new Guid("93360e10-1e96-4a00-93da-2bbde22319da") },
                    { new Guid("836e0cb1-4dad-499d-8d69-04cb10e4ac96"), false, "TestGame", new Guid("f3c14cd4-5a3a-433c-8e43-400ac28c9472") },
                    { new Guid("dc2c2828-573a-4fdb-8567-41ec865225db"), false, "TestGame2", new Guid("a4f16549-5089-4148-a034-9e5d04d27177") }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("188073e6-39f8-4a82-b0d9-ed342916c476"), "TestGameLog", new Guid("836e0cb1-4dad-499d-8d69-04cb10e4ac96"), "TestStamp" },
                    { new Guid("7b8ff93b-a5fd-41bf-81ec-b6eba4afddfb"), "TestGameLog3", new Guid("46024ade-f7ce-48a1-b6da-d991367a8a7c"), "TestStamp3" },
                    { new Guid("83c655fd-910f-4eaf-a706-c827e803f972"), "TestGameLog2", new Guid("dc2c2828-573a-4fdb-8567-41ec865225db"), "TestStamp2" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("018e5dfb-ffe9-4e55-97cd-43156b0ff8a6"), new Guid("836e0cb1-4dad-499d-8d69-04cb10e4ac96"), new Guid("f3c14cd4-5a3a-433c-8e43-400ac28c9472") },
                    { new Guid("0422bce9-201e-4f5f-9c4a-d1aecbd9ea7b"), new Guid("dc2c2828-573a-4fdb-8567-41ec865225db"), new Guid("a4f16549-5089-4148-a034-9e5d04d27177") },
                    { new Guid("a4767da2-f643-4974-ab6f-473d316a206a"), new Guid("46024ade-f7ce-48a1-b6da-d991367a8a7c"), new Guid("93360e10-1e96-4a00-93da-2bbde22319da") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("304a82e3-9e67-4226-856a-baade14978f3"), new Guid("fc0ecf49-7fe8-4859-99bf-fb66e79a9a31"), new Guid("0422bce9-201e-4f5f-9c4a-d1aecbd9ea7b") },
                    { new Guid("5c5ad81f-6b30-4d93-afd9-14c29bfd6dff"), new Guid("9f899f28-8f4a-478f-a47f-93c474fc2496"), new Guid("018e5dfb-ffe9-4e55-97cd-43156b0ff8a6") },
                    { new Guid("de7cf15f-4be8-4809-8e02-536df5837057"), new Guid("fa46662b-d423-4208-9d21-f1d8dede9847"), new Guid("a4767da2-f643-4974-ab6f-473d316a206a") }
                });

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
