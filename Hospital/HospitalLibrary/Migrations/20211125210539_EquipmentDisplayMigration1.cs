using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class EquipmentDisplayMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "FloorGraphics",
                columns: new[] { "Id", "BuildingId", "Floor" },
                values: new object[] { 3, 1, 0L });

            migrationBuilder.InsertData(
                table: "RoomEquipments",
                columns: new[] { "Id", "Name", "Quantity", "RoomId", "Type" },
                values: new object[,]
                {
                    { 4, "Picks", 300, 17, "Dynamic" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsRenovated", "IsRenovatedUntill", "Name", "NumOfTakenBeds", "RoomType", "Sector" },
                values: new object[] { 17, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 3", 0, 5, "WS" });


            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "imbiamba",
                column: "Token",
                value: new Guid("b48819f3-473a-4015-aefb-aa31ad80e018"));

            migrationBuilder.InsertData(
                table: "RoomGraphics",
                columns: new[] { "Id", "DoorPosition", "FloorGraphicId", "Height", "RoomId", "Width", "X", "Y" },
                values: new object[] { 17, "right", 3, 100, 17, 100, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomEquipments");

            migrationBuilder.DropTable(
                name: "TermOfRelocationEquipments");

            migrationBuilder.DeleteData(
                table: "RoomGraphics",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FloorGraphics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "imbiamba",
                column: "Token",
                value: new Guid("601ccaa8-3a07-4a7c-89b9-9953e6eac8a7"));
        }
    }
}
