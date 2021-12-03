﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class MigrationComment : Migration
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
               name: "Ingredients",
               columns: table => new
               {
                   Name = table.Column<string>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Ingredients", x => x.Name);
               });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    MedicineStatus = table.Column<int>(nullable: false),
                    MedicineIngredient = table.Column<List<string>>(nullable: true),
                    MedicineAmmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
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
                    Id = table.Column<long>(nullable: false)
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
                    Comment = table.Column<string>(nullable:true),
                    Picture = table.Column<string>(nullable:true)
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
                       ComplaintId = table.Column<long>(nullable: false),
                       Date = table.Column<DateTime>(nullable: false),
                       Content = table.Column<string>(nullable: true)
                   },
                   constraints: table =>
                   {
                       table.PrimaryKey("PK_ResponseToComplaint", x => x.Id);
                   });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }   
    }
}