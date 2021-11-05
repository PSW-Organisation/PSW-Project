using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class ResponseToComplaintMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponseToComplaint",
                columns: table => new
                {
                    ResponseToComplaintId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComplaintId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseToComplaint", x => x.ResponseToComplaintId);
                });

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 17, 6, 19, 197, DateTimeKind.Local).AddTicks(1526));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseToComplaint");

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 11, 5, 16, 56, 41, 566, DateTimeKind.Local).AddTicks(3576));
        }
    }
}
