using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PharmacyLibrary.Migrations
{
    public partial class TenderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenderOpenDate = table.Column<DateTime>(nullable: false),
                    TenderCloseDate = table.Column<DateTime>(nullable: false),
                    Open = table.Column<bool>(nullable: false),
                    ApiKeyPharmacy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenderItemName = table.Column<string>(nullable: true),
                    TenderItemQuantity = table.Column<int>(nullable: false),
                    TenderItemPrice = table.Column<double>(nullable: false),
                    TenderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderItem_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenderItem_TenderId",
                table: "TenderItem",
                column: "TenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenderItem");

            migrationBuilder.DropTable(
                name: "Tenders");
        }
    }
}
