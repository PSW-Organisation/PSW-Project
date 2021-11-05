using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyAPI.Migrations
{
    public partial class RemodeledComplaintMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyId",
                table: "Complaints");

            migrationBuilder.AddColumn<long>(
                name: "HospitalId",
                table: "Complaints",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ResponsesToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 17, 13, 36, 325, DateTimeKind.Local).AddTicks(3182));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Complaints");

            migrationBuilder.AddColumn<long>(
                name: "PharmacyId",
                table: "Complaints",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ResponsesToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 17, 10, 56, 179, DateTimeKind.Local).AddTicks(6162));
        }
    }
}
