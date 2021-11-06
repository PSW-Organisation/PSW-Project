using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyAPI.Migrations
{
    public partial class HospitalUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PharmacyApiKey",
                table: "Hospitals",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 6, 13, 22, 31, 450, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "HospitalId",
                keyValue: 1L,
                column: "PharmacyApiKey",
                value: "test");

            migrationBuilder.UpdateData(
                table: "ResponsesToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 6, 13, 22, 31, 446, DateTimeKind.Local).AddTicks(9661));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyApiKey",
                table: "Hospitals");

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 17, 57, 13, 312, DateTimeKind.Local).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "ResponsesToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 17, 57, 13, 309, DateTimeKind.Local).AddTicks(6989));
        }
    }
}
