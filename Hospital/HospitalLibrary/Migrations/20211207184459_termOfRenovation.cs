using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class termOfRenovation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TermOfRenovations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    DurationInMinutes = table.Column<int>(nullable: false),
                    StateOfRenovation = table.Column<int>(nullable: false),
                    TypeOfRenovation = table.Column<int>(nullable: false),
                    IdRoomA = table.Column<int>(nullable: false),
                    IdRoomB = table.Column<int>(nullable: false),
                    EquipmentLogic = table.Column<int>(nullable: false),
                    NewNameForRoomA = table.Column<string>(nullable: true),
                    NewSectorForRoomA = table.Column<string>(nullable: true),
                    NewRoomTypeForRoomA = table.Column<int>(nullable: false),
                    NewNameForRoomB = table.Column<string>(nullable: true),
                    NewSectorForRoomB = table.Column<string>(nullable: true),
                    NewRoomTypeForRoomB = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermOfRenovations", x => x.Id);
                });

           
            migrationBuilder.InsertData(
                table: "TermOfRenovations",
                columns: new[] { "Id", "DurationInMinutes", "EndTime", "EquipmentLogic", "IdRoomA", "IdRoomB", "NewNameForRoomA", "NewNameForRoomB", "NewRoomTypeForRoomA", "NewRoomTypeForRoomB", "NewSectorForRoomA", "NewSectorForRoomB", "StartTime", "StateOfRenovation", "TypeOfRenovation" },
                values: new object[,]
                {
                    { 1, 60, new DateTime(2021, 12, 7, 11, 30, 0, 0, DateTimeKind.Unspecified), 0, 1, 16, "Operation room 5", "", 1, 5, "OS", "", new DateTime(2021, 12, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 3, 0 },
                    { 2, 1440, new DateTime(2021, 12, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, -1, "Operation room 6", "Operation room 7", 1, 1, "OS", "OS", new DateTime(2021, 12, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "imbiamba",
                column: "Token",
                value: new Guid("601ccaa8-3a07-4a7c-89b9-9953e6eac8a7"));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TermOfRenovations");

            migrationBuilder.DeleteData(
                table: "RoomEquipments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomGraphics",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FloorGraphics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "imbiamba",
                column: "Token",
                value: new Guid("17893c3e-07de-4e65-aad1-47964225946f"));
        }
    }
}
