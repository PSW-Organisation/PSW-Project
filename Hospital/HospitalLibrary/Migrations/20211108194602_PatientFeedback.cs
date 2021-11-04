using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class PatientFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientFeedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PatientUsername = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Anonymous = table.Column<bool>(nullable: false),
                    PublishAllowed = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFeedbacks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PatientFeedbacks",
                columns: new[] { "Id", "Anonymous", "IsPublished", "PatientUsername", "PublishAllowed", "SubmissionDate", "Text" },
                values: new object[] { "0", false, false, "p1", false, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alallalal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientFeedbacks");
        }
    }
}
