using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class dodatiPrigovori3 : Migration
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
                values: new object[] { new DateTime(2021, 11, 4, 21, 22, 6, 394, DateTimeKind.Local).AddTicks(3016), 1L });
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
                value: new DateTime(2021, 11, 4, 16, 28, 16, 16, DateTimeKind.Local).AddTicks(44));
        }
    }
}
