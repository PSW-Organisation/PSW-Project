﻿// <auto-generated />
using System;
using IntegrationLibrary.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    [Migration("20220110190410_newMig")]
    partial class newMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IntegrationLibrary.Parnership.Model.MedicineBenefit", b =>
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

            modelBuilder.Entity("IntegrationLibrary.Parnership.Model.MedicineTransaction", b =>
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

            modelBuilder.Entity("IntegrationLibrary.Pharmacies.Model.Complaint", b =>
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

            modelBuilder.Entity("IntegrationLibrary.Pharmacies.Model.Pharmacy", b =>
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

            modelBuilder.Entity("IntegrationLibrary.Pharmacies.Model.ResponseToComplaint", b =>
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

            modelBuilder.Entity("IntegrationLibrary.SharedModel.Model.NotificationsForApp", b =>
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

            modelBuilder.Entity("IntegrationLibrary.Tendering.Model.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApiKeyPharmacy")
                        .HasColumnType("text");

                    b.Property<bool>("Open")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TenderCloseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TenderOpenDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("IntegrationLibrary.Tendering.Model.TenderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("TenderId")
                        .HasColumnType("integer");

                    b.Property<string>("TenderItemName")
                        .HasColumnType("text");

                    b.Property<double>("TenderItemPrice")
                        .HasColumnType("double precision");

                    b.Property<int>("TenderItemQuantity")
                        .HasColumnType("integer");

                    b.Property<int?>("TenderResponseId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TenderId");

                    b.HasIndex("TenderResponseId");

                    b.ToTable("TenderItems");
                });

            modelBuilder.Entity("IntegrationLibrary.Tendering.Model.TenderResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsWinner")
                        .HasColumnType("boolean");

                    b.Property<string>("PharmacyApiKey")
                        .HasColumnType("text");

                    b.Property<int>("PharmacyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ResponseReceivedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TenderId")
                        .HasColumnType("integer");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId");

                    b.HasIndex("TenderId");

                    b.ToTable("TenderResponses");
                });

            modelBuilder.Entity("IntegrationLibrary.Tendering.Model.TenderItem", b =>
                {
                    b.HasOne("IntegrationLibrary.Tendering.Model.Tender", null)
                        .WithMany("TenderItems")
                        .HasForeignKey("TenderId");

                    b.HasOne("IntegrationLibrary.Tendering.Model.TenderResponse", null)
                        .WithMany("TenderItems")
                        .HasForeignKey("TenderResponseId");
                });

            modelBuilder.Entity("IntegrationLibrary.Tendering.Model.TenderResponse", b =>
                {
                    b.HasOne("IntegrationLibrary.Pharmacies.Model.Pharmacy", "Pharmacy")
                        .WithMany()
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntegrationLibrary.Tendering.Model.Tender", "Tender")
                        .WithMany("TenderResponses")
                        .HasForeignKey("TenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
