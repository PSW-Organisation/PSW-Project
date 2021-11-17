﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class PatientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExteriorGraphic",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IdElement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorGraphic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorGraphics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Floor = table.Column<long>(nullable: false),
                    BuildingId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorGraphics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalRecordId = table.Column<int>(nullable: false),
                    AllergenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sector = table.Column<string>(nullable: true),
                    Floor = table.Column<int>(nullable: false),
                    RoomType = table.Column<int>(nullable: false),
                    IsRenovated = table.Column<bool>(nullable: false),
                    IsRenovatedUntill = table.Column<DateTime>(nullable: false),
                    NumOfTakenBeds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomGraphics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    DoorPosition = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true),
                    FloorGraphicId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomGraphics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomGraphics_FloorGraphics_FloorGraphicId",
                        column: x => x.FloorGraphicId,
                        principalTable: "FloorGraphics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomGraphics_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeAddress = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LoginType = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsBlocked = table.Column<bool>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Specialization = table.Column<int>(nullable: true),
                    UsedOffDays = table.Column<int>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalPermits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPermits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalPermits_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalPermits_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    PatientId = table.Column<string>(nullable: false),
                    PersonalId = table.Column<string>(nullable: true),
                    BloodType = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Profession = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true),
                    PersonalDoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Users_PersonalDoctorId",
                        column: x => x.PersonalDoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Type" },
                values: new object[] { "1", "macija dlaka" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, "21000", "Srbija" });

            migrationBuilder.InsertData(
                table: "ExteriorGraphic",
                columns: new[] { "Id", "Height", "IdElement", "Name", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { "0", 200.0, "0", "ZGR1", "building", 100.0, 180.0, 30.0 },
                    { "1", 110.0, "1", "ZGR2", "building", 180.0, 380.0, 120.0 },
                    { "2", 50.0, "-1", "", "road", 600.0, 0.0, 250.0 }
                });

            migrationBuilder.InsertData(
                table: "FloorGraphics",
                columns: new[] { "Id", "BuildingId", "Floor" },
                values: new object[,]
                {
                    { "0", "0", 0L },
                    { "1", "0", 1L }
                });

            migrationBuilder.InsertData(
                table: "PatientAllergens",
                columns: new[] { "Id", "AllergenId", "MedicalRecordId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "PatientFeedbacks",
                columns: new[] { "Id", "Anonymous", "IsPublished", "PatientUsername", "PublishAllowed", "SubmissionDate", "Text" },
                values: new object[,]
                {
                    { -1, false, false, "p1", false, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alallalal" },
                    { 1, false, false, "imbiamba", false, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alallalal" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsRenovated", "IsRenovatedUntill", "Name", "NumOfTakenBeds", "RoomType", "Sector" },
                values: new object[,]
                {
                    { "13", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 3", 0, 3, "RRS" },
                    { "12", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 4", 0, 0, "ES" },
                    { "11", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 3", 0, 0, "ES" },
                    { "10", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 4", 0, 1, "OS" },
                    { "9", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 3", 0, 1, "OS" },
                    { "8", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 2", 0, 1, "OS" },
                    { "7", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 1", 0, 1, "OS" },
                    { "2", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 1", 1, 0, "ES" },
                    { "5", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 2", 0, 3, "RRS" },
                    { "4", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 1", 0, 3, "RRS" },
                    { "3", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 2", 1, 0, "ES" },
                    { "14", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 4", 0, 3, "RRS" },
                    { "1", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter 2", 0, 4, "CS" },
                    { "0", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter 1", 0, 4, "CS" },
                    { "6", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 1", 0, 5, "WS" },
                    { "15", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 2", 0, 5, "WS" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "PostalCode" },
                values: new object[] { 1, 1, "Novi Sad", "21000" });

            migrationBuilder.InsertData(
                table: "RoomGraphics",
                columns: new[] { "Id", "DoorPosition", "FloorGraphicId", "Height", "RoomId", "Width", "X", "Y" },
                values: new object[,]
                {
                    { "13", "top", "1", 80, "13", 147, 0, 517 },
                    { "12", "left", "1", 145, "12", 75, 222, 340 },
                    { "11", "right", "1", 145, "11", 75, 0, 340 },
                    { "10", "left", "1", 100, "10", 100, 197, 100 },
                    { "9", "right", "1", 100, "9", 100, 0, 100 },
                    { "8", "left", "1", 100, "8", 100, 197, 0 },
                    { "14", "top", "1", 80, "14", 147, 150, 517 },
                    { "7", "right", "1", 100, "7", 100, 0, 0 },
                    { "5", "top", "0", 80, "5", 147, 150, 517 },
                    { "4", "top", "0", 80, "4", 147, 0, 517 },
                    { "3", "left", "0", 145, "3", 75, 222, 340 },
                    { "2", "right", "0", 145, "2", 75, 0, 340 },
                    { "1", "right", "0", 100, "1", 100, 0, 100 },
                    { "0", "right", "0", 100, "0", 100, 0, 0 },
                    { "6", "none", "0", 160, "6", 140, 150, 20 },
                    { "15", "none", "1", 100, "15", 140, 10, 220 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "HomeAddress" },
                values: new object[] { 1, 1, "Sime Milutinovica, 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "DateOfBirth", "Discriminator", "Email", "Gender", "IsActivated", "IsBlocked", "LoginType", "Name", "ParentName", "Password", "Phone", "Surname", "Username", "Specialization", "UsedOffDays" },
                values: new object[] { "nelex", 1, new DateTime(1999, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "nemanjar@gmail.com", "male", false, false, 2, "Nemanja", "Zoran", "najjacapecurka", "019919199191", "Radojcic", "nelex", 0, 12 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "DateOfBirth", "Discriminator", "Email", "Gender", "IsActivated", "IsBlocked", "LoginType", "Name", "ParentName", "Password", "Phone", "Surname", "Username", "MedicalRecordId" },
                values: new object[] { "imbiamba", 1, new DateTime(2001, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", "markoilic@gmail.com", "male", false, false, 0, "Marko", "Milan", "pecurkaa", "019919199191", "Ilic", "imbiamba", 1 });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "PatientId", "BloodType", "DoctorId", "Height", "PersonalDoctorId", "PersonalId", "Profession", "Weight" },
                values: new object[] { "imbiamba", 1, "1", 186, null, "1209001129123", "Professor", 90 });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPermits_DoctorId",
                table: "MedicalPermits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPermits_PatientId",
                table: "MedicalPermits",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PersonalDoctorId",
                table: "MedicalRecords",
                column: "PersonalDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomGraphics_FloorGraphicId",
                table: "RoomGraphics",
                column: "FloorGraphicId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomGraphics_RoomId",
                table: "RoomGraphics",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "ExteriorGraphic");

            migrationBuilder.DropTable(
                name: "MedicalPermits");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "PatientAllergens");

            migrationBuilder.DropTable(
                name: "PatientFeedbacks");

            migrationBuilder.DropTable(
                name: "RoomGraphics");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FloorGraphics");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
