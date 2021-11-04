﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PharmacyAPI;

namespace PharmacyAPI.Migrations
{
    [DbContext(typeof(PharmacyDbContext))]
    [Migration("20211108120944_FirstSprint")]
    partial class FirstSprint
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