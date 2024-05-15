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
                    Number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
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
                columns: new[] { "Id", "Color", "Number" },
                values: new object[,]
                {
                    { new Guid("02abfabe-01a5-4f13-918b-39f2bd1728e2"), "Red", "9" },
                    { new Guid("08e52a6a-0111-4094-bd02-1bf224ceb8ed"), "Yellow", "7" },
                    { new Guid("159d76b7-fee2-4c68-bb2b-aeee79dba1ed"), "Green", "4" },
                    { new Guid("175ac394-0c16-4bf6-958e-9e5ddf0239dd"), "Blue", "12" },
                    { new Guid("189ab267-797b-45a8-a278-20ce51ab3bba"), "Yellow", "2" },
                    { new Guid("1bc1f460-6319-4f26-8636-d7a0ecded183"), "Blue", "9" },
                    { new Guid("1c26691f-2e72-4709-a0aa-de85128a6a7e"), "Green", "7" },
                    { new Guid("1e8a13d6-126f-4aa1-9068-286a847b0c7e"), "Green", "8" },
                    { new Guid("1ed46bda-8630-42f5-93ef-0c2119287c28"), "Yellow", "11" },
                    { new Guid("20b9f84d-9ebc-4ed5-b252-b0315361bc3f"), "Blue", "6" },
                    { new Guid("2871b70a-e852-41d7-8d7f-dd48c50971e8"), "Blue", "11" },
                    { new Guid("2f0993c1-686d-47bf-af29-4a24a8521244"), "Red", "8" },
                    { new Guid("303c31a8-4fb1-4634-907c-75deed9eff0d"), "Red", "1" },
                    { new Guid("32fa21fc-6843-4de4-80a7-dfd4b372e0ce"), "Yellow", "12" },
                    { new Guid("3cb95772-b596-4e6b-9385-b8046c9def31"), "Green", "2" },
                    { new Guid("3ef05602-44b9-4235-8e4b-85a39e41dd94"), "Yellow", "8" },
                    { new Guid("46e1c250-a5f2-4659-a6fb-a61b0d0afd77"), "Green", "6" },
                    { new Guid("477b8c1f-3da8-4035-9686-6ee93f9550bb"), "Green", "11" },
                    { new Guid("488f795a-bc90-4e7f-be9f-e2be4ca64296"), "Blue", "4" },
                    { new Guid("48b88363-97b0-4e5d-af5a-0620cdd75c7e"), "Yellow", "9" },
                    { new Guid("491d7a4e-69b9-45ff-bafc-e3ebf4a12091"), "Red", "2" },
                    { new Guid("53c43072-4036-474a-a2a7-eccc80823ab2"), "Red", "10" },
                    { new Guid("5537fc94-bbff-4499-92f6-eda544682214"), "Yellow", "3" },
                    { new Guid("590b72bb-3f17-4647-b110-2e5dfc53605e"), "Red", "14" },
                    { new Guid("697bf154-2b52-4df3-95b5-377ed152dcfb"), "Yellow", "1" },
                    { new Guid("6b3b6281-f8db-4c94-87d4-ae569c02eecf"), "Green", "12" },
                    { new Guid("6f243e17-d822-4785-ae78-39716339f711"), "Blue", "8" },
                    { new Guid("715e5abd-1cb4-415b-9b5c-337146a2b3be"), "Green", "1" },
                    { new Guid("7228d572-28c8-422d-bc32-65f09b7b1e16"), "Red", "5" },
                    { new Guid("7432d29d-52e9-49a0-b7be-472ddc9d78db"), "Blue", "14" },
                    { new Guid("777d18e0-e9d1-4c0a-94c9-58159f6e9b75"), "Red", "4" },
                    { new Guid("7cae4ad7-4c71-41da-b625-3a1928053a73"), "Blue", "13" },
                    { new Guid("7d90a16e-9f88-400f-8eed-d623a8fc6e84"), "Green", "13" },
                    { new Guid("8357bd2e-6aec-4c20-925b-3b65fd072896"), "Blue", "7" },
                    { new Guid("885a1980-7156-4a56-b704-8726f0d5217e"), "Blue", "3" },
                    { new Guid("887cc86d-de4a-4168-b11f-05eec459b198"), "Blue", "10" },
                    { new Guid("8ac2d76a-c62c-4e2e-a74a-1dc18383e464"), "Yellow", "10" },
                    { new Guid("971037f8-2ea9-4a19-a1a7-f20dc91b196e"), "Green", "14" },
                    { new Guid("98a3319a-0804-4253-8dc9-cdd55adf843b"), "Blue", "1" },
                    { new Guid("a32f7fec-5fa8-4b6c-b7d0-111815b21b45"), "Red", "12" },
                    { new Guid("a5e40ff0-e53d-437e-885e-cd128c7bc20e"), "Yellow", "4" },
                    { new Guid("a6343d3a-9f28-48fb-bedf-9a79396e6cce"), "Red", "6" },
                    { new Guid("a7bd6542-8f2b-4028-86cb-24118d8f4402"), "Yellow", "14" },
                    { new Guid("a7d68514-3721-4c11-b4c2-11dfc0b2bcf6"), "Yellow", "5" },
                    { new Guid("a85dbc05-8dac-4017-80b2-1c2bcec4c2be"), "Red", "3" },
                    { new Guid("a907f9f3-22e7-4d13-b8f2-f7ae483771f5"), "Red", "7" },
                    { new Guid("ac8fa47d-de34-47c9-87be-1459a8f5a73e"), "Green", "5" },
                    { new Guid("ba6e91b7-2014-498b-a6d6-091743e301cf"), "Yellow", "13" },
                    { new Guid("baf67263-42ca-4fa2-b5c9-8b4aeee141ef"), "Red", "11" },
                    { new Guid("d8fa86d3-f11f-4511-8698-d999e50b0779"), "Yellow", "6" },
                    { new Guid("de899861-c64d-479e-a9d8-8577b1118a00"), "Green", "10" },
                    { new Guid("df8a4530-1662-4b93-a266-0d0cf8c24653"), "Green", "3" },
                    { new Guid("ea460629-2858-4fba-a615-0fd213a129dc"), "Blue", "5" },
                    { new Guid("ecb7f17d-e005-4e07-bbe1-01f9ba2d3f3a"), "Blue", "2" },
                    { new Guid("f4b23a26-857f-4516-8b4d-c3fc98a33ae7"), "Red", "13" },
                    { new Guid("f67df28d-3460-46f3-ad56-9abbc9a36bdf"), "Green", "9" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "CurrentTurnUserId", "IsPaused", "Name", "tblPlayerId", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("c6f66555-bb9e-4e9a-b96f-ed55344531de"), new Guid("fee30ac8-57e5-4cfc-afb1-2e073a4b72c3"), false, "Test Game 2", null, null },
                    { new Guid("f12d11c4-fefe-4017-aca7-cfb4e5f17112"), new Guid("31ceef29-be9c-49d9-b1f1-dcca91a068ce"), false, "Test Game 3", null, null },
                    { new Guid("fca7b04b-36a6-4778-9461-c6fb9d1e1304"), new Guid("88540449-0c2b-40fc-806a-f8774a5005a3"), false, "Test Game 1", null, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("31ceef29-be9c-49d9-b1f1-dcca91a068ce"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("88540449-0c2b-40fc-806a-f8774a5005a3"), "Austin", "Steffes", "Wwbx8IUDtOY0aSZmfTGPD51+n9E=", "asteffes" },
                    { new Guid("b1f6f715-a942-4468-9633-3ba40c55455c"), "NPC", "NPC", "8M1CByOq6EARbI7321yvHg3/Ku8=", "nonplayercharacter" },
                    { new Guid("fee30ac8-57e5-4cfc-afb1-2e073a4b72c3"), "Carlos", "Guzman", "ZRhJY7TwwZ8UzKABa1uS7MYtnfQ=", "cguzman" }
                });

            migrationBuilder.InsertData(
                table: "tblGameLog",
                columns: new[] { "Id", "Description", "GameId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("18d1c47c-9293-4c8c-a81b-07b1595f4928"), "Test Game Log 1", new Guid("fca7b04b-36a6-4778-9461-c6fb9d1e1304"), "Test Stamp 1" },
                    { new Guid("468e5637-c24b-46ec-97cb-2986e1569dbe"), "Test Game Log 2", new Guid("c6f66555-bb9e-4e9a-b96f-ed55344531de"), "Test Stamp 2" },
                    { new Guid("8aaba0cf-ab94-4fe7-907a-9cb98f2380a4"), "Test Game Log 3", new Guid("f12d11c4-fefe-4017-aca7-cfb4e5f17112"), "Test Stamp 3" }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "IsComputerPlayer", "UserId" },
                values: new object[] { new Guid("25bb2c21-c643-4da5-aaf4-c02f4166a3b7"), new Guid("fca7b04b-36a6-4778-9461-c6fb9d1e1304"), true, new Guid("b1f6f715-a942-4468-9633-3ba40c55455c") });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[] { new Guid("47add45f-1e56-4f10-ba8d-ed61fa6f1d06"), new Guid("f12d11c4-fefe-4017-aca7-cfb4e5f17112"), new Guid("31ceef29-be9c-49d9-b1f1-dcca91a068ce") });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "IsComputerPlayer", "UserId" },
                values: new object[,]
                {
                    { new Guid("77d82ea8-d3fc-4611-9b9e-b4a260c3c326"), new Guid("c6f66555-bb9e-4e9a-b96f-ed55344531de"), true, new Guid("b1f6f715-a942-4468-9633-3ba40c55455c") },
                    { new Guid("c5ce8e11-de07-402b-a4bf-9a25e88c049a"), new Guid("f12d11c4-fefe-4017-aca7-cfb4e5f17112"), true, new Guid("b1f6f715-a942-4468-9633-3ba40c55455c") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cd478a84-7e7d-4bb0-a7e2-71cfd198bd48"), new Guid("fca7b04b-36a6-4778-9461-c6fb9d1e1304"), new Guid("88540449-0c2b-40fc-806a-f8774a5005a3") },
                    { new Guid("fd46511f-39d1-4914-a31b-35a042a99f8d"), new Guid("c6f66555-bb9e-4e9a-b96f-ed55344531de"), new Guid("fee30ac8-57e5-4cfc-afb1-2e073a4b72c3") }
                });

            migrationBuilder.InsertData(
                table: "tblPlayerCard",
                columns: new[] { "Id", "CardId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("3e48c876-cdef-44cb-b2df-66cad916338e"), new Guid("98a3319a-0804-4253-8dc9-cdd55adf843b"), new Guid("cd478a84-7e7d-4bb0-a7e2-71cfd198bd48") },
                    { new Guid("9d78264d-049d-459c-8705-1d5a1ccb9b26"), new Guid("ecb7f17d-e005-4e07-bbe1-01f9ba2d3f3a"), new Guid("fd46511f-39d1-4914-a31b-35a042a99f8d") },
                    { new Guid("b8137a82-1f66-4791-af56-fb4676d6258d"), new Guid("885a1980-7156-4a56-b704-8726f0d5217e"), new Guid("47add45f-1e56-4f10-ba8d-ed61fa6f1d06") }
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
