using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class newMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseRecivedTime",
                table: "TenderResponses");

            migrationBuilder.AddColumn<string>(
                name: "PharmacyApiKey",
                table: "TenderResponses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseReceivedTime",
                table: "TenderResponses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyApiKey",
                table: "TenderResponses");

            migrationBuilder.DropColumn(
                name: "ResponseReceivedTime",
                table: "TenderResponses");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseRecivedTime",
                table: "TenderResponses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
