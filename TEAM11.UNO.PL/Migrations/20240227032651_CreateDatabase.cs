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
                    IsPaused = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("039e430f-6218-4b7a-b4d4-ccf89e35f2e0"), "Yellow", "Y7", "Number" },
                    { new Guid("09cedbc8-6078-4b74-a593-4e79ce01fc3b"), "Yellow", "Y2", "Number" },
                    { new Guid("09d7e46e-9c9f-4896-81b8-fe8023b12edb"), "Blue", "B3", "Number" },
                    { new Guid("0afef1c4-fa70-45f1-b637-c6588d57c22b"), "Green", "G3", "Number" },
                    { new Guid("0f727c17-06ba-4c56-a83d-57790044c1e6"), "Green", "G2", "Number" },
                    { new Guid("14fede7b-0cad-4b17-95c0-b7ce150fa228"), "Green", "Reverse", "Action" },
                    { new Guid("16635160-17c7-433a-83e8-6668b34b5a31"), "Red", "DrawTwo", "Action" },
                    { new Guid("16e9d7ba-006b-4d8c-bfdc-cb0df6ae5d56"), "Red", "Reverse", "Action" },
                    { new Guid("184de25e-e72e-4425-a20e-dcd714892390"), "Yellow", "Y9", "Number" },
                    { new Guid("1a87130b-c662-417a-8d4c-788567ad619b"), "Blue", "B4", "Number" },
                    { new Guid("1ad6bd64-0f28-4a8f-8490-28cf62f9e750"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("1bdb4c9d-9c70-4b6a-af36-94d641b517a9"), "Yellow", "Y5", "Number" },
                    { new Guid("2a648108-2f87-4ded-be9b-b09200c0bfb0"), "Red", "Skip", "Action" },
                    { new Guid("3199c101-d608-4c70-aa5e-37f64a321bf7"), "Blue", "B5", "Number" },
                    { new Guid("3c92ccf6-1793-41cc-8754-2fcf123241b5"), "Green", "G1", "Number" },
                    { new Guid("3e8c013c-9884-4980-8bd3-b5396a2c6536"), "Green", "G8", "Number" },
                    { new Guid("47e706d2-eaf6-440b-b751-33d717c2e31a"), "Blue", "B6", "Number" },
                    { new Guid("48dbbce9-e630-40dc-b02c-8620cffebf54"), "Wild", "Wild", "Wild" },
                    { new Guid("578e4f52-6ac3-464c-8b6a-a9e6030556fe"), "Red", "R1", "Number" },
                    { new Guid("5c25bcc8-1098-427b-b760-d5bfc6ea0cd3"), "Red", "R5", "Number" },
                    { new Guid("5e6c00e8-c4f1-48d2-8d29-5df2e52c84cc"), "Green", "Skip", "Action" },
                    { new Guid("62a49e36-ba37-4943-b1b8-ace3c5ae705d"), "Blue", "Reverse", "Action" },
                    { new Guid("6ea7b011-475a-482b-8abd-7bd8633086e5"), "Red", "R0", "Number" },
                    { new Guid("7174497e-41cb-42ec-9d90-6a0cebef32fd"), "Yellow", "Y0", "Number" },
                    { new Guid("7740f5e5-af1c-46ff-9dde-3095e18e9d58"), "Blue", "B7", "Number" },
                    { new Guid("7a830362-9736-49da-a00e-674223bc1a47"), "Red", "R9", "Number" },
                    { new Guid("7b413f17-7ecb-4100-9873-66a5d21d3bb5"), "Red", "R7", "Number" },
                    { new Guid("85bc4a5c-2f11-4efe-97f3-4302485db0c5"), "Blue", "DrawTwo", "Action" },
                    { new Guid("85d89e42-358a-4feb-ad11-10096ef3221f"), "Red", "R3", "Number" },
                    { new Guid("86aa2f43-6e84-4ff9-b9c7-3735272449ae"), "Yellow", "Skip", "Action" },
                    { new Guid("88b747f3-5e79-4adc-be01-15d3d0ab27aa"), "Red", "R8", "Number" },
                    { new Guid("9b98d458-e504-40fe-b2fe-04538ada7f0f"), "Yellow", "Y4", "Number" },
                    { new Guid("9bb2cdbc-638b-4718-87bc-e1fcfbe3a270"), "Blue", "B0", "Number" },
                    { new Guid("a39f955c-4c77-43fc-9bc8-b2b09c3e1b10"), "Yellow", "Y6", "Number" },
                    { new Guid("a8cf9083-724b-4864-be12-ab54e2243cdf"), "Yellow", "Y1", "Number" },
                    { new Guid("a98cf121-8c44-4630-ac55-a98ad3f30d86"), "Green", "G5", "Number" },
                    { new Guid("a9d1451b-e3c4-470a-8aa9-6ea8073bb191"), "Green", "G0", "Number" },
                    { new Guid("cacc6cb5-29a9-4bd9-8ef5-c672e628b577"), "Blue", "B1", "Number" },
                    { new Guid("cc532621-820c-450c-9da0-b286e621d476"), "Blue", "B2", "Number" },
                    { new Guid("cc681382-9aa2-4896-a67d-c8fde0e402c8"), "Green", "G4", "Number" },
                    { new Guid("da583c0c-003c-4a9a-85db-a616fb4b77f7"), "Red", "R6", "Number" },
                    { new Guid("db2092cc-76c1-4361-94d3-3e6281b95009"), "Red", "R2", "Number" },
                    { new Guid("db5fa18a-bbd0-4dd7-a566-3a465839eaee"), "Green", "DrawTwo", "Action" },
                    { new Guid("de0f9384-2a8c-4362-97d7-b2fcfe8f9ac1"), "Blue", "B9", "Number" },
                    { new Guid("df89b4c6-522a-4331-9e5d-eaeea3781242"), "Green", "G9", "Number" },
                    { new Guid("e002ef75-3af7-4aae-9dd1-8a7428344c3e"), "Yellow", "Y3", "Number" },
                    { new Guid("e0e4855f-f2e9-4d95-8bad-f3d6ee89254b"), "Yellow", "Reverse", "Action" },
                    { new Guid("e1871e2f-8ba9-44ea-8080-c073a0e71c3a"), "Blue", "Skip", "Action" },
                    { new Guid("f00810e9-7c67-481e-ace6-d81c7170c6b1"), "Yellow", "Y8", "Number" },
                    { new Guid("f0996e59-cc22-4fc7-9ced-3ba9b753fcbb"), "Green", "G7", "Number" },
                    { new Guid("f2a4801a-a5c9-40d0-bed1-1ee11e23cbe7"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("f6362289-b5b7-4231-81d3-155f0dd380d9"), "Red", "R4", "Number" },
                    { new Guid("fd874b18-f395-4815-b9e5-3f5d7287eff0"), "Green", "G6", "Number" },
                    { new Guid("fe5231f0-c6c9-493b-8151-57654cb75dbf"), "Blue", "B8", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "IsPaused", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("08ce4503-c094-4142-b810-eb63d3122f88"), true, "Game 1", new Guid("d7059aae-7259-41a6-8c93-cbb95beb0cbc") },
                    { new Guid("425328a8-6237-46b2-b188-e737d5b99edb"), true, "Game 3", new Guid("99932bc6-9167-4b11-9b12-57e3493bf385") },
                    { new Guid("a39d5161-0d17-499d-9cc3-3307ce1e26eb"), true, "Game 2", new Guid("6ccf0a27-06eb-4ba8-a9de-4d70b6793425") }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("31bf8e51-855b-44e0-8038-728e080a5f56"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" },
                    { new Guid("6ddda626-1da0-435d-88c4-b19b3b10d1ed"), "Bot", "Bot", "OjGS4nkcV4YYDQImS16TRUBa+n0=", "Bot" },
                    { new Guid("71a95b24-b212-4f9b-8a18-e546f9cea4bc"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" },
                    { new Guid("c08001ea-66a0-47dc-8d5a-8c84a8b0cc58"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("019d2138-2146-41c6-a266-f0f14ee57f13"), "Game 1 Log", new Guid("08ce4503-c094-4142-b810-eb63d3122f88"), "12:00pm" },
                    { new Guid("885b37b6-bae0-4ba3-8ae5-be0c64f0cb8f"), "Game 3 Log", new Guid("425328a8-6237-46b2-b188-e737d5b99edb"), "2:00pm" },
                    { new Guid("d4be755d-7c6a-4d64-8fd8-b0cdf5af6442"), "Game 2 Log", new Guid("a39d5161-0d17-499d-9cc3-3307ce1e26eb"), "1:00pm" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[] { new Guid("05e3fee9-10b0-43b0-94f7-b565b1ae8e9d"), new Guid("08ce4503-c094-4142-b810-eb63d3122f88"), new Guid("d7059aae-7259-41a6-8c93-cbb95beb0cbc") });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("0af356be-7f26-41d2-b7d4-d2fb906bb49a"), new Guid("db2092cc-76c1-4361-94d3-3e6281b95009"), new Guid("4e7cca10-751e-4de4-a527-c115a5703ffa") },
                    { new Guid("175274cd-825a-4ace-a1db-72682cc83cb7"), new Guid("578e4f52-6ac3-464c-8b6a-a9e6030556fe"), new Guid("e699a7b1-51eb-4652-afa2-645cc1a22669") },
                    { new Guid("276c76b2-85ef-44ac-b55f-f40810a31841"), new Guid("85d89e42-358a-4feb-ad11-10096ef3221f"), new Guid("2ff9f337-6070-4081-a71d-ccc8078398f0") },
                    { new Guid("c481c75c-8f24-4251-bbd5-aa423ef2e632"), new Guid("6ea7b011-475a-482b-8abd-7bd8633086e5"), new Guid("05e3fee9-10b0-43b0-94f7-b565b1ae8e9d") }
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
