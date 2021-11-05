using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PharmacyAPI.Migrations
{
    public partial class HospitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HospitalUrl = table.Column<string>(nullable: true),
                    HospitalName = table.Column<string>(nullable: true),
                    HospitalAddress = table.Column<string>(nullable: true),
                    HospitalApiKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalId);
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "HospitalId", "HospitalAddress", "HospitalApiKey", "HospitalName", "HospitalUrl" },
                values: new object[] { 1L, "Kralja Petra 32", "", "Institut za zdravstvenu zastitu dece i omladine Vojvodine", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
