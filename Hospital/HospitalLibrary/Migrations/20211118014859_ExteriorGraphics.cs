using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class ExteriorGraphics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExteriorGraphic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IdElement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorGraphic", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExteriorGraphic",
                columns: new[] { "Id", "Height", "IdElement", "Name", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 200.0, 0, "ZGR1", "building", 100.0, 180.0, 30.0 },
                    { 2, 110.0, 1, "ZGR2", "building", 180.0, 380.0, 120.0 },
                    { 7, 50.0, -1, "", "road", 600.0, 0.0, 250.0 },
                    { 3, 110.0, -1, "", "road", 50.0, 0.0, 290.0 },
                    { 4, 400.0, -1, "", "road", 50.0, 305.0, 0.0 },
                    { 5, 80.0, -1, "P", "parking", 50.0, 245.0, 310.0 },
                    { 6, 80.0, -1, "P", "parking", 50.0, 380.0, 20.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExteriorGraphic");
        }
    }
}
