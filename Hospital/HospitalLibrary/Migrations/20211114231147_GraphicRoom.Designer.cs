﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ehealthcare.Model;

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20211114231147_GraphicRoom")]
    partial class GraphicRoom
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.FloorGraphic", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BuildingId")
                        .HasColumnType("text");

                    b.Property<long>("Floor")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("FloorGraphics");

                    b.HasData(
                        new
                        {
                            Id = "0",
                            BuildingId = "0",
                            Floor = 0L
                        },
                        new
                        {
                            Id = "1",
                            BuildingId = "0",
                            Floor = 1L
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

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NumOfTakenBeds")
                        .HasColumnType("integer");

                    b.Property<int>("RoomType")
                        .HasColumnType("integer");

                    b.Property<string>("Sector")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = "0",
                            Floor = 0,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Counter 1",
                            NumOfTakenBeds = 0,
                            RoomType = 4,
                            Sector = "CS"
                        },
                        new
                        {
                            Id = "1",
                            Floor = 0,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Counter 2",
                            NumOfTakenBeds = 0,
                            RoomType = 4,
                            Sector = "CS"
                        },
                        new
                        {
                            Id = "2",
                            Floor = 0,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Examination room 1",
                            NumOfTakenBeds = 1,
                            RoomType = 0,
                            Sector = "ES"
                        },
                        new
                        {
                            Id = "3",
                            Floor = 0,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Examination room 2",
                            NumOfTakenBeds = 1,
                            RoomType = 0,
                            Sector = "ES"
                        },
                        new
                        {
                            Id = "4",
                            Floor = 0,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Restroom 1",
                            NumOfTakenBeds = 0,
                            RoomType = 3,
                            Sector = "RRS"
                        },
                        new
                        {
                            Id = "5",
                            Floor = 0,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Restroom 2",
                            NumOfTakenBeds = 0,
                            RoomType = 3,
                            Sector = "RRS"
                        },
                        new
                        {
                            Id = "6",
                            Floor = 0,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Waiting room 1",
                            NumOfTakenBeds = 0,
                            RoomType = 5,
                            Sector = "WS"
                        },
                        new
                        {
                            Id = "7",
                            Floor = 1,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Operation room 1",
                            NumOfTakenBeds = 0,
                            RoomType = 1,
                            Sector = "OS"
                        },
                        new
                        {
                            Id = "8",
                            Floor = 1,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Operation room 2",
                            NumOfTakenBeds = 0,
                            RoomType = 1,
                            Sector = "OS"
                        },
                        new
                        {
                            Id = "9",
                            Floor = 1,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Operation room 3",
                            NumOfTakenBeds = 0,
                            RoomType = 1,
                            Sector = "OS"
                        },
                        new
                        {
                            Id = "10",
                            Floor = 1,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Operation room 4",
                            NumOfTakenBeds = 0,
                            RoomType = 1,
                            Sector = "OS"
                        },
                        new
                        {
                            Id = "11",
                            Floor = 1,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Examination room 3",
                            NumOfTakenBeds = 0,
                            RoomType = 0,
                            Sector = "ES"
                        },
                        new
                        {
                            Id = "12",
                            Floor = 1,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Examination room 4",
                            NumOfTakenBeds = 0,
                            RoomType = 0,
                            Sector = "ES"
                        },
                        new
                        {
                            Id = "13",
                            Floor = 1,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Restroom 3",
                            NumOfTakenBeds = 0,
                            RoomType = 3,
                            Sector = "RRS"
                        },
                        new
                        {
                            Id = "14",
                            Floor = 1,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Restroom 4",
                            NumOfTakenBeds = 0,
                            RoomType = 3,
                            Sector = "RRS"
                        },
                        new
                        {
                            Id = "15",
                            Floor = 1,
                            IsRenovated = false,
                            IsRenovatedUntill = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Waiting room 2",
                            NumOfTakenBeds = 0,
                            RoomType = 5,
                            Sector = "WS"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.FloorGraphic", b =>
                {
                    b.OwnsMany("ehealthcare.Model.RoomGraphic", "RoomGraphics", b1 =>
                        {
                            b1.Property<string>("FloorGraphicId")
                                .HasColumnType("text");

                            b1.Property<string>("Id")
                                .HasColumnType("text");

                            b1.Property<string>("DoorPosition")
                                .HasColumnType("text");

                            b1.Property<int>("Height")
                                .HasColumnType("integer");

                            b1.Property<string>("RoomId")
                                .HasColumnType("text");

                            b1.Property<int>("Width")
                                .HasColumnType("integer");

                            b1.Property<int>("X")
                                .HasColumnType("integer");

                            b1.Property<int>("Y")
                                .HasColumnType("integer");

                            b1.HasKey("FloorGraphicId", "Id");

                            b1.HasIndex("RoomId");

                            b1.ToTable("RoomGraphics");

                            b1.WithOwner()
                                .HasForeignKey("FloorGraphicId");

                            b1.HasOne("ehealthcare.Model.Room", "Room")
                                .WithMany()
                                .HasForeignKey("RoomId");

                            b1.HasData(
                                new
                                {
                                    FloorGraphicId = "0",
                                    Id = "0",
                                    DoorPosition = "right",
                                    Height = 100,
                                    RoomId = "0",
                                    Width = 100,
                                    X = 0,
                                    Y = 0
                                },
                                new
                                {
                                    FloorGraphicId = "0",
                                    Id = "1",
                                    DoorPosition = "right",
                                    Height = 100,
                                    RoomId = "1",
                                    Width = 100,
                                    X = 0,
                                    Y = 100
                                },
                                new
                                {
                                    FloorGraphicId = "0",
                                    Id = "2",
                                    DoorPosition = "right",
                                    Height = 145,
                                    RoomId = "2",
                                    Width = 75,
                                    X = 0,
                                    Y = 340
                                },
                                new
                                {
                                    FloorGraphicId = "0",
                                    Id = "3",
                                    DoorPosition = "left",
                                    Height = 145,
                                    RoomId = "3",
                                    Width = 75,
                                    X = 222,
                                    Y = 340
                                },
                                new
                                {
                                    FloorGraphicId = "0",
                                    Id = "4",
                                    DoorPosition = "top",
                                    Height = 80,
                                    RoomId = "4",
                                    Width = 147,
                                    X = 0,
                                    Y = 517
                                },
                                new
                                {
                                    FloorGraphicId = "0",
                                    Id = "5",
                                    DoorPosition = "top",
                                    Height = 80,
                                    RoomId = "5",
                                    Width = 147,
                                    X = 150,
                                    Y = 517
                                },
                                new
                                {
                                    FloorGraphicId = "0",
                                    Id = "6",
                                    DoorPosition = "none",
                                    Height = 160,
                                    RoomId = "6",
                                    Width = 140,
                                    X = 150,
                                    Y = 20
                                },
                                new
                                {
                                    FloorGraphicId = "1",
                                    Id = "7",
                                    DoorPosition = "right",
                                    Height = 100,
                                    RoomId = "7",
                                    Width = 100,
                                    X = 0,
                                    Y = 0
                                },
                                new
                                {
                                    FloorGraphicId = "1",
                                    Id = "8",
                                    DoorPosition = "left",
                                    Height = 100,
                                    RoomId = "8",
                                    Width = 100,
                                    X = 197,
                                    Y = 0
                                },
                                new
                                {
                                    FloorGraphicId = "1",
                                    Id = "9",
                                    DoorPosition = "right",
                                    Height = 100,
                                    RoomId = "9",
                                    Width = 100,
                                    X = 0,
                                    Y = 100
                                },
                                new
                                {
                                    FloorGraphicId = "1",
                                    Id = "10",
                                    DoorPosition = "left",
                                    Height = 100,
                                    RoomId = "10",
                                    Width = 100,
                                    X = 197,
                                    Y = 100
                                },
                                new
                                {
                                    FloorGraphicId = "1",
                                    Id = "11",
                                    DoorPosition = "right",
                                    Height = 145,
                                    RoomId = "11",
                                    Width = 75,
                                    X = 0,
                                    Y = 340
                                },
                                new
                                {
                                    FloorGraphicId = "1",
                                    Id = "12",
                                    DoorPosition = "left",
                                    Height = 145,
                                    RoomId = "12",
                                    Width = 75,
                                    X = 222,
                                    Y = 340
                                },
                                new
                                {
                                    FloorGraphicId = "1",
                                    Id = "13",
                                    DoorPosition = "top",
                                    Height = 80,
                                    RoomId = "13",
                                    Width = 147,
                                    X = 0,
                                    Y = 517
                                },
                                new
                                {
                                    FloorGraphicId = "1",
                                    Id = "14",
                                    DoorPosition = "top",
                                    Height = 80,
                                    RoomId = "14",
                                    Width = 147,
                                    X = 150,
                                    Y = 517
                                },
                                new
                                {
                                    FloorGraphicId = "1",
                                    Id = "15",
                                    DoorPosition = "none",
                                    Height = 100,
                                    RoomId = "15",
                                    Width = 140,
                                    X = 10,
                                    Y = 220
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
