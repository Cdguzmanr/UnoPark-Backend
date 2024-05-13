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
                    { new Guid("05d3699a-8f41-43a0-bdb7-cfb9b23d9b38"), "Yellow", "Y3", "Number" },
                    { new Guid("062b1b34-8823-4785-8887-ff8e13db2b3c"), "Green", "Skip", "Action" },
                    { new Guid("072f4caf-d274-4c6e-b310-811545b029e9"), "Blue", "B6", "Number" },
                    { new Guid("09af2719-20fc-4a88-995b-895e78ef9690"), "Green", "G9", "Number" },
                    { new Guid("0e2596ad-85e5-4a06-93f3-f9292b893459"), "Wild", "Wild", "Wild" },
                    { new Guid("0e2e425e-cce8-49db-b2a6-1d8352eec777"), "Blue", "Skip", "Action" },
                    { new Guid("1638a297-a1a4-4835-8ba0-48164d7acc5a"), "Blue", "Reverse", "Action" },
                    { new Guid("16c45792-fd0f-4ae0-a5c7-5269004404ec"), "Blue", "B5", "Number" },
                    { new Guid("184da116-c9f3-4617-b24c-c2b26ccab105"), "Yellow", "Y4", "Number" },
                    { new Guid("1c6071b2-8137-4cf7-96e1-060d04f32e74"), "Red", "R0", "Number" },
                    { new Guid("1e88fe65-9229-4ec4-9d02-ca5d0c0d2572"), "Red", "R7", "Number" },
                    { new Guid("20fc6001-e3fa-462d-88aa-371f24663e15"), "Red", "R2", "Number" },
                    { new Guid("2d4874f6-3b31-400a-9569-2a5fc3b41bb3"), "Blue", "B9", "Number" },
                    { new Guid("31eb931b-3045-4f9b-b9c7-7c455f797b7d"), "Red", "DrawTwo", "Action" },
                    { new Guid("334303ea-3d27-4eb9-9a37-825932225df8"), "Red", "R6", "Number" },
                    { new Guid("47169f68-4a7c-4f02-8212-466d1dee2131"), "Green", "G2", "Number" },
                    { new Guid("4898765b-4e78-4c4e-a181-034827b0f2b2"), "Green", "G7", "Number" },
                    { new Guid("48c3643d-b38a-43d7-aab1-2266447cbdf2"), "Red", "Reverse", "Action" },
                    { new Guid("49df715b-7cc8-4f01-8fab-bd5a311ceb7a"), "Green", "G0", "Number" },
                    { new Guid("51c07159-b8f9-4e46-ae73-8317faddcd7e"), "Green", "DrawTwo", "Action" },
                    { new Guid("55b371c9-9f9a-4b1a-b83c-d9ffc6c01edd"), "Blue", "B3", "Number" },
                    { new Guid("57e2fa00-beae-4065-8cb4-05b557e2fcd1"), "Green", "G5", "Number" },
                    { new Guid("5a645f82-0384-4496-adb6-2955830a20d7"), "Blue", "B8", "Number" },
                    { new Guid("5a7daf0f-7d07-4398-8a37-c7e60ce692e2"), "Yellow", "Y9", "Number" },
                    { new Guid("5c35a711-d8a1-4616-b5a2-84fc7be9b29a"), "Blue", "B7", "Number" },
                    { new Guid("5e561fde-97c8-4c1f-9646-3b5ffb8496b7"), "Green", "G1", "Number" },
                    { new Guid("5ea0c7a6-b31c-4e0f-85d0-9e283307bd0d"), "Yellow", "Y7", "Number" },
                    { new Guid("651931bc-f3fa-4cff-8a75-3a63d977821c"), "Blue", "B0", "Number" },
                    { new Guid("6808bfd6-401a-4890-8328-50873b53e666"), "Yellow", "Y0", "Number" },
                    { new Guid("6b10eb29-32c6-4627-92ac-279c12df93da"), "Yellow", "Y8", "Number" },
                    { new Guid("7d720fb9-4a22-4c0d-ab7d-b34499400112"), "Blue", "B4", "Number" },
                    { new Guid("7de444f6-7145-4942-b5de-fca0f1d4a21e"), "Yellow", "Y2", "Number" },
                    { new Guid("7f980119-4648-4265-b74e-de6a0d25b2e9"), "Red", "R4", "Number" },
                    { new Guid("8029f1a6-2561-48b9-87f2-2a181b96579e"), "Red", "Skip", "Action" },
                    { new Guid("830c7569-7812-4586-843a-dcb12a97d134"), "Red", "R1", "Number" },
                    { new Guid("84f2c7ae-c5f0-4ddf-b000-0bfe57bbe093"), "Green", "G6", "Number" },
                    { new Guid("85f25393-4a8a-458b-ae87-f7c4dfeee654"), "Red", "R8", "Number" },
                    { new Guid("86f3d3ff-17c3-4854-9314-4eaf7e75e3c6"), "Blue", "B1", "Number" },
                    { new Guid("8889dcae-176b-457e-bbe3-ebf411e944eb"), "Yellow", "Y5", "Number" },
                    { new Guid("8a8686e3-a27e-4d76-944b-93b089f495a7"), "Red", "R9", "Number" },
                    { new Guid("8c203074-e3d7-438b-ba93-1e5209cea921"), "Green", "G8", "Number" },
                    { new Guid("8cda56c5-aa62-4098-9983-c5eb22276667"), "Yellow", "Skip", "Action" },
                    { new Guid("8d42fac5-5681-41f6-8b89-7516264b98f2"), "Green", "G3", "Number" },
                    { new Guid("ae819104-2931-4e7e-a1b2-38be4ba7885a"), "Blue", "DrawTwo", "Action" },
                    { new Guid("aedefa41-8f27-43ed-8e51-303b8af819cd"), "Wild", "Wild Draw Four", "Wild" },
                    { new Guid("c60cb107-d39e-42a3-a06a-353ccaf48a0e"), "Red", "R5", "Number" },
                    { new Guid("da13ca91-f2b0-4766-9f7d-bd41663eaafc"), "Red", "R3", "Number" },
                    { new Guid("e25afd1a-c276-43f5-8041-2314fbf9c134"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("e8a94bd3-c038-4d21-b44c-f1d5c73ef3ac"), "Yellow", "Y1", "Number" },
                    { new Guid("e9438018-6a58-46d1-977c-97ed2d57e914"), "Green", "G4", "Number" },
                    { new Guid("f130a0e7-164a-4185-bf5d-f3cfa7597c98"), "Yellow", "Y6", "Number" },
                    { new Guid("f46a62e0-682f-446e-bb2d-0ade00a81417"), "Green", "Reverse", "Action" },
                    { new Guid("f6a88bcb-ccb6-4197-a0fa-a7d3af1df331"), "Blue", "B2", "Number" },
                    { new Guid("fc556912-1a15-4740-8322-835172ffa743"), "Yellow", "Reverse", "Action" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "CurrentTurnUserId", "IsPaused", "Name", "tblPlayerId", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("1d694263-cc41-4e0a-99a8-d1205891a6bf"), new Guid("df51aa84-2bec-490f-8e27-299bbb857ba9"), false, "Test Game 1", null, null },
                    { new Guid("5fc4af13-0da7-4156-a7aa-b29f057ab24c"), new Guid("8397aa00-dcae-4491-b9f7-02f8597efa62"), false, "Test Game 3", null, null },
                    { new Guid("e40a9e7e-9200-490f-b302-0a9a5deaf58e"), new Guid("c1623eb6-3236-4f1c-9ddc-498faa735522"), false, "Test Game 2", null, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("8397aa00-dcae-4491-b9f7-02f8597efa62"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("c1623eb6-3236-4f1c-9ddc-498faa735522"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "cguzman" },
                    { new Guid("ce229f4e-bbf4-4d52-8ca1-3661c2206eee"), "NPC", "NPC", "8M1CByOq6EARbI7321yvHg3/Ku8=", "nonplayercharacter" },
                    { new Guid("df51aa84-2bec-490f-8e27-299bbb857ba9"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "asteffes" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("63b91732-c6d3-42da-bff6-4c9d901154dd"), "Test Game Log 3", new Guid("5fc4af13-0da7-4156-a7aa-b29f057ab24c"), "Test Stamp 3" },
                    { new Guid("9237f48c-4b37-483d-8439-116e1f72346c"), "Test Game Log 1", new Guid("1d694263-cc41-4e0a-99a8-d1205891a6bf"), "Test Stamp 1" },
                    { new Guid("9b3a1fd4-bfff-4cae-9212-c486626d2d85"), "Test Game Log 2", new Guid("e40a9e7e-9200-490f-b302-0a9a5deaf58e"), "Test Stamp 2" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6cb7b232-cbb8-47d0-8b8d-c90db5350811"), new Guid("e40a9e7e-9200-490f-b302-0a9a5deaf58e"), new Guid("c1623eb6-3236-4f1c-9ddc-498faa735522") },
                    { new Guid("6d46efed-9382-4725-8f32-dbeddd052cfe"), new Guid("5fc4af13-0da7-4156-a7aa-b29f057ab24c"), new Guid("8397aa00-dcae-4491-b9f7-02f8597efa62") },
                    { new Guid("a02b94ed-0fad-47f9-a223-d59d647a8508"), new Guid("1d694263-cc41-4e0a-99a8-d1205891a6bf"), new Guid("df51aa84-2bec-490f-8e27-299bbb857ba9") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "IsComputerPlayer", "UserId" },
                values: new object[,]
                {
                    { new Guid("bef75bb1-af68-4cf2-a567-85bc849412eb"), new Guid("1d694263-cc41-4e0a-99a8-d1205891a6bf"), true, new Guid("ce229f4e-bbf4-4d52-8ca1-3661c2206eee") },
                    { new Guid("daa3cbcc-06ed-4297-ba69-82b7afe9a4dd"), new Guid("5fc4af13-0da7-4156-a7aa-b29f057ab24c"), true, new Guid("ce229f4e-bbf4-4d52-8ca1-3661c2206eee") },
                    { new Guid("e9b2a745-31c0-4a6a-873a-126828137048"), new Guid("e40a9e7e-9200-490f-b302-0a9a5deaf58e"), true, new Guid("ce229f4e-bbf4-4d52-8ca1-3661c2206eee") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("2d549111-2916-4ae0-a369-1b72bc331600"), new Guid("1c6071b2-8137-4cf7-96e1-060d04f32e74"), new Guid("a02b94ed-0fad-47f9-a223-d59d647a8508") },
                    { new Guid("7ebc9fc9-4028-4d1a-945c-607d0c384d04"), new Guid("20fc6001-e3fa-462d-88aa-371f24663e15"), new Guid("6d46efed-9382-4725-8f32-dbeddd052cfe") },
                    { new Guid("e231d6a1-f15f-4042-94b5-d86c90bdc05f"), new Guid("830c7569-7812-4586-843a-dcb12a97d134"), new Guid("6cb7b232-cbb8-47d0-8b8d-c90db5350811") }
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
