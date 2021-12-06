using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class PrescriptionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true),
                    MedicineId = table.Column<string>(nullable: true),
                    PrescriptionDate = table.Column<DateTime>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FloorGraphics",
                columns: new[] { "Id", "BuildingId", "Floor" },
                values: new object[] { 3, 1, 0L });

            migrationBuilder.InsertData(
                table: "RoomEquipments",
                columns: new[] { "Id", "Name", "Quantity", "RoomId", "Type" },
                values: new object[] { 4, "Picks", 300, 16, "Dynamic" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsRenovated", "IsRenovatedUntill", "Name", "NumOfTakenBeds", "RoomType", "Sector" },
                values: new object[] { 17, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 3", 0, 5, "WS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "imbiamba",
                column: "Token",
                value: new Guid("601ccaa8-3a07-4a7c-89b9-9953e6eac8a7"));

            migrationBuilder.InsertData(
                table: "RoomGraphics",
                columns: new[] { "Id", "DoorPosition", "FloorGraphicId", "Height", "RoomId", "Width", "X", "Y" },
                values: new object[] { 17, "right", 3, 100, 17, 100, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DeleteData(
                table: "RoomEquipments",
                keyColumn: "Id",
                keyValue: 4);

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
                value: new Guid("17893c3e-07de-4e65-aad1-47964225946f"));
        }
    }
}
