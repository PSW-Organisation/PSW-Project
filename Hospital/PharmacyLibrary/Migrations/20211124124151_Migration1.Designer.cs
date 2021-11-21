﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PharmacyAPI;

namespace PharmacyLibrary.Migrations
{
    [DbContext(typeof(PharmacyDbContext))]
    [Migration("20211124124151_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PharmacyAPI.Model.Complaint", b =>
                {
                    b.Property<long>("ComplaintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("HospitalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ComplaintId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("PharmacyAPI.Model.Hospital", b =>
                {
                    b.Property<long>("HospitalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HospitalAddress")
                        .HasColumnType("text");

                    b.Property<string>("HospitalApiKey")
                        .HasColumnType("text");

                    b.Property<string>("HospitalName")
                        .HasColumnType("text");

                    b.Property<string>("HospitalUrl")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyApiKey")
                        .HasColumnType("text");

                    b.HasKey("HospitalId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("PharmacyAPI.Model.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<List<string>>("Ingredients")
                        .HasColumnType("text[]");

                    b.Property<int>("MedicineStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<List<string>>("SideEffects")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("UseFor")
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("PharmacyAPI.Model.ResponseToComplaint", b =>
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

                    b.ToTable("ResponsesToComplaint");
                });

            modelBuilder.Entity("PharmacyAPI.Pharmacy", b =>
                {
                    b.Property<long>("PharmacyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
#pragma warning restore 612, 618
        }
    }
}
