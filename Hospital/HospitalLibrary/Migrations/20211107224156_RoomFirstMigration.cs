using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class RoomFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomId",
                table: "RoomGraphics",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
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
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsRenovated", "IsRenovatedUntill", "NumOfTakenBeds", "RoomType", "Sector" },
                values: new object[] { "0", 1, false, new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "S!" });

            migrationBuilder.UpdateData(
                table: "RoomGraphics",
                keyColumn: "Id",
                keyValue: "0",
                column: "RoomId",
                value: "0");

            migrationBuilder.CreateIndex(
                name: "IX_RoomGraphics_RoomId",
                table: "RoomGraphics",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomGraphics_Rooms_RoomId",
                table: "RoomGraphics",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomGraphics_Rooms_RoomId",
                table: "RoomGraphics");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_RoomGraphics_RoomId",
                table: "RoomGraphics");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomGraphics");
        }
    }
}
