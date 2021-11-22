using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyLibrary.Migrations
{
    public partial class Migration2 : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
