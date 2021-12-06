﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace IntegrationLibrary.Migrations
{
    public partial class newMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "Benefits",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                 MedicineBenefitTitle = table.Column<string>(nullable: true),
                 MedicineBenefitContent = table.Column<string>(nullable: true),
                 MedicineBenefitDueDate = table.Column<DateTime>(nullable: false),
                 MedicineId = table.Column<int>(nullable: false),
                 Published = table.Column<bool>(nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Benefits", x => x.Id);
             });

            migrationBuilder.CreateTable(
                name: "MedicineTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicineId = table.Column<int>(nullable: false),
                    MedicineAmmount = table.Column<int>(nullable: false),
                    TransactionTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                            name: "Pharmacies",
                            columns: table => new
                            {
                                Id = table.Column<int>(nullable: false)
                                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                PharmacyUrl = table.Column<string>(nullable: true),
                                PharmacyName = table.Column<string>(nullable: true),
                                PharmacyAddress = table.Column<string>(nullable: true),
                                PharmacyApiKey = table.Column<string>(nullable: true),
                                HospitalApiKey = table.Column<string>(nullable: true),
                                Comment = table.Column<string>(nullable: true),
                                Picture = table.Column<string>(nullable: true),
                                PharmacyCommunicationType = table.Column<int>(nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Pharmacies", x => x.Id);
                            });


            migrationBuilder.CreateTable(
              name: "ResponseToComplaint",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  Date = table.Column<DateTime>(nullable: false),
                  Title = table.Column<string>(nullable: true),
                  Content = table.Column<string>(nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_ResponseToComplaint", x => x.Id);
              });



            migrationBuilder.CreateTable(
                   name: "Notifications",
                   columns: table => new
                   {
                       Id = table.Column<int>(nullable: false)
                           .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                       Content = table.Column<string>(nullable: true),
                       Date = table.Column<DateTime>(nullable: false),
                       Seen = table.Column<bool>(nullable: true)
                   },
                   constraints: table =>
                   {
                       table.PrimaryKey("PK_Notifications", x => x.Id);
                   });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}