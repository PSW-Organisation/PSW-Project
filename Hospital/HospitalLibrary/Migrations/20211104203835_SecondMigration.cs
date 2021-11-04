using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientFeedbacks",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    patientId = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    anonymous = table.Column<bool>(nullable: false),
                    publishAllowed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFeedbacks", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "PatientFeedbacks",
                columns: new[] { "id", "anonymous", "patientId", "publishAllowed", "text" },
                values: new object[] { "f1", false, "p1", false, "alallalal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientFeedbacks");
        }
    }
}
