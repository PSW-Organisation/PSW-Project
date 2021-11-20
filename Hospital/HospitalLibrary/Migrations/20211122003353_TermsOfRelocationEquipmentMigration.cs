using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class TermsOfRelocationEquipmentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TermOfRelocationEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSourceRoom = table.Column<int>(nullable: false),
                    IdDestinationRoom = table.Column<int>(nullable: false),
                    NameOfEquipment = table.Column<string>(nullable: true),
                    QuantityOfEquipment = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    durationInMinutes = table.Column<int>(nullable: false),
                    FinishedRelocation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermOfRelocationEquipments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TermOfRelocationEquipments",
                columns: new[] { "Id", "EndTime", "FinishedRelocation", "IdDestinationRoom", "IdSourceRoom", "NameOfEquipment", "QuantityOfEquipment", "StartTime", "durationInMinutes" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 22, 1, 10, 0, 0, DateTimeKind.Unspecified), false, 8, 7, "bed", 2, new DateTime(2021, 11, 22, 1, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 2, new DateTime(2021, 11, 22, 4, 10, 0, 0, DateTimeKind.Unspecified), false, 9, 7, "needle", 14, new DateTime(2021, 11, 22, 3, 30, 0, 0, DateTimeKind.Unspecified), 40 },
                    { 3, new DateTime(2021, 11, 23, 7, 45, 0, 0, DateTimeKind.Unspecified), false, 9, 8, "infusion", 8, new DateTime(2021, 11, 23, 7, 30, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 4, new DateTime(2021, 11, 23, 9, 25, 0, 0, DateTimeKind.Unspecified), false, 11, 9, "table", 1, new DateTime(2021, 11, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), 25 },
                    { 5, new DateTime(2021, 11, 23, 11, 15, 0, 0, DateTimeKind.Unspecified), false, 7, 10, "xrayMachine", 1, new DateTime(2021, 11, 23, 10, 45, 0, 0, DateTimeKind.Unspecified), 30 },
                    { 6, new DateTime(2021, 11, 23, 14, 50, 0, 0, DateTimeKind.Unspecified), false, 11, 10, "chair", 5, new DateTime(2021, 11, 23, 14, 30, 0, 0, DateTimeKind.Unspecified), 20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TermOfRelocationEquipments");
        }
    }
}
