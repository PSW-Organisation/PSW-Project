using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class InitialPharmacyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitTime");

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    PharmacyId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PharmacyUrl = table.Column<string>(nullable: true),
                    PharmacyName = table.Column<string>(nullable: true),
                    PharmacyAddress = table.Column<string>(nullable: true),
                    PharmacyApiKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.PharmacyId);
                });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "PharmacyId", "PharmacyAddress", "PharmacyApiKey", "PharmacyName", "PharmacyUrl" },
                values: new object[] { 1L, "Bul. Cara Lazara 58", "", "Apoteka Jankovic", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.CreateTable(
                name: "VisitTime",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitTime", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VisitTime",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[] { "zoki", new DateTime(2010, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
