using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class MedicineMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MedicineStatus = table.Column<int>(nullable: false),
                    MedicineAmmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTransactions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MedicineId = table.Column<string>(nullable: true),
                    MedicineAmmount = table.Column<int>(nullable: false),
                    TransactionTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineIngredient",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    MedicineId = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineIngredient");

            migrationBuilder.DropTable(
                name: "MedicineTransactions");

            migrationBuilder.DropTable(
                name: "Medicine");
        }
    }
}
