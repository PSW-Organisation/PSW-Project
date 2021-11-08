using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class FirstSprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Complaints",
                keyColumn: "ComplaintId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ResponseToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "ComplaintId", "Content", "Date", "PharmacyId", "Title" },
                values: new object[] { 1L, "Postovani, molimo Vas da isporuke o medicinskim sredstvima vrsite u navedenom roku! ", new DateTime(2021, 11, 5, 18, 42, 3, 155, DateTimeKind.Local).AddTicks(7421), 1L, "Prigovor o dostavi" });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "PharmacyId", "HospitalApiKey", "PharmacyAddress", "PharmacyApiKey", "PharmacyName", "PharmacyUrl" },
                values: new object[] { 1L, "", "Bul. Cara Lazara 58", "", "Apoteka Jankovic", "" });

            migrationBuilder.InsertData(
                table: "ResponseToComplaint",
                columns: new[] { "ResponseToComplaintId", "ComplaintId", "Content", "Date" },
                values: new object[] { 1L, 0L, "Prvi test Response to complaint", new DateTime(2021, 11, 5, 18, 42, 3, 159, DateTimeKind.Local).AddTicks(1822) });
        }
    }
}
