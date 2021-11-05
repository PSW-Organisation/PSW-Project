using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PharmacyAPI.Migrations
{
    public partial class ComplaintResponseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponsesToComplaint",
                columns: table => new
                {
                    ResponseToComplaintId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsesToComplaint", x => x.ResponseToComplaintId);
                });

            migrationBuilder.InsertData(
                table: "ResponsesToComplaint",
                columns: new[] { "ResponseToComplaintId", "Content", "Date" },
                values: new object[] { 1L, "Imali smo problema sa nabavkom leka panadol, izvinjavamo se na zakasneloj porudzbini", new DateTime(2021, 11, 4, 20, 12, 50, 155, DateTimeKind.Local).AddTicks(2491) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsesToComplaint");
        }
    }
}
