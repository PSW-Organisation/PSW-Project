using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "patientId",
                table: "PatientFeedbacks");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "PatientFeedbacks",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "publishAllowed",
                table: "PatientFeedbacks",
                newName: "PublishAllowed");

            migrationBuilder.RenameColumn(
                name: "anonymous",
                table: "PatientFeedbacks",
                newName: "Anonymous");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PatientFeedbacks",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "PatientFeedbacks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PatientUsername",
                table: "PatientFeedbacks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "PatientFeedbacks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PatientFeedbacks",
                keyColumn: "Id",
                keyValue: "f1",
                columns: new[] { "PatientUsername", "SubmissionDate" },
                values: new object[] { "p1", new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "PatientFeedbacks");

            migrationBuilder.DropColumn(
                name: "PatientUsername",
                table: "PatientFeedbacks");

            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "PatientFeedbacks");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "PatientFeedbacks",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "PublishAllowed",
                table: "PatientFeedbacks",
                newName: "publishAllowed");

            migrationBuilder.RenameColumn(
                name: "Anonymous",
                table: "PatientFeedbacks",
                newName: "anonymous");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PatientFeedbacks",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "patientId",
                table: "PatientFeedbacks",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PatientFeedbacks",
                keyColumn: "id",
                keyValue: "f1",
                column: "patientId",
                value: "p1");
        }
    }
}
