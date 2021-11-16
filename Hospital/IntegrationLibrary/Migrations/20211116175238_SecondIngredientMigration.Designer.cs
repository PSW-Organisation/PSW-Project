﻿// <auto-generated />
using System;
using System.Collections.Generic;
using IntegrationLibrary.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    [Migration("20211116175238_SecondIngredientMigration")]
    partial class SecondIngredientMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IntegrationLibrary.Model.Complaint", b =>
                {
                    b.Property<long>("ComplaintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("PharmacyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ComplaintId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.Medicine", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("MedicineAmmount")
                        .HasColumnType("integer");

                    b.Property<List<string>>("MedicineIngredient")
                        .HasColumnType("text[]");

                    b.Property<int>("MedicineStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.MedicineIngredient", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.MedicineTransaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("MedicineAmmount")
                        .HasColumnType("integer");

                    b.Property<string>("MedicineId")
                        .HasColumnType("text");

                    b.Property<DateTime>("TransactionTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("MedicineTransactions");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.Pharmacy", b =>
                {
                    b.Property<long>("PharmacyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HospitalApiKey")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyAddress")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyApiKey")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyUrl")
                        .HasColumnType("text");

                    b.HasKey("PharmacyId");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.ResponseToComplaint", b =>
                {
                    b.Property<long>("ResponseToComplaintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("ComplaintId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ResponseToComplaintId");

                    b.ToTable("ResponseToComplaint");
                });
#pragma warning restore 612, 618
        }
    }
}
