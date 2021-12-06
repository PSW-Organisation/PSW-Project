﻿// <auto-generated />
using System;
using IntegrationLibrary.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    partial class IntegrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IntegrationLibrary.Model.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("PharmacyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.MedicineBenefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MedicineBenefitContent")
                        .HasColumnType("text");

                    b.Property<DateTime>("MedicineBenefitDueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("MedicineBenefitTitle")
                        .HasColumnType("text");

                    b.Property<int>("MedicineId")
                        .HasColumnType("integer");

                    b.Property<bool>("Published")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.MedicineTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MedicineAmmount")
                        .HasColumnType("integer");

                    b.Property<int>("MedicineId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TransactionTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("MedicineTransactions");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.NotificationsForApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Seen")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.Pharmacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("HospitalApiKey")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyAddress")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyApiKey")
                        .HasColumnType("text");

                    b.Property<int>("PharmacyCommunicationType")
                        .HasColumnType("integer");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyUrl")
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("IntegrationLibrary.Model.ResponseToComplaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("ComplaintId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ResponseToComplaint");
                });
#pragma warning restore 612, 618
        }
    }
}
