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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "fk_tblGame_Id",
                        column: x => x.GameId,
                        principalTable: "tblGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tblUser_Id",
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
                    { new Guid("06d8ddbc-892d-40dc-89d0-ebc6c9e619c2"), "Blue", "Skip", "Action" },
                    { new Guid("0c3a6c0c-70d0-41c4-86f7-f737f465d4da"), "Yellow", "Y6", "Number" },
                    { new Guid("0d074144-1008-40b8-b138-5d9ed0acbf30"), "Blue", "B3", "Number" },
                    { new Guid("0fc2d153-d59a-4463-b024-6d4540d8e523"), "Yellow", "Y5", "Number" },
                    { new Guid("13ab9dbc-43fa-4dca-9209-b5e1ff479b81"), "Blue", "B8", "Number" },
                    { new Guid("1b26c5fb-7f77-4b84-be78-7173bb1a3389"), "Yellow", "Y2", "Number" },
                    { new Guid("23290282-633a-4f71-8182-24f8918e58e6"), "Blue", "B9", "Number" },
                    { new Guid("26f1f598-f4d5-4ac4-9420-f7c4d0e0b9d2"), "Red", "R7", "Number" },
                    { new Guid("2f87b0a8-36ee-4f04-9dfd-f9dc153e42bd"), "Yellow", "Y8", "Number" },
                    { new Guid("3120e7fa-e9b0-41b1-9a1f-b752d1c9af8b"), "Red", "Reverse", "Action" },
                    { new Guid("312ba25f-141d-4931-8807-7f4d0656ed2b"), "Yellow", "Skip", "Action" },
                    { new Guid("333ef719-1d89-419f-a281-e3cb355021be"), "Blue", "Reverse", "Action" },
                    { new Guid("3560b463-4dcb-47ba-ae43-fdb3ed45d4d5"), "Yellow", "Reverse", "Action" },
                    { new Guid("38e5c006-9c02-4fb5-87a6-c5a1fb6192c7"), "Red", "DrawTwo", "Action" },
                    { new Guid("39daaf72-e7ca-44c4-8c25-642a55882a71"), "Red", "R0", "Number" },
                    { new Guid("3bbd6e0c-91de-4c34-9b4c-4c41c5d8a425"), "Red", "R5", "Number" },
                    { new Guid("3f04e93a-ad28-4530-8d23-a33728a0fe96"), "Red", "R3", "Number" },
                    { new Guid("44f2ffaf-bfca-41a9-8cf0-6dd1df64b472"), "Red", "R1", "Number" },
                    { new Guid("484616b2-c20a-4ac3-a85c-377941a17853"), "Blue", "B1", "Number" },
                    { new Guid("4aee857f-0bc2-47d0-a5fb-e951769c5702"), "Blue", "B2", "Number" },
                    { new Guid("4b0d2d66-30a2-47b7-a881-b9fa6a2d8cb5"), "Red", "R2", "Number" },
                    { new Guid("4b4308bb-c89d-47d0-9488-1839cfa09d87"), "Blue", "B7", "Number" },
                    { new Guid("4ddb183f-8f97-4591-b324-a74353ca3e32"), "Yellow", "Y9", "Number" },
                    { new Guid("4f90a2dd-da89-4121-a785-da08762bb95a"), "Red", "R4", "Number" },
                    { new Guid("50822bdb-c5d1-46d1-8b29-7397977aee36"), "Green", "DrawTwo", "Action" },
                    { new Guid("633b0239-db28-4a3b-a5bb-35b1e95f42c8"), "Blue", "B4", "Number" },
                    { new Guid("6455e8b2-170a-4d5d-b8de-8177dafdd0f7"), "Red", "Skip", "Action" },
                    { new Guid("666bf31a-60c9-4667-937c-06f78b586fcb"), "Blue", "B5", "Number" },
                    { new Guid("6a95098a-88cb-4431-b7af-b650133fcac6"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("74d8aa4b-7b27-433d-b05d-b2d569350480"), "Blue", "B0", "Number" },
                    { new Guid("766ea8e1-c4cd-46c7-9089-670b9c6a1479"), "Green", "Reverse", "Action" },
                    { new Guid("7718b355-ce98-4619-99b8-baeee863d858"), "Blue", "DrawTwo", "Action" },
                    { new Guid("7892178d-e14c-4057-9c2d-95c116e85653"), "Green", "G9", "Number" },
                    { new Guid("7ace504b-0a95-4fbf-aa38-c93731d7d8e5"), "Green", "Skip", "Action" },
                    { new Guid("85490b6e-39fa-4818-80a9-924f4e803800"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("87e51800-da80-439d-bda4-fb291a7c9f43"), "Green", "G5", "Number" },
                    { new Guid("8a57f82b-99eb-458f-ae20-fd0925b72fb9"), "Green", "G2", "Number" },
                    { new Guid("8aa442dd-cd10-4070-b08c-7e3b05b07227"), "Wild", "Wild", "Wild" },
                    { new Guid("8d334b38-6403-4bc4-a884-5ece07ae9689"), "Yellow", "Y7", "Number" },
                    { new Guid("969b88ed-d6dc-49a1-9f6a-f05906620ddd"), "Green", "G8", "Number" },
                    { new Guid("a2136694-6956-4b2c-b554-af2c648b0de2"), "Green", "G0", "Number" },
                    { new Guid("a32f68d3-7f0f-41b3-a441-e4749b4df7e9"), "Blue", "B6", "Number" },
                    { new Guid("a49648d0-7cd3-474a-a70c-129de3b2595f"), "Yellow", "Y1", "Number" },
                    { new Guid("a58bb66f-906d-42a9-94e1-1e989a1b0cb3"), "Yellow", "Y4", "Number" },
                    { new Guid("b2cf32cc-2333-493b-b3c6-0ac094975643"), "Green", "G6", "Number" },
                    { new Guid("bc098d91-9019-46a7-890e-06efb9ce7a9d"), "Yellow", "Y0", "Number" },
                    { new Guid("c5f656a3-3037-492e-8fe2-d520b5415dcc"), "Green", "G3", "Number" },
                    { new Guid("c98c82d4-3579-4edf-af20-46554c494b9f"), "Red", "R6", "Number" },
                    { new Guid("d274d121-237e-4cc3-9d19-6522428b4521"), "Green", "G4", "Number" },
                    { new Guid("d3f1d2ee-ac37-45dd-8bfa-5113a0e095b0"), "Red", "R8", "Number" },
                    { new Guid("d95ccbac-d823-4812-97c8-900cc1d27650"), "Green", "G7", "Number" },
                    { new Guid("db4933d9-3f4b-4f4d-9ad6-a690238ff0ce"), "Red", "R9", "Number" },
                    { new Guid("e3b9b5e1-1a11-4c3c-9529-b8bcf9de649a"), "Yellow", "Y3", "Number" },
                    { new Guid("eab658f9-c639-4f8f-80b7-5bd89077432c"), "Green", "G1", "Number" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "IsPaused", "Name", "UserId", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("1e8ae97d-6eeb-466d-a66e-855272510d4b"), true, "Game 2", new Guid("0bf39821-f411-4116-8446-9334296c02ff"), null },
                    { new Guid("9b34baa9-0d88-45b8-9c95-f25128f6b750"), true, "Game 1", new Guid("ea151920-35a2-4aa2-a106-b1f1caeec47c"), null },
                    { new Guid("ff81d7ed-ac81-4a82-aa2d-f05ebbaa8842"), true, "Game 3", new Guid("516e98d5-f40a-46cf-8143-0be1f5b24020"), null }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0880134e-3e64-417f-b397-99903cf8afc3"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("0bf39821-f411-4116-8446-9334296c02ff") },
                    { new Guid("8f5f768f-6c4a-4588-b475-36cdd06b1186"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("516e98d5-f40a-46cf-8143-0be1f5b24020") },
                    { new Guid("9fa54f9f-4577-40b4-ac2b-77318994be1e"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("ea151920-35a2-4aa2-a106-b1f1caeec47c") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "IsComputerPlayer", "UserId" },
                values: new object[] { new Guid("b0fc5883-82ad-46de-a01e-e062a96dc09b"), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("86cf474e-fc40-4171-a3ab-a9c821b6ec14") });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("0dde41bc-4260-4524-b1f1-4543fac7fc53"), "Bot", "Bot", "OjGS4nkcV4YYDQImS16TRUBa+n0=", "Bot" },
                    { new Guid("592a79db-625a-407a-a372-d93de366cd6b"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" },
                    { new Guid("92777b4b-6594-4a00-b76c-b3a9eab276c7"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" },
                    { new Guid("c485bf94-5c0f-4b63-8aa5-e8b95649e594"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("2adebf95-50d8-482d-b836-ae28203af14a"), "Game 1 Log", new Guid("9b34baa9-0d88-45b8-9c95-f25128f6b750"), "12:00pm" },
                    { new Guid("3c18c764-4d18-4d5e-8d1f-f2b3abf49e02"), "Game 3 Log", new Guid("ff81d7ed-ac81-4a82-aa2d-f05ebbaa8842"), "2:00pm" },
                    { new Guid("3ce261e5-0ea0-4cf6-b980-fefa4a6b8d74"), "Game 2 Log", new Guid("1e8ae97d-6eeb-466d-a66e-855272510d4b"), "1:00pm" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("1382fddb-1a49-46a0-8d46-a1b6323a8b68"), new Guid("3f04e93a-ad28-4530-8d23-a33728a0fe96"), new Guid("b0fc5883-82ad-46de-a01e-e062a96dc09b") },
                    { new Guid("8f9ca24a-5769-46af-b5bf-8528c0df5097"), new Guid("44f2ffaf-bfca-41a9-8cf0-6dd1df64b472"), new Guid("0880134e-3e64-417f-b397-99903cf8afc3") },
                    { new Guid("acfb29d5-a511-45a6-bfd1-43329a803120"), new Guid("39daaf72-e7ca-44c4-8c25-642a55882a71"), new Guid("9fa54f9f-4577-40b4-ac2b-77318994be1e") },
                    { new Guid("e8707f9f-9d06-4f78-aab7-310026c3bd81"), new Guid("4b0d2d66-30a2-47b7-a881-b9fa6a2d8cb5"), new Guid("8f5f768f-6c4a-4588-b475-36cdd06b1186") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblGame_tblUserId",
                table: "tblGame",
                column: "tblUserId");

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
