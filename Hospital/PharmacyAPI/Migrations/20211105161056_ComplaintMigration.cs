using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PharmacyAPI.Migrations
{
    public partial class ComplaintMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ComplaintId",
                table: "ResponsesToComplaint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    ComplaintId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PharmacyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.ComplaintId);
                });

            migrationBuilder.UpdateData(
                table: "ResponsesToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 17, 10, 56, 179, DateTimeKind.Local).AddTicks(6162));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintId",
                table: "ResponsesToComplaint");

            migrationBuilder.UpdateData(
                table: "ResponsesToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 4, 20, 12, 50, 155, DateTimeKind.Local).AddTicks(2491));
        }
    }
}
