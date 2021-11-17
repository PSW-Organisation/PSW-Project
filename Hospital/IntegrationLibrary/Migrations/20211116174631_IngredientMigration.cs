using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class IngredientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineIngredient");

            migrationBuilder.AddColumn<List<string>>(
                name: "MedicineIngredient",
                table: "Medicine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicineIngredient",
                table: "Medicine");

            migrationBuilder.CreateTable(
                name: "MedicineIngredient",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    MedicineId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineIngredient", x => x.Name);
                    table.ForeignKey(
                        name: "FK_MedicineIngredient_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineIngredient_MedicineId",
                table: "MedicineIngredient",
                column: "MedicineId");
        }
    }
}
