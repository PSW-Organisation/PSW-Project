using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyAPI.Migrations
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
                table: "Hospitals",
                keyColumn: "HospitalId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ResponsesToComplaint",
                keyColumn: "ResponseToComplaintId",
                keyValue: 1L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "ComplaintId", "Content", "Date", "HospitalId", "Title" },
                values: new object[] { 1L, "Razbijene epruvete", new DateTime(2021, 11, 6, 13, 22, 31, 450, DateTimeKind.Local).AddTicks(4063), 1L, "Losa isporuka" });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "HospitalId", "HospitalAddress", "HospitalApiKey", "HospitalName", "HospitalUrl", "PharmacyApiKey" },
                values: new object[] { 1L, "Kralja Petra 32", "", "Institut za zdravstvenu zastitu dece i omladine Vojvodine", "", "test" });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "PharmacyId", "PharmacyAddress", "PharmacyApiKey", "PharmacyName", "PharmacyUrl" },
                values: new object[] { 1L, "Bul. Cara Lazara 58", "", "Apoteka Jankovic", "" });

            migrationBuilder.InsertData(
                table: "ResponsesToComplaint",
                columns: new[] { "ResponseToComplaintId", "ComplaintId", "Content", "Date" },
                values: new object[] { 1L, 0L, "Imali smo problema sa nabavkom leka panadol, izvinjavamo se na zakasneloj porudzbini", new DateTime(2021, 11, 6, 13, 22, 31, 446, DateTimeKind.Local).AddTicks(9661) });
        }
    }
}
