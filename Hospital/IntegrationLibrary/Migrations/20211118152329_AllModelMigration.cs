using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class AllModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseToComplaint",
                table: "ResponseToComplaint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ResponseToComplaintId",
                table: "ResponseToComplaint");

            migrationBuilder.DropColumn(
                name: "PharmacyId",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "ComplaintId",
                table: "Complaints");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ResponseToComplaint",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pharmacies",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Complaints",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseToComplaint",
                table: "ResponseToComplaint",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseToComplaint",
                table: "ResponseToComplaint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ResponseToComplaint");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Complaints");

            migrationBuilder.AddColumn<long>(
                name: "ResponseToComplaintId",
                table: "ResponseToComplaint",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "PharmacyId",
                table: "Pharmacies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "ComplaintId",
                table: "Complaints",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseToComplaint",
                table: "ResponseToComplaint",
                column: "ResponseToComplaintId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies",
                column: "PharmacyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints",
                column: "ComplaintId");
        }
    }
}
