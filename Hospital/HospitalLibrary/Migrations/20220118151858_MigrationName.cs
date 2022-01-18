using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class MigrationName : Migration
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
                name: "DoctorVacations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorVacations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    EventAppName = table.Column<int>(nullable: false),
                    EventClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExteriorGraphic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<int>(nullable: true),
                    Y = table.Column<int>(nullable: true),
                    Width = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: true),
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
                    BuildingId = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorGraphics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnCallShifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'10', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnCallShifts", x => x.Id);
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
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true),
                    MedicineId = table.Column<string>(nullable: true),
                    PrescriptionDate = table.Column<DateTime>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
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
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    ShiftOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
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
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    DurationInMinutes = table.Column<int>(nullable: false),
                    RelocationState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermOfRelocationEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermOfRenovations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
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
                    RoomId = table.Column<int>(nullable: true),
                    ShiftOrder = table.Column<int>(nullable: true),
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
                    X = table.Column<int>(nullable: true),
                    Y = table.Column<int>(nullable: true),
                    Width = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: true),
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
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    VisitType = table.Column<int>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true),
                    IsReviewed = table.Column<bool>(nullable: false),
                    IsCanceled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_Users_PatientId",
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
                table: "DoctorVacations",
                columns: new[] { "Id", "Description", "DoctorId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, "Zimovanje", "mkisic", new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Letovanje", "nelex", new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Bolovanje", "mkisic", new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ExteriorGraphic",
                columns: new[] { "Id", "IdElement", "Name", "Type", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 6, -1, "P", "parking", 80, 50, 380, 20 },
                    { 4, -1, "", "road", 400, 50, 305, 0 },
                    { 3, -1, "", "road", 110, 50, 0, 290 },
                    { 7, -1, "", "road", 50, 600, 0, 250 },
                    { 2, 1, "ZGR2", "building", 110, 180, 380, 120 },
                    { 5, -1, "P", "parking", 80, 50, 245, 310 },
                    { 1, 0, "ZGR1", "building", 200, 100, 180, 30 }
                });

            migrationBuilder.InsertData(
                table: "FloorGraphics",
                columns: new[] { "Id", "BuildingId", "Floor" },
                values: new object[,]
                {
                    { 3, 1, 0 },
                    { 1, 0, 0 },
                    { 2, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "OnCallShifts",
                columns: new[] { "Id", "Date", "DoctorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mkisic" },
                    { 4, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "nelex" },
                    { 3, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "mkisic" },
                    { 2, new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "nelex" }
                });

            migrationBuilder.InsertData(
                table: "PatientFeedbacks",
                columns: new[] { "Id", "Anonymous", "IsPublished", "PatientUsername", "PublishAllowed", "SubmissionDate", "Text" },
                values: new object[,]
                {
                    { 1, false, false, "imbiamba", false, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alallalal" },
                    { -1, false, true, "imbiamba", true, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sehr gut!" }
                });

            migrationBuilder.InsertData(
                table: "RoomEquipments",
                columns: new[] { "Id", "Name", "Quantity", "RoomId", "Type" },
                values: new object[,]
                {
                    { 4, "Picks", 300, 16, "Dynamic" },
                    { 3, "Needle", 300, 3, "Dynamic" },
                    { 2, "Needle", 200, 2, "Dynamic" },
                    { 1, "Bed", 2, 1, "Static" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsRenovated", "IsRenovatedUntill", "Name", "NumOfTakenBeds", "RoomType", "Sector" },
                values: new object[,]
                {
                    { 17, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 3", 0, 5, "WS" },
                    { 15, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 2", 0, 5, "WS" },
                    { 14, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 4", 0, 3, "RRS" },
                    { 13, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 3", 0, 3, "RRS" },
                    { 12, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 4", 0, 0, "ES" },
                    { 11, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 3", 0, 0, "ES" },
                    { 7, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 1", 0, 1, "OS" },
                    { 9, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 3", 0, 1, "OS" },
                    { 8, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 2", 0, 1, "OS" },
                    { 6, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting room 1", 0, 5, "WS" },
                    { 5, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 2", 0, 3, "RRS" },
                    { 4, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restroom 1", 0, 3, "RRS" },
                    { 3, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 2", 1, 0, "ES" },
                    { 2, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Examination room 1", 1, 0, "ES" },
                    { 1, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter 2", 0, 4, "CS" },
                    { 16, 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter 1", 0, 4, "CS" },
                    { 10, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation room 4", 0, 1, "OS" }
                });

            migrationBuilder.InsertData(
                table: "TermOfRelocationEquipments",
                columns: new[] { "Id", "DurationInMinutes", "IdDestinationRoom", "IdSourceRoom", "NameOfEquipment", "QuantityOfEquipment", "RelocationState", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 6, 20, 11, 10, "chair", 5, 0, new DateTime(2021, 11, 23, 14, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 30, 7, 10, "xrayMachine", 1, 0, new DateTime(2021, 11, 23, 11, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 10, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 25, 11, 9, "table", 1, 0, new DateTime(2021, 11, 23, 9, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 40, 9, 7, "needle", 14, 0, new DateTime(2021, 11, 22, 4, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 22, 3, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 10, 8, 7, "bed", 2, 0, new DateTime(2021, 11, 22, 1, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 22, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 15, 9, 8, "infusion", 8, 0, new DateTime(2021, 11, 23, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 7, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TermOfRenovations",
                columns: new[] { "Id", "DurationInMinutes", "EquipmentLogic", "IdRoomA", "IdRoomB", "NewNameForRoomA", "NewNameForRoomB", "NewRoomTypeForRoomA", "NewRoomTypeForRoomB", "NewSectorForRoomA", "NewSectorForRoomB", "StateOfRenovation", "TypeOfRenovation", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 60, 0, 1, 16, "Operation room 5", "", 1, 5, "OS", "", 3, 1, new DateTime(2021, 12, 7, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 7, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1440, 2, 4, -1, "Operation room 6", "Operation room 7", 1, 1, "OS", "OS", 0, 0, new DateTime(2021, 12, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 17, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "DateOfBirth", "Discriminator", "Email", "Gender", "IsActivated", "IsBlocked", "LoginType", "Name", "ParentName", "Password", "Phone", "Surname", "Token", "Username", "DoctorId" },
                values: new object[] { "imbiamba", "Sime Milosevica, 5", "Novi Sad", "Serbia", new DateTime(2001, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", "markoilic@gmail.com", "male", false, false, 0, "Marko", "Milan", "pecurkaa", "019919199191", "Ilic", new Guid("601ccaa8-3a07-4a7c-89b9-9953e6eac8a7"), "imbiamba", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "DateOfBirth", "Discriminator", "Email", "Gender", "IsActivated", "IsBlocked", "LoginType", "Name", "ParentName", "Password", "Phone", "Surname", "Token", "Username" },
                values: new object[,]
                {
                    { "laki", "Hajduk Veljka, 5", "Novi Sad", "Serbia", new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", "igor.m@gmail.com", "male", true, false, 1, "Igor", "Ivan", "Laki123!", "129572904354", "Maric", new Guid("00000000-0000-0000-0000-000000000000"), "laki" },
                    { "jagodica", "Rumenacka, 23", "Novi Sad", "Serbia", new DateTime(1985, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", "jagodica@gmail.com", "female", true, false, 1, "Jagoda", "Petar", "Jagodica123!", "6820543267243", "Vasic", new Guid("00000000-0000-0000-0000-000000000000"), "jagodica" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "DateOfBirth", "Discriminator", "Email", "Gender", "IsActivated", "IsBlocked", "LoginType", "Name", "ParentName", "Password", "Phone", "Surname", "Token", "Username", "RoomId", "ShiftOrder", "Specialization", "UsedOffDays" },
                values: new object[,]
                {
                    { "nelex", "Sime Milutinovica, 2", "Novi Sad", "Serbia", new DateTime(1999, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "nemanjar@gmail.com", "male", false, false, 2, "Nemanja", "Zoran", "najjacapecurka", "019919199191", "Radojcic", new Guid("00000000-0000-0000-0000-000000000000"), "nelex", 1, 1, 3, 12 },
                    { "mkisic", "Sime Milutinovica, 2", "Novi Sad", "Serbia", new DateTime(1999, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "nemanjar@gmail.com", "male", false, false, 2, "Mihajlo", "Zvezdan", "ftn", "019919199191", "Kisic", new Guid("00000000-0000-0000-0000-000000000000"), "mkisic", 7, 1, 0, 12 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "DateOfBirth", "Discriminator", "Email", "Gender", "IsActivated", "IsBlocked", "LoginType", "Name", "ParentName", "Password", "Phone", "Surname", "Token", "Username", "DoctorId" },
                values: new object[] { "kristina", "Sime Milosevica, 9", "Novi Sad", "Serbia", new DateTime(1999, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", "sdjfsj@gmail.com", "female", true, false, 0, "Kristina", "Zoran", "kristinica", "019919195191", "Tamindzija", new Guid("601ccaa8-3a07-4a7c-89b9-9923e6bac8a7"), "kristina", null });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "PatientId", "BloodType", "DoctorId", "Height", "PersonalId", "Profession", "Weight" },
                values: new object[,]
                {
                    { "kristina", 6, "nelex", 186, "1209222129123", "Professor", 90 },
                    { "imbiamba", 4, "nelex", 186, "1209001129123", "Professor", 90 }
                });

            migrationBuilder.InsertData(
                table: "PatientAllergens",
                columns: new[] { "PatientId", "AllergenId" },
                values: new object[] { "imbiamba", 1 });

            migrationBuilder.InsertData(
                table: "RoomGraphics",
                columns: new[] { "Id", "DoorPosition", "FloorGraphicId", "RoomId", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 17, "right", 3, 17, 100, 100, 0, 0 },
                    { 15, "none", 2, 15, 100, 140, 10, 220 },
                    { 14, "top", 2, 14, 80, 150, 150, 517 },
                    { 13, "top", 2, 13, 80, 150, 0, 517 },
                    { 12, "left", 2, 12, 145, 75, 222, 340 },
                    { 11, "right", 2, 11, 145, 75, 0, 340 },
                    { 10, "left", 2, 10, 100, 100, 197, 100 },
                    { 8, "left", 2, 8, 100, 100, 197, 0 },
                    { 7, "right", 2, 7, 100, 100, 0, 0 },
                    { 6, "none", 1, 6, 160, 140, 150, 20 },
                    { 5, "top", 1, 5, 80, 150, 150, 517 },
                    { 4, "top", 1, 4, 80, 150, 0, 517 },
                    { 3, "left", 1, 3, 145, 75, 222, 340 },
                    { 2, "right", 1, 2, 145, 75, 0, 340 },
                    { 1, "right", 1, 1, 100, 100, 0, 100 },
                    { 9, "right", 2, 9, 100, 100, 0, 100 },
                    { 16, "right", 1, 16, 100, 100, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "PatientId", "SubmissionDate", "VisitId" },
                values: new object[] { -1, "imbiamba", new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "Id", "DoctorId", "EndTime", "IsCanceled", "IsReviewed", "PatientId", "StartTime", "VisitType" },
                values: new object[] { -1, "nelex", new DateTime(2021, 11, 30, 19, 30, 0, 0, DateTimeKind.Unspecified), false, false, "imbiamba", new DateTime(2021, 11, 30, 19, 0, 0, 0, DateTimeKind.Unspecified), 0 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorVacations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ExteriorGraphic");

            migrationBuilder.DropTable(
                name: "MedicalPermits");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "OnCallShifts");

            migrationBuilder.DropTable(
                name: "PatientAllergens");

            migrationBuilder.DropTable(
                name: "PatientFeedbacks");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "RoomEquipments");

            migrationBuilder.DropTable(
                name: "RoomGraphics");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "TermOfRelocationEquipments");

            migrationBuilder.DropTable(
                name: "TermOfRenovations");

            migrationBuilder.DropTable(
                name: "Visits");

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
