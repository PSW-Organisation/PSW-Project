﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ehealthcare.Model;

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.ExteriorGraphic", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<string>("IdElement")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<double>("Width")
                        .HasColumnType("double precision");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Y")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("ExteriorGraphic");

                    b.HasData(
                        new
                        {
                            Id = "0",
                            Height = 200.0,
                            IdElement = "0",
                            Name = "ZGR1",
                            Type = "building",
                            Width = 100.0,
                            X = 180.0,
                            Y = 30.0
                        },
                        new
                        {
                            Id = "1",
                            Height = 110.0,
                            IdElement = "1",
                            Name = "ZGR2",
                            Type = "building",
                            Width = 180.0,
                            X = 380.0,
                            Y = 120.0
                        },
                        new
                        {
                            Id = "2",
                            Height = 50.0,
                            IdElement = "-1",
                            Name = "",
                            Type = "road",
                            Width = 600.0,
                            X = 0.0,
                            Y = 250.0
                        },
                        new
                        {
                            Id = "3",
                            Height = 110.0,
                            IdElement = "-1",
                            Name = "",
                            Type = "road",
                            Width = 50.0,
                            X = 0.0,
                            Y = 290.0
                        },
                        new
                        {
                            Id = "4",
                            Height = 400.0,
                            IdElement = "-1",
                            Name = "",
                            Type = "road",
                            Width = 50.0,
                            X = 305.0,
                            Y = 0.0
                        },
                        new
                        {
                            Id = "5",
                            Height = 80.0,
                            IdElement = "-1",
                            Name = "P",
                            Type = "parking",
                            Width = 50.0,
                            X = 245.0,
                            Y = 310.0
                        },
                        new
                        {
                            Id = "6",
                            Height = 80.0,
                            IdElement = "-1",
                            Name = "P",
                            Type = "parking",
                            Width = 50.0,
                            X = 380.0,
                            Y = 20.0
                        });
                });

            modelBuilder.Entity("ehealthcare.Model.PatientFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Anonymous")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<string>("PatientUsername")
                        .HasColumnType("text");

                    b.Property<bool>("PublishAllowed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PatientFeedbacks");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Anonymous = false,
                            IsPublished = false,
                            PatientUsername = "p1",
                            PublishAllowed = false,
                            SubmissionDate = new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "alallalal"
                        });
                });

            modelBuilder.Entity("ehealthcare.Model.Room", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRenovated")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("IsRenovatedUntill")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("NumOfTakenBeds")
                        .HasColumnType("integer");

                    b.Property<int>("RoomType")
                        .HasColumnType("integer");

                    b.Property<string>("Sector")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ehealthcare.Model.RoomGraphic", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("DoorPosition")
                        .HasColumnType("text");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("RoomRefId")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<double>("Width")
                        .HasColumnType("double precision");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Y")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("RoomRefId");

                    b.ToTable("RoomGraphics");

                    b.HasData(
                        new
                        {
                            Id = "0",
                            DoorPosition = "right",
                            Floor = 0,
                            Height = 100.0,
                            Name = "S1",
                            Type = "Salter",
                            Width = 100.0,
                            X = 0.0,
                            Y = 0.0
                        });
                });

            modelBuilder.Entity("ehealthcare.Model.RoomGraphic", b =>
                {
                    b.HasOne("ehealthcare.Model.Room", "RoomRef")
                        .WithMany()
                        .HasForeignKey("RoomRefId");
                });
#pragma warning restore 612, 618
        }
    }
}
