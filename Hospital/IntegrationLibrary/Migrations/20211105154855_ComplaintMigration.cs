using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class ComplaintMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PharmacyId",
                table: "Complaints",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                columns: new[] { "Date", "PharmacyId" },
                values: new object[] { new DateTime(2021, 11, 5, 16, 48, 54, 783, DateTimeKind.Local).AddTicks(1101), 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyId",
                table: "Complaints");

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 4, 16, 6, 18, 802, DateTimeKind.Local).AddTicks(8398));
        }
    }
}
