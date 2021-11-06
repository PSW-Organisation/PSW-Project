using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class RoomViewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsRenovatedUntill = table.Column<DateTime>(nullable: false),
                    Sector = table.Column<string>(nullable: true),
                    IsRenovated = table.Column<bool>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    RoomType = table.Column<int>(nullable: false),
                    NumOfTakenBeds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomGraphics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    DoorPosition = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RoomRefId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomGraphics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomGraphics_Room_RoomRefId",
                        column: x => x.RoomRefId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "RoomGraphics",
                columns: new[] { "Id", "DoorPosition", "Floor", "Height", "Name", "RoomRefId", "Type", "Width", "X", "Y" },
                values: new object[] { "0", "right", 0, 100.0, "S1", null, "Salter", 100.0, 0.0, 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_RoomGraphics_RoomRefId",
                table: "RoomGraphics",
                column: "RoomRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomGraphics");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
