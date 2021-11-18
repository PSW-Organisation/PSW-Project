using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.Model;
using System.Linq;

namespace ehealthcare.Model
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalPermit> MedicalPermits { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<RoomGraphic> RoomGraphics { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<FloorGraphic> FloorGraphics { get; set; }

        public DbSet<PatientAllergen> PatientAllergens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ExteriorGraphic> ExteriorGraphic { get; set; }
        public DbSet<TermOfRelocationEquipment> TermOfRelocationEquipments { get; set; }

        public DbSet<RoomEquipment> RoomEquipments { get; set; }


        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected HospitalDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Allergen>(a =>
            {
                a.HasData(new Allergen()
                {
                    Id = "1",
                    Type = "macija dlaka",

                });
            });

            modelBuilder.Entity<RoomEquipment>().HasData(
                new
                {
                    Id = 1,
                    Name = "Bed",
                    Quantity = 2,
                    Type = "Static",
                    RoomId = 1
                },
                new
                {
                    Id = 2,
                    Name = "Needle",
                    Quantity = 200,
                    Type = "Dynamic",
                    RoomId = 2
                },
                new
                {
                    Id = 3,
                    Name = "Needle",
                    Quantity = 300,
                    Type = "Dynamic",
                    RoomId = 3
                }


                );
            modelBuilder.Entity<PatientFeedback>().HasData(
                new
                {
                    Id = -1,
                    PatientUsername = "p1",
                    SubmissionDate = new DateTime(2021, 11, 4),
                    Text = "alallalal",
                    Anonymous = false,
                    PublishAllowed = false,
                    IsPublished = false
                });


            modelBuilder.Entity<Room>().HasData(
                new
                {
                    Id = 16,
                    Name = "Counter 1",
                    Floor = 0,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.counter,
                    Sector = "CS"
                },
                new
                {
                    Id = 1,
                    Name = "Counter 2",
                    Floor = 0,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.counter,
                    Sector = "CS"
                },
                new
                {
                    Id = 2,
                    Name = "Examination room 1",
                    Floor = 0,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 1,
                    RoomType = RoomType.examination,
                    Sector = "ES"
                },
                new
                {
                    Id = 3,
                    Name = "Examination room 2",
                    Floor = 0,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 1,
                    RoomType = RoomType.examination,
                    Sector = "ES"
                },
                new
                {
                    Id = 4,
                    Name = "Restroom 1",
                    Floor = 0,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.restroom,
                    Sector = "RRS"
                },
                new
                {
                    Id = 5,
                    Name = "Restroom 2",
                    Floor = 0,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.restroom,
                    Sector = "RRS"
                },
                new
                {
                    Id = 6,
                    Name = "Waiting room 1",
                    Floor = 0,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.waitingRoom,
                    Sector = "WS"
                }, new
                {
                    Id = 7,
                    Name = "Operation room 1",
                    Floor = 1,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.operation,
                    Sector = "OS"
                },
                new
                {
                    Id = 8,
                    Name = "Operation room 2",
                    Floor = 1,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.operation,
                    Sector = "OS"
                },
                new
                {
                    Id = 9,
                    Name = "Operation room 3",
                    Floor = 1,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.operation,
                    Sector = "OS"
                },
                new
                {
                    Id = 10,
                    Name = "Operation room 4",
                    Floor = 1,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.operation,
                    Sector = "OS"
                },
                new
                {
                    Id = 11,
                    Name = "Examination room 3",
                    Floor = 1,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.examination,
                    Sector = "ES"
                },
                new
                {
                    Id = 12,
                    Name = "Examination room 4",
                    Floor = 1,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.examination,
                    Sector = "ES"
                },
                new
                {
                    Id = 13,
                    Name = "Restroom 3",
                    Floor = 1,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.restroom,
                    Sector = "RRS"
                },
                new
                {
                    Id = 14,
                    Name = "Restroom 4",
                    Floor = 1,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.restroom,
                    Sector = "RRS"
                },
                new
                {
                    Id = 15,
                    Name = "Waiting room 2",
                    Floor = 1,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.waitingRoom,
                    Sector = "WS"
                }

            );

            modelBuilder.Entity<FloorGraphic>(fg =>
            {
                fg.HasData(new FloorGraphic
                {
                    Id = 1,
                    Floor = 0,
                    BuildingId = 0

                });
                fg.OwnsMany(e => e.RoomGraphics).HasData(new
                {
                    Id = 16,
                    DoorPosition = "right",
                    Width = 100,
                    Height = 100,
                    X = 0,
                    Y = 0,
                    FloorGraphicId = 1,
                    RoomId = 16
                }, new
                {
                    Id = 1,
                    DoorPosition = "right",
                    Width = 100,
                    Height = 100,
                    X = 0,
                    Y = 100,
                    FloorGraphicId = 1,
                    RoomId = 1
                }, new
                {
                    Id = 2,
                    DoorPosition = "right",
                    Width = 75,
                    Height = 145,
                    X = 0,
                    Y = 340,
                    FloorGraphicId = 1,
                    RoomId = 2
                }, new
                {
                    Id = 3,
                    DoorPosition = "left",
                    Width = 75,
                    Height = 145,
                    X = 222,
                    Y = 340,
                    FloorGraphicId = 1,
                    RoomId = 3
                }, new
                {
                    Id = 4,
                    DoorPosition = "top",
                    Width = 147,
                    Height = 80,
                    X = 0,
                    Y = 517,
                    FloorGraphicId = 1,
                    RoomId = 4
                }, new
                {
                    Id = 5,
                    DoorPosition = "top",
                    Width = 147,
                    Height = 80,
                    X = 150,
                    Y = 517,
                    FloorGraphicId = 1,
                    RoomId = 5
                }, new
                {
                    Id = 6,
                    DoorPosition = "none",
                    Width = 140,
                    Height = 160,
                    X = 150,
                    Y = 20,
                    FloorGraphicId = 1,
                    RoomId = 6
                });
            });

            modelBuilder.Entity<FloorGraphic>(fg =>
            {
                fg.HasData(new FloorGraphic
                {
                    Id = 2,
                    Floor = 1,
                    BuildingId = 0

                });
                fg.OwnsMany(e => e.RoomGraphics).HasData(new
                {
                    Id = 7,
                    DoorPosition = "right",
                    Width = 100,
                    Height = 100,
                    X = 0,
                    Y = 0,
                    FloorGraphicId = 2,
                    RoomId = 7
                }, new
                {
                    Id = 8,
                    DoorPosition = "left",
                    Width = 100,
                    Height = 100,
                    X = 197,
                    Y = 0,
                    FloorGraphicId = 2,
                    RoomId = 8
                }, new
                {
                    Id = 9,
                    DoorPosition = "right",
                    Width = 100,
                    Height = 100,
                    X = 0,
                    Y = 100,
                    FloorGraphicId = 2,
                    RoomId = 9
                }, new
                {
                    Id = 10,
                    DoorPosition = "left",
                    Width = 100,
                    Height = 100,
                    X = 197,
                    Y = 100,
                    FloorGraphicId = 2,
                    RoomId = 10
                }, new
                {
                    Id = 11,
                    DoorPosition = "right",
                    Width = 75,
                    Height = 145,
                    X = 0,
                    Y = 340,
                    FloorGraphicId = 2,
                    RoomId = 11
                }, new
                {
                    Id = 12,
                    DoorPosition = "left",
                    Width = 75,
                    Height = 145,
                    X = 222,
                    Y = 340,
                    FloorGraphicId = 2,
                    RoomId = 12
                }, new
                {
                    Id = 13,
                    DoorPosition = "top",
                    Width = 147,
                    Height = 80,
                    X = 0,
                    Y = 517,
                    FloorGraphicId = 2,
                    RoomId = 13
                }, new
                {
                    Id = 14,
                    DoorPosition = "top",
                    Width = 147,
                    Height = 80,
                    X = 150,
                    Y = 517,
                    FloorGraphicId = 2,
                    RoomId = 14
                }, new
                {
                    Id = 15,
                    DoorPosition = "none",
                    Width = 140,
                    Height = 100,
                    X = 10,
                    Y = 220,
                    FloorGraphicId = 2,
                    RoomId = 15
                });
            });


            modelBuilder.Entity<TermOfRelocationEquipment>().HasData(
                new TermOfRelocationEquipment()
                {
                    Id = 1,
                    IdSourceRoom = 7,
                    IdDestinationRoom = 8,
                    NameOfEquipment = "bed",
                    QuantityOfEquipment = 2,
                    StartTime = new DateTime(2021, 11, 22, 1, 0, 0),
                    EndTime = new DateTime(2021, 11, 22, 1, 10, 0),
                    durationInMinutes = 10,
                    FinishedRelocation = false
                },
                new TermOfRelocationEquipment()
                {
                    Id = 2,
                    IdSourceRoom = 7,
                    IdDestinationRoom = 9,
                    NameOfEquipment = "needle",
                    QuantityOfEquipment = 14,
                    StartTime = new DateTime(2021, 11, 22, 3, 30, 0),
                    EndTime = new DateTime(2021, 11, 22, 4, 10, 0),
                    durationInMinutes = 40,
                    FinishedRelocation = false
                },
                new TermOfRelocationEquipment()
                {
                    Id = 3,
                    IdSourceRoom = 8,
                    IdDestinationRoom = 9,
                    NameOfEquipment = "infusion",
                    QuantityOfEquipment = 8,
                    StartTime = new DateTime(2021, 11, 23, 7, 30, 0),
                    EndTime = new DateTime(2021, 11, 23, 7, 45, 0),
                    durationInMinutes = 15,
                    FinishedRelocation = false
                },
                new TermOfRelocationEquipment()
                {
                    Id = 4,
                    IdSourceRoom = 9,
                    IdDestinationRoom = 11,
                    NameOfEquipment = "table",
                    QuantityOfEquipment = 1,
                    StartTime = new DateTime(2021, 11, 23, 9, 0, 0),
                    EndTime = new DateTime(2021, 11, 23, 9, 25, 0),
                    durationInMinutes = 25,
                    FinishedRelocation = false
                },
                new TermOfRelocationEquipment()
                {
                    Id = 5,
                    IdSourceRoom = 10,
                    IdDestinationRoom = 7,
                    NameOfEquipment = "xrayMachine",
                    QuantityOfEquipment = 1,
                    StartTime = new DateTime(2021, 11, 23, 10, 45, 0),
                    EndTime = new DateTime(2021, 11, 23, 11, 15, 0),
                    durationInMinutes = 30,
                    FinishedRelocation = false
                },
                new TermOfRelocationEquipment()
                {
                    Id = 6,
                    IdSourceRoom = 10,
                    IdDestinationRoom = 11,
                    NameOfEquipment = "chair",
                    QuantityOfEquipment = 5,
                    StartTime = new DateTime(2021, 11, 23, 14, 30, 0),
                    EndTime = new DateTime(2021, 11, 23, 14, 50, 0),
                    durationInMinutes = 20,
                    FinishedRelocation = false
                }



            );

            modelBuilder.Entity<ExteriorGraphic>().HasData(
            new ExteriorGraphic()
            {
                Id = 1,
                X = 180,
                Y = 30,
                Width = 100,
                Height = 200,
                Name = "ZGR1",
                Type = "building",
                IdElement = 0
            },
            new ExteriorGraphic()
            {
                Id = 2,
                X = 380,
                Y = 120,
                Width = 180,
                Height = 110,
                Name = "ZGR2",
                Type = "building",
                IdElement = 1
            },
            new ExteriorGraphic()
            {
                Id = 7,
                X = 0,
                Y = 250,
                Width = 600,
                Height = 50,
                Name = "",
                Type = "road",
                IdElement = -1
            },
            new ExteriorGraphic()
            {
                Id = 3,
                X = 0,
                Y = 290,
                Width = 50,
                Height = 110,
                Name = "",
                Type = "road",
                IdElement = -1
            },
            new ExteriorGraphic()
            {
                Id = 4,
                X = 305,
                Y = 0,
                Width = 50,
                Height = 400,
                Name = "",
                Type = "road",
                IdElement = -1
            },
            new ExteriorGraphic()
            {
                Id = 5,
                X = 245,
                Y = 310,
                Width = 50,
                Height = 80,
                Name = "P",
                Type = "parking",
                IdElement = -1
            },
            new ExteriorGraphic()
            {
                Id = 6,
                X = 380,
                Y = 20,
                Width = 50,
                Height = 80,
                Name = "P",
                Type = "parking",
                IdElement = -1
            }
            );



            modelBuilder.Entity<MedicalRecord>(m =>
            {
                m.HasData(
                  new MedicalRecord
                  {
                      PersonalId = "1209001129123",
                      BloodType = 1,
                      Height = 186,
                      Weight = 90,
                      Profession = "Professor",
                      DoctorId = "1",
                      PatientId = "imbiamba"
                  });

            });


            modelBuilder.Entity<PatientAllergen>(a =>
            {
                a.HasData(new PatientAllergen()
                {
                    Id = 1,
                    MedicalRecordId = 1,
                    AllergenId = 1

                });
            });


            modelBuilder.Entity<Patient>(p =>
            {
                p.HasData(
                    new Patient
                    {
                        Id = "imbiamba",
                        Name = "Marko",
                        Surname = "Ilic",
                        ParentName = "Milan",
                        Username = "imbiamba",
                        Password = "pecurkaa",
                        LoginType = LoginType.patient,
                        Gender = "male",
                        DateOfBirth = new DateTime(2001, 11, 9),
                        Phone = "019919199191",
                        Email = "markoilic@gmail.com",
                        AddressId = 1,
                        IsBlocked = false,
                        IsActivated = false,
                        MedicalRecordId = 1
                    });
            });




            modelBuilder.Entity<Doctor>(d =>
            {

                d.HasData(
                    new Doctor
                    {
                        Id = "nelex",
                        Name = "Nemanja",
                        Surname = "Radojcic",
                        ParentName = "Zoran",
                        Username = "nelex",
                        Password = "najjacapecurka",
                        LoginType = LoginType.doctor,
                        Gender = "male",
                        DateOfBirth = new DateTime(1999, 7, 14),
                        Phone = "019919199191",
                        Email = "nemanjar@gmail.com",
                        HomeAddress = "Sime Milutinovica, 2",
                        City = "Novi Sad",
                        Country = "Serbia",
                        IsBlocked = false,
                        IsActivated = false,
                        UsedOffDays = 12,
                        Specialization = 0,
                    });
            });




           
           

            modelBuilder.Entity<PatientFeedback>().HasData(new PatientFeedback()
            {
                Id = 1,
                PatientUsername = "imbiamba",
                SubmissionDate = new DateTime(2021, 11, 4),
                Text = "alallalal",
                Anonymous = false,
                PublishAllowed = false,
                IsPublished = false
            });


        }
    }
}