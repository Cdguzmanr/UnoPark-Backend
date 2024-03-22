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
                    { new Guid("0a0bf98d-1f37-439e-a7fb-a8e2482b4568"), "Red", "R1", "Number" },
                    { new Guid("0e52da78-6e55-4fd6-bbc1-34832f366ac5"), "Yellow", "Skip", "Action" },
                    { new Guid("0fdc95be-659e-47ed-8ced-0151868cd0c8"), "Red", "R9", "Number" },
                    { new Guid("1001a5f1-fdb0-4a5f-8050-158c76afea8d"), "Red", "R5", "Number" },
                    { new Guid("105e3dfa-9d95-4b8f-8af9-2aa31591031d"), "Blue", "B1", "Number" },
                    { new Guid("335a9c12-62f8-4dbc-93c8-3357ed1ec3ff"), "Yellow", "DrawTwo", "Action" },
                    { new Guid("346163c0-5f73-44dd-b8d8-4ae2a1e2e855"), "Green", "G3", "Number" },
                    { new Guid("39116ec2-7044-40f0-ba52-5e36a48fc7cd"), "Blue", "B8", "Number" },
                    { new Guid("3a8598c0-6af6-431f-969c-454ef9ca3d93"), "Blue", "Reverse", "Action" },
                    { new Guid("3b68e4a0-8d3f-410e-867e-d6fa2fb4dcda"), "Blue", "B7", "Number" },
                    { new Guid("42240731-b5a3-44cd-a60e-5b52cc8d9379"), "Blue", "Skip", "Action" },
                    { new Guid("4ecfa821-705f-4e74-a1e3-775251352877"), "Yellow", "Y9", "Number" },
                    { new Guid("4eeb491a-c832-45a4-912c-6fa8e64e2489"), "Blue", "B4", "Number" },
                    { new Guid("5cc3d870-ee43-4068-b22a-ee13a293df97"), "Red", "R3", "Number" },
                    { new Guid("621233ac-94ae-4d9c-9cd6-a858416094bd"), "Red", "R2", "Number" },
                    { new Guid("67c6efad-34a0-4e95-acc5-b816b81437c8"), "Red", "R8", "Number" },
                    { new Guid("69a8fdeb-d225-4145-8201-935604b1c0f5"), "Red", "DrawTwo", "Action" },
                    { new Guid("7696f5a6-eacb-42a6-83ab-e7ea60991a08"), "Green", "G7", "Number" },
                    { new Guid("80d586d0-bce8-4844-8fe4-70a882d4b07e"), "Red", "R0", "Number" },
                    { new Guid("8110c0f3-8791-4c41-b071-d6a16faca9d8"), "Red", "Reverse", "Action" },
                    { new Guid("827f9491-5a50-4f9e-a350-b5f1d3dae613"), "Green", "G8", "Number" },
                    { new Guid("84b0d102-e799-4c1c-ada6-2aeead702a40"), "Yellow", "Y3", "Number" },
                    { new Guid("85cacf37-0a97-4ca3-b713-6f2b481c680d"), "Wild", "Wild", "Wild" },
                    { new Guid("873f2e60-d074-4bb4-8485-5e1bb7968fe1"), "Blue", "B9", "Number" },
                    { new Guid("878c6a0f-884f-4369-b2bd-45f34695f03d"), "Green", "G4", "Number" },
                    { new Guid("87915ac9-5cbc-445f-a5e1-d6656fec6149"), "Blue", "DrawTwo", "Action" },
                    { new Guid("8abab812-bcf7-4ac4-bd6c-3db71ac1c41a"), "Red", "Skip", "Action" },
                    { new Guid("8d6fcdc0-829d-4907-9e78-fb5d4e033f76"), "Green", "DrawTwo", "Action" },
                    { new Guid("8f25b3cb-053c-4d48-b3eb-8c0f41abdf98"), "Yellow", "Y7", "Number" },
                    { new Guid("95af9d2b-05ed-4157-8c8b-705518ab6f0f"), "Yellow", "Y8", "Number" },
                    { new Guid("9d1a22a5-9ba4-4288-bf22-5b2c7d3a92b0"), "Yellow", "Y0", "Number" },
                    { new Guid("a461e592-9818-4805-8591-48abbc5c663f"), "Red", "R7", "Number" },
                    { new Guid("a8f37f6a-dec0-41c0-ae05-5e12038787e6"), "Red", "R6", "Number" },
                    { new Guid("a970efb5-e266-4f6f-a957-21178c7cc3c3"), "Green", "G0", "Number" },
                    { new Guid("b019c066-eb18-4cee-8277-88820cfc4006"), "Blue", "B2", "Number" },
                    { new Guid("bf8781a4-0bcc-454d-863b-9241c7901dab"), "Yellow", "Reverse", "Action" },
                    { new Guid("c8b4b27d-3672-40d3-82f3-e0048b4d14a5"), "Blue", "B3", "Number" },
                    { new Guid("c90504a1-40b7-4647-a6fd-89b3c223e15a"), "Yellow", "Y1", "Number" },
                    { new Guid("cb95f7d5-410a-4f93-9b05-1ebbf7336d9a"), "Green", "G6", "Number" },
                    { new Guid("ce14a598-029d-4c38-9113-4993f9a97c83"), "Green", "G1", "Number" },
                    { new Guid("ce15d37b-f01d-4a72-9d17-aa49e6d0ce84"), "Blue", "B0", "Number" },
                    { new Guid("d1efef89-e77d-4911-8515-1eb939e193a8"), "Yellow", "Y5", "Number" },
                    { new Guid("d6727c5e-1771-4206-a80a-ad437e3aee0f"), "Green", "G2", "Number" },
                    { new Guid("db6e6807-9a8f-40fe-a0d6-0f81e7708733"), "Red", "R4", "Number" },
                    { new Guid("e3911b1c-55fc-4c46-86e3-5844d56d1737"), "Blue", "B6", "Number" },
                    { new Guid("e99c5314-b1c8-4833-a36d-2313fc9dae8a"), "Green", "G5", "Number" },
                    { new Guid("ea8accd5-84f2-4b93-ae5a-bd22855167de"), "Green", "G9", "Number" },
                    { new Guid("f370a50d-3e3e-449c-96eb-23191cfbbafa"), "Green", "Reverse", "Action" },
                    { new Guid("f9998be9-fa00-4283-9e97-4493e52e570e"), "Yellow", "Y6", "Number" },
                    { new Guid("fc377cd5-4746-4943-a5d5-d6c1d4408538"), "Blue", "B5", "Number" },
                    { new Guid("fd772a05-ca7f-4539-bfa3-ddc88c991aca"), "Yellow", "Y2", "Number" },
                    { new Guid("fdf92d0c-daef-4070-975e-fa1d1b0b4db8"), "Green", "Skip", "Action" },
                    { new Guid("ff89dcc1-6127-4f58-81f4-326dd139732c"), "Yellow", "Y4", "Number" },
                    { new Guid("fff9789a-7b5e-4cbf-ae09-f73a043206b3"), "Wild", "Wild Draw Four", "Wild" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "CurrentTurnUserId", "IsPaused", "Name", "tblPlayerId", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("5971fc34-6d11-463a-9b91-d01082117323"), new Guid("37436d31-f5fe-419e-bfe2-a1050c6ed2ce"), false, "Test Game 1", null, null },
                    { new Guid("86a735e2-5d90-4e0f-8846-4db798f0adf9"), new Guid("7dabe075-2d31-4532-879e-be086998d436"), false, "Test Game 2", null, null },
                    { new Guid("f3f66fd2-6ea1-4474-9923-1f69190d5564"), new Guid("2a8de7bf-a0c2-4d09-bac9-4fbc522b4bff"), false, "Test Game 3", null, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("2a8de7bf-a0c2-4d09-bac9-4fbc522b4bff"), "Brian", "Foote", "dcRQw/ljvvuRLuefC2PlY2UngPA=", "Brian" },
                    { new Guid("35c9b800-1a23-4f6a-a4ea-90db6a84fa59"), "NPC", "NPC", "8M1CByOq6EARbI7321yvHg3/Ku8=", "NPC" },
                    { new Guid("37436d31-f5fe-419e-bfe2-a1050c6ed2ce"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "Austin" },
                    { new Guid("7dabe075-2d31-4532-879e-be086998d436"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "Carlos" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("01313c0c-3f0c-4ad2-b763-787674671bde"), "Test Game Log 1", new Guid("5971fc34-6d11-463a-9b91-d01082117323"), "Test Stamp 1" },
                    { new Guid("3cbf1794-d7d0-45fc-9f24-be4560006e22"), "Test Game Log 2", new Guid("86a735e2-5d90-4e0f-8846-4db798f0adf9"), "Test Stamp 2" },
                    { new Guid("ebe35040-dd07-402b-ad16-f6f187dd02de"), "Test Game Log 3", new Guid("f3f66fd2-6ea1-4474-9923-1f69190d5564"), "Test Stamp 3" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "IsComputerPlayer", "UserId" },
                values: new object[,]
                {
                    { new Guid("158a0f4a-e308-4417-b459-47a8868d5d72"), new Guid("5971fc34-6d11-463a-9b91-d01082117323"), true, new Guid("35c9b800-1a23-4f6a-a4ea-90db6a84fa59") },
                    { new Guid("183abdac-4c5f-476c-ac7a-9bc7bfadf652"), new Guid("86a735e2-5d90-4e0f-8846-4db798f0adf9"), true, new Guid("35c9b800-1a23-4f6a-a4ea-90db6a84fa59") },
                    { new Guid("23710c28-3420-4016-b0c5-7998a20df35f"), new Guid("f3f66fd2-6ea1-4474-9923-1f69190d5564"), true, new Guid("35c9b800-1a23-4f6a-a4ea-90db6a84fa59") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8e975ffc-73db-43ce-8674-57ec9bec0809"), new Guid("86a735e2-5d90-4e0f-8846-4db798f0adf9"), new Guid("7dabe075-2d31-4532-879e-be086998d436") },
                    { new Guid("b895363f-84ec-4cbb-a623-a5ea04d21372"), new Guid("5971fc34-6d11-463a-9b91-d01082117323"), new Guid("37436d31-f5fe-419e-bfe2-a1050c6ed2ce") },
                    { new Guid("d2953128-01a3-454a-ae8a-b668d126af7e"), new Guid("f3f66fd2-6ea1-4474-9923-1f69190d5564"), new Guid("2a8de7bf-a0c2-4d09-bac9-4fbc522b4bff") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("28708c77-6363-47c7-90c2-5d43ce102cee"), new Guid("0a0bf98d-1f37-439e-a7fb-a8e2482b4568"), new Guid("8e975ffc-73db-43ce-8674-57ec9bec0809") },
                    { new Guid("f11fbe5f-e99c-4c1d-87d3-8b31b68dc2ea"), new Guid("80d586d0-bce8-4844-8fe4-70a882d4b07e"), new Guid("b895363f-84ec-4cbb-a623-a5ea04d21372") },
                    { new Guid("ff089931-a13f-4b80-9bfa-883d473c858c"), new Guid("621233ac-94ae-4d9c-9cd6-a858416094bd"), new Guid("d2953128-01a3-454a-ae8a-b668d126af7e") }
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
