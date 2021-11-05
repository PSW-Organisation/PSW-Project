using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class ResponseToComplaintSeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 18, 42, 3, 155, DateTimeKind.Local).AddTicks(7421));

            migrationBuilder.InsertData(
                table: "ResponseToComplaint",
                columns: new[] { "ResponseToComplaintId", "ComplaintId", "Content", "Date" },
                values: new object[] { 1L, 0L, "Prvi test Response to complaint", new DateTime(2021, 11, 5, 18, 42, 3, 159, DateTimeKind.Local).AddTicks(1822) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResponseToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L);

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 17, 6, 19, 197, DateTimeKind.Local).AddTicks(1526));
        }
    }
}
