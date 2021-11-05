using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class SecondPharmacyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HospitalApiKey",
                table: "Pharmacies",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 16, 56, 41, 566, DateTimeKind.Local).AddTicks(3576));

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 1L,
                column: "HospitalApiKey",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalApiKey",
                table: "Pharmacies");

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 16, 48, 54, 783, DateTimeKind.Local).AddTicks(1101));
        }
    }
}
