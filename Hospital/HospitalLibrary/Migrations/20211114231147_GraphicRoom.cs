using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class GraphicRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExteriorGraphic",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IdElement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorGraphic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorGraphics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Floor = table.Column<long>(nullable: false),
                    BuildingId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorGraphics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientUsername = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Anonymous = table.Column<bool>(nullable: false),
                    PublishAllowed = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sector = table.Column<string>(nullable: true),
                    Floor = table.Column<int>(nullable: false),
                    RoomType = table.Column<int>(nullable: false),
                    IsRenovated = table.Column<bool>(nullable: false),
                    IsRenovatedUntill = table.Column<DateTime>(nullable: false),
                    NumOfTakenBeds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomGraphics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FloorGraphicId = table.Column<string>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    DoorPosition = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomGraphics", x => new { x.FloorGraphicId, x.Id });
                    table.ForeignKey(
                        name: "FK_RoomGraphics_FloorGraphics_FloorGraphicId",
                        column: x => x.FloorGraphicId,
                        principalTable: "FloorGraphics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomGraphics_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ExteriorGraphic",
                columns: new[] { "Id", "Height", "IdElement", "Name", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { "0", 200.0, "0", "ZGR1", "building", 100.0, 180.0, 30.0 },
                    { "1", 110.0, "1", "ZGR2", "building", 180.0, 380.0, 120.0 },
                    { "2", 50.0, "-1", "", "road", 600.0, 0.0, 250.0 },
                    { "3", 110.0, "-1", "", "road", 50.0, 0.0, 290.0 },
                    { "4", 400.0, "-1", "", "road", 50.0, 305.0, 0.0 },
                    { "5", 80.0, "-1", "P", "parking", 50.0, 245.0, 310.0 },
                    { "6", 80.0, "-1", "P", "parking", 50.0, 380.0, 20.0 }
                });

            migrationBuilder.InsertData(
                table: "FloorGraphics",
                columns: new[] { "Id", "BuildingId", "Floor" },
                values: new object[,]
                {
                    { "1", "0", 1L },
                    { "0", "0", 0L }
                });

            migrationBuilder.InsertData(
                table: "PatientFeedbacks",
                columns: new[] { "Id", "Anonymous", "IsPublished", "PatientUsername", "PublishAllowed", "SubmissionDate", "Text" },
                values: new object[] { -1, false, false, "p1", false, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alallalal" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsRenovated", "IsRenovatedUntill", "Name", "NumOfTakenBeds", "RoomType", "Sector" },
                values: new object[,]
                {
                    { "8", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 2", 0, 1, "OS" },
                    { "13", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 3", 0, 3, "RRS" },
                    { "12", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 4", 0, 0, "ES" },
                    { "11", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 3", 0, 0, "ES" },
                    { "10", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 4", 0, 1, "OS" },
                    { "9", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 3", 0, 1, "OS" },
                    { "7", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 1", 0, 1, "OS" },
                    { "2", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 1", 1, 0, "ES" },
                    { "5", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 2", 0, 3, "RRS" },
                    { "4", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 1", 0, 3, "RRS" },
                    { "3", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 2", 1, 0, "ES" },
                    { "14", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 4", 0, 3, "RRS" },
                    { "1", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter 2", 0, 4, "CS" },
                    { "0", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter 1", 0, 4, "CS" },
                    { "6", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 1", 0, 5, "WS" },
                    { "15", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 2", 0, 5, "WS" }
                });

            migrationBuilder.InsertData(
                table: "RoomGraphics",
                columns: new[] { "FloorGraphicId", "Id", "DoorPosition", "Height", "RoomId", "Width", "X", "Y" },
                values: new object[,]
                {
                    { "0", "0", "right", 100, "0", 100, 0, 0 },
                    { "0", "1", "right", 100, "1", 100, 0, 100 },
                    { "0", "2", "right", 145, "2", 75, 0, 340 },
                    { "0", "3", "left", 145, "3", 75, 222, 340 },
                    { "0", "4", "top", 80, "4", 147, 0, 517 },
                    { "0", "5", "top", 80, "5", 147, 150, 517 },
                    { "0", "6", "none", 160, "6", 140, 150, 20 },
                    { "1", "7", "right", 100, "7", 100, 0, 0 },
                    { "1", "8", "left", 100, "8", 100, 197, 0 },
                    { "1", "9", "right", 100, "9", 100, 0, 100 },
                    { "1", "10", "left", 100, "10", 100, 197, 100 },
                    { "1", "11", "right", 145, "11", 75, 0, 340 },
                    { "1", "12", "left", 145, "12", 75, 222, 340 },
                    { "1", "13", "top", 80, "13", 147, 0, 517 },
                    { "1", "14", "top", 80, "14", 147, 150, 517 },
                    { "1", "15", "none", 100, "15", 140, 10, 220 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomGraphics_RoomId",
                table: "RoomGraphics",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExteriorGraphic");

            migrationBuilder.DropTable(
                name: "PatientFeedbacks");

            migrationBuilder.DropTable(
                name: "RoomGraphics");

            migrationBuilder.DropTable(
                name: "FloorGraphics");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
