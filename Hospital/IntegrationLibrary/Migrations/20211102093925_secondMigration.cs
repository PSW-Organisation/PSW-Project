using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitTime",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitTime");
        }
    }
}
