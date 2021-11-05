using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyAPI.Migrations
{
    public partial class ComplaintMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "ComplaintId", "Content", "Date", "HospitalId", "Title" },
                values: new object[] { 1L, "Razbijene epruvete", new DateTime(2021, 11, 5, 17, 57, 13, 312, DateTimeKind.Local).AddTicks(868), 1L, "Losa isporuka" });

            migrationBuilder.UpdateData(
                table: "ResponsesToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 17, 57, 13, 309, DateTimeKind.Local).AddTicks(6989));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L);

            migrationBuilder.UpdateData(
                table: "ResponsesToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 17, 13, 36, 325, DateTimeKind.Local).AddTicks(3182));
        }
    }
}
