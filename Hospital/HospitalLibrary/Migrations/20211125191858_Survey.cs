﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class Survey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "FloorGraphics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Floor = table.Column<long>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorGraphics", x => x.Id);
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
                name: "RoomEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "TermOfRelocationEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSourceRoom = table.Column<int>(nullable: false),
                    IdDestinationRoom = table.Column<int>(nullable: false),
                    NameOfEquipment = table.Column<string>(nullable: true),
                    QuantityOfEquipment = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    DurationInMinutes = table.Column<int>(nullable: false),
                    FinishedRelocation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermOfRelocationEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LoginType = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<Guid>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Specialization = table.Column<int>(nullable: true),
                    UsedOffDays = table.Column<int>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomGraphics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    DoorPosition = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false),
                    FloorGraphicId = table.Column<int>(nullable: false)
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
                    DoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergens",
                columns: table => new
                {
                    PatientId = table.Column<string>(nullable: false),
                    AllergenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergens", x => new { x.PatientId, x.AllergenId });
                    table.ForeignKey(
                        name: "FK_PatientAllergens_Allergens_AllergenId",
                        column: x => x.AllergenId,
                        principalTable: "Allergens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAllergens_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    VisitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    SurveyId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => new { x.SurveyId, x.Id });
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "macija dlaka" });

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

            migrationBuilder.InsertData(
                table: "FloorGraphics",
                columns: new[] { "Id", "BuildingId", "Floor" },
                values: new object[,]
                {
                    { 1, 0, 0L },
                    { 2, 0, 1L }
                });

            migrationBuilder.InsertData(
                table: "PatientFeedbacks",
                columns: new[] { "Id", "Anonymous", "IsPublished", "PatientUsername", "PublishAllowed", "SubmissionDate", "Text" },
                values: new object[,]
                {
                    { -1, false, true, "imbiamba", true, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sehr gut!" },
                    { 1, false, false, "imbiamba", false, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alallalal" }
                });

            migrationBuilder.InsertData(
                table: "RoomEquipments",
                columns: new[] { "Id", "Name", "Quantity", "RoomId", "Type" },
                values: new object[,]
                {
                    { 3, "Needle", 300, 3, "Dynamic" },
                    { 2, "Needle", 200, 2, "Dynamic" },
                    { 1, "Bed", 2, 1, "Static" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsRenovated", "IsRenovatedUntill", "Name", "NumOfTakenBeds", "RoomType", "Sector" },
                values: new object[,]
                {
                    { 13, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 3", 0, 3, "RRS" },
                    { 12, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 4", 0, 0, "ES" },
                    { 11, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 3", 0, 0, "ES" },
                    { 10, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 4", 0, 1, "OS" },
                    { 9, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 3", 0, 1, "OS" },
                    { 8, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 2", 0, 1, "OS" },
                    { 7, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 1", 0, 1, "OS" },
                    { 6, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 1", 0, 5, "WS" },
                    { 5, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 2", 0, 3, "RRS" },
                    { 4, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 1", 0, 3, "RRS" },
                    { 3, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 2", 1, 0, "ES" },
                    { 15, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 2", 0, 5, "WS" },
                    { 1, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter 2", 0, 4, "CS" },
                    { 16, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter 1", 0, 4, "CS" },
                    { 14, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 4", 0, 3, "RRS" },
                    { 2, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 1", 1, 0, "ES" }
                });

            migrationBuilder.InsertData(
                table: "TermOfRelocationEquipments",
                columns: new[] { "Id", "EndTime", "FinishedRelocation", "IdDestinationRoom", "IdSourceRoom", "NameOfEquipment", "QuantityOfEquipment", "StartTime", "DurationInMinutes" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 11, 23, 14, 50, 0, 0, DateTimeKind.Unspecified), false, 11, 10, "chair", 5, new DateTime(2021, 11, 23, 14, 30, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 4, new DateTime(2021, 11, 23, 9, 25, 0, 0, DateTimeKind.Unspecified), false, 11, 9, "table", 1, new DateTime(2021, 11, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), 25 },
                    { 3, new DateTime(2021, 11, 23, 7, 45, 0, 0, DateTimeKind.Unspecified), false, 9, 8, "infusion", 8, new DateTime(2021, 11, 23, 7, 30, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 2, new DateTime(2021, 11, 22, 4, 10, 0, 0, DateTimeKind.Unspecified), false, 9, 7, "needle", 14, new DateTime(2021, 11, 22, 3, 30, 0, 0, DateTimeKind.Unspecified), 40 },
                    { 1, new DateTime(2021, 11, 22, 1, 10, 0, 0, DateTimeKind.Unspecified), false, 8, 7, "bed", 2, new DateTime(2021, 11, 22, 1, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 5, new DateTime(2021, 11, 23, 11, 15, 0, 0, DateTimeKind.Unspecified), false, 7, 10, "xrayMachine", 1, new DateTime(2021, 11, 23, 10, 45, 0, 0, DateTimeKind.Unspecified), 30 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "DateOfBirth", "Discriminator", "Email", "Gender", "IsActivated", "IsBlocked", "LoginType", "Name", "ParentName", "Password", "Phone", "Surname", "Token", "Username", "DoctorId" },
                values: new object[] { "imbiamba", "Sime Milosevica, 5", null, null, new DateTime(2001, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", "markoilic@gmail.com", "male", false, false, 0, "Marko", "Milan", "pecurkaa", "019919199191", "Ilic", new Guid("17893c3e-07de-4e65-aad1-47964225946f"), "imbiamba", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "DateOfBirth", "Discriminator", "Email", "Gender", "IsActivated", "IsBlocked", "LoginType", "Name", "ParentName", "Password", "Phone", "Surname", "Token", "Username", "Specialization", "UsedOffDays" },
                values: new object[] { "nelex", "Sime Milutinovica, 2", "Novi Sad", "Serbia", new DateTime(1999, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "nemanjar@gmail.com", "male", false, false, 2, "Nemanja", "Zoran", "najjacapecurka", "019919199191", "Radojcic", new Guid("00000000-0000-0000-0000-000000000000"), "nelex", 3, 12 });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "PatientId", "BloodType", "DoctorId", "Height", "PersonalId", "Profession", "Weight" },
                values: new object[] { "imbiamba", 4, "nelex", 186, "1209001129123", "Professor", 90 });

            migrationBuilder.InsertData(
                table: "PatientAllergens",
                columns: new[] { "PatientId", "AllergenId" },
                values: new object[] { "imbiamba", 1 });

            migrationBuilder.InsertData(
                table: "RoomGraphics",
                columns: new[] { "Id", "DoorPosition", "FloorGraphicId", "Height", "RoomId", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 6, "none", 1, 160, 6, 140, 150, 20 },
                    { 13, "top", 2, 80, 13, 150, 0, 517 },
                    { 12, "left", 2, 145, 12, 75, 222, 340 },
                    { 11, "right", 2, 145, 11, 75, 0, 340 },
                    { 10, "left", 2, 100, 10, 100, 197, 100 },
                    { 9, "right", 2, 100, 9, 100, 0, 100 },
                    { 8, "left", 2, 100, 8, 100, 197, 0 },
                    { 7, "right", 2, 100, 7, 100, 0, 0 },
                    { 15, "none", 2, 100, 15, 140, 10, 220 },
                    { 5, "top", 1, 80, 5, 150, 150, 517 },
                    { 4, "top", 1, 80, 4, 150, 0, 517 },
                    { 3, "left", 1, 145, 3, 75, 222, 340 },
                    { 2, "right", 1, 145, 2, 75, 0, 340 },
                    { 1, "right", 1, 100, 1, 100, 0, 100 },
                    { 16, "right", 1, 100, 16, 100, 0, 0 },
                    { 14, "top", 2, 80, 14, 150, 150, 517 }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "PatientId", "SubmissionDate", "VisitId" },
                values: new object[] { -1, "imbiamba", new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "SurveyId", "Id", "Category", "Value" },
                values: new object[] { -1, -1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPermits_DoctorId",
                table: "MedicalPermits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPermits_PatientId",
                table: "MedicalPermits",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DoctorId",
                table: "MedicalRecords",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergens_AllergenId",
                table: "PatientAllergens",
                column: "AllergenId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomGraphics_FloorGraphicId",
                table: "RoomGraphics",
                column: "FloorGraphicId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomGraphics_RoomId",
                table: "RoomGraphics",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PatientId",
                table: "Surveys",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DoctorId",
                table: "Users",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Questions");

            migrationBuilder.DropTable(
                name: "RoomEquipments");

            migrationBuilder.DropTable(
                name: "RoomGraphics");

            migrationBuilder.DropTable(
                name: "TermOfRelocationEquipments");

            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "FloorGraphics");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
