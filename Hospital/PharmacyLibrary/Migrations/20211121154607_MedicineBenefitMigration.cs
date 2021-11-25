using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PharmacyLibrary.Migrations
{
    public partial class MedicineBenefitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "Ingredients",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "SideEffects",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "UseFor",
                table: "Medicines",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicineBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicineBenefitTitle = table.Column<string>(nullable: true),
                    MedicineBenefitContent = table.Column<string>(nullable: true),
                    MedicineBenefitDueDate = table.Column<DateTime>(nullable: false),
                    MedicineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineBenefits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineBenefits");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "SideEffects",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "UseFor",
                table: "Medicines");
        }
    }
}
