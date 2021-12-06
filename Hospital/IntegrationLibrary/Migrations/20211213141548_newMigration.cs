using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace IntegrationLibrary.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                          name: "Pharmacies",
                          columns: table => new
                          {
                              Id = table.Column<int>(nullable: false)
                                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                              PharmacyUrl = table.Column<string>(nullable: true),
                              PharmacyName = table.Column<string>(nullable: true),
                              PharmacyAddress = table.Column<string>(nullable: true),
                              PharmacyApiKey = table.Column<string>(nullable: true),
                              HospitalApiKey = table.Column<string>(nullable: true),
                              Comment = table.Column<string>(nullable: true),
                              Picture = table.Column<string>(nullable: true),
                              PharmacyCommunicationType = table.Column<int>(nullable: true)
                          },
                          constraints: table =>
                          {
                              table.PrimaryKey("PK_Pharmacies", x => x.Id);
                          });

            migrationBuilder.CreateTable(
                 name: "Notifications",
                 columns: table => new
                 {
                     Id = table.Column<int>(nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     Content = table.Column<string>(nullable: true),
                     Date = table.Column<DateTime>(nullable: false),
                     Seen = table.Column<bool>(nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Notifications", x => x.Id);
                 });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
