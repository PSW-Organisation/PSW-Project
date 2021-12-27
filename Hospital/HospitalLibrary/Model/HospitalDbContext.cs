using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Model;
using System.Linq;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using Microsoft.EntityFrameworkCore;
using System;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;

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
        public DbSet<Visit> Visits { get; set; }
        public DbSet<FloorGraphic> FloorGraphics { get; set; }
        public DbSet<PatientAllergen> PatientAllergens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ExteriorGraphic> ExteriorGraphic { get; set; }
        public DbSet<TermOfRelocationEquipment> TermOfRelocationEquipments { get; set; }
        public DbSet<TermOfRenovation> TermOfRenovations { get; set; }
        public DbSet<RoomEquipment> RoomEquipments { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        //public DbSet<Medicine> Medicines { get; set; }

        public DbSet<MedicinePrescription> Prescriptions { get; set; }
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
                    Id = 1,
                    Name = "macija dlaka",
                });
            });

            #region RoomEquipments

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
                },
                new
                {
                    Id = 4,
                    Name = "Picks",
                    Quantity = 300,
                    Type = "Dynamic",
                    RoomId = 16
                }


                );

            #endregion

            modelBuilder.Entity<PatientFeedback>().HasData(
                new
                {
                    Id = -1,
                    PatientUsername = "imbiamba",
                    SubmissionDate = new DateTime(2021, 11, 4),
                    Text = "Sehr gut!",
                    Anonymous = false,
                    PublishAllowed = true,
                    IsPublished = true
                });

            #region Rooms

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
                },
                new
                {
                    Id = 17,
                    Name = "Waiting room 3",
                    Floor = 0,
                    IsRenovated = false,
                    IsRenovatedUntill = new DateTime(),
                    NumOfTakenBeds = 0,
                    RoomType = RoomType.waitingRoom,
                    Sector = "WS"
                }
            );


            #endregion

            #region FloorGraphicsWithRoomGraphics

            modelBuilder.Entity<FloorGraphic>().HasData(
                new
                {
                    Id = 1,
                    Floor = 0,
                    BuildingId = 0
                }, new
                {
                    Id = 2,
                    Floor = 1,
                    BuildingId = 0
                }, new
                {
                    Id = 3,
                    Floor = 0,
                    BuildingId = 1
                });

            modelBuilder.Entity<RoomGraphic>().HasData(
                new
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
                    Width = 150,
                    Height = 80,
                    X = 0,
                    Y = 517,
                    FloorGraphicId = 1,
                    RoomId = 4
                }, new
                {
                    Id = 5,
                    DoorPosition = "top",
                    Width = 150,
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

            modelBuilder.Entity<RoomGraphic>().HasData(
                new
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
                    Width = 150,
                    Height = 80,
                    X = 0,
                    Y = 517,
                    FloorGraphicId = 2,
                    RoomId = 13
                }, new
                {
                    Id = 14,
                    DoorPosition = "top",
                    Width = 150,
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

            modelBuilder.Entity<RoomGraphic>().HasData(
                new
                {
                    Id = 17,
                    DoorPosition = "right",
                    Width = 100,
                    Height = 100,
                    X = 0,
                    Y = 0,
                    FloorGraphicId = 3,
                    RoomId = 17
                });

            #endregion

            #region TermOfRelocationEquipments

            modelBuilder.Entity<TermOfRelocationEquipment>().HasData(
                new TermOfRelocationEquipment()
                {
                    Id = 1,
                    IdSourceRoom = 7,
                    IdDestinationRoom = 8,
                    NameOfEquipment = "bed",
                    QuantityOfEquipment = 2,
                    Time = new TimeInterval(new DateTime(2021, 11, 22, 1, 0, 0), new DateTime(2021, 11, 22, 1, 10, 0)),
                    DurationInMinutes = 10,
                    RelocationState = StateOfTerm.PENDING
                },
                new TermOfRelocationEquipment()
                {
                    Id = 2,
                    IdSourceRoom = 7,
                    IdDestinationRoom = 9,
                    NameOfEquipment = "needle",
                    QuantityOfEquipment = 14,
                    Time = new TimeInterval(new DateTime(2021, 11, 22, 3, 30, 0), new DateTime(2021, 11, 22, 4, 10, 0)),
                    DurationInMinutes = 40,
                    RelocationState = StateOfTerm.PENDING
                },
                new TermOfRelocationEquipment()
                {
                    Id = 3,
                    IdSourceRoom = 8,
                    IdDestinationRoom = 9,
                    NameOfEquipment = "infusion",
                    QuantityOfEquipment = 8,
                    Time = new TimeInterval(new DateTime(2021, 11, 23, 7, 30, 0), new DateTime(2021, 11, 23, 7, 45, 0)),
                    DurationInMinutes = 15,
                    RelocationState = StateOfTerm.PENDING
                },
                new TermOfRelocationEquipment()
                {
                    Id = 4,
                    IdSourceRoom = 9,
                    IdDestinationRoom = 11,
                    NameOfEquipment = "table",
                    QuantityOfEquipment = 1,
                    Time = new TimeInterval(new DateTime(2021, 11, 23, 9, 0, 0),new DateTime(2021, 11, 23, 9, 25, 0)),
                    DurationInMinutes = 25,
                    RelocationState = StateOfTerm.PENDING
                },
                new TermOfRelocationEquipment()
                {
                    Id = 5,
                    IdSourceRoom = 10,
                    IdDestinationRoom = 7,
                    NameOfEquipment = "xrayMachine",
                    QuantityOfEquipment = 1,
                    Time = new TimeInterval(new DateTime(2021, 11, 23, 10, 45, 0),new DateTime(2021, 11, 23, 11, 15, 0)),
                    DurationInMinutes = 30,
                    RelocationState = StateOfTerm.PENDING
                },
                new TermOfRelocationEquipment()
                {
                    Id = 6,
                    IdSourceRoom = 10,
                    IdDestinationRoom = 11,
                    NameOfEquipment = "chair",
                    QuantityOfEquipment = 5,
                    Time = new TimeInterval(new DateTime(2021, 11, 23, 14, 30, 0), new DateTime(2021, 11, 23, 14, 50, 0)),
                    DurationInMinutes = 20,
                    RelocationState = StateOfTerm.PENDING
                }
            );

            #endregion

            #region TermOfRenovations

            modelBuilder.Entity<TermOfRenovation>().HasData(
                  new TermOfRenovation()
                  {
                      Id = 1,
                      Time = new TimeInterval( new DateTime(2021, 12, 7, 10, 30, 0), new DateTime(2021, 12, 7, 11, 30, 0)),
                      DurationInMinutes = 60,
                      StateOfRenovation = StateOfTerm.CANCELED,
                      TypeOfRenovation = TypeOfRenovation.MERGE,
                      IdRoomA = 1,
                      IdRoomB = 16,
                      EquipmentLogic = EquipmentLogic.ALL_EQUIPMENT_IN_A,
                      NewNameForRoomA = "Operation room 5",
                      NewSectorForRoomA = "OS",
                      NewRoomTypeForRoomA = RoomType.operation,
                      NewNameForRoomB = "",
                      NewSectorForRoomB = "",
                      NewRoomTypeForRoomB = RoomType.waitingRoom,
                  },
                  new TermOfRenovation()
                  {
                      Id = 2,
                      Time = new TimeInterval(new DateTime(2021, 12, 17, 9, 0, 0), new DateTime(2021, 12, 18, 9, 0, 0)),
                      DurationInMinutes = 1440,
                      StateOfRenovation = StateOfTerm.PENDING,
                      TypeOfRenovation = TypeOfRenovation.SPLIT,
                      IdRoomA = 4,
                      IdRoomB = -1,
                      EquipmentLogic = EquipmentLogic.HALF_IN_A_HALF_IN_B,
                      NewNameForRoomA = "Operation room 6",
                      NewSectorForRoomA = "OS",
                      NewRoomTypeForRoomA = RoomType.operation,
                      NewNameForRoomB = "Operation room 7",
                      NewSectorForRoomB = "OS",
                      NewRoomTypeForRoomB = RoomType.operation,
                  }
            );

            #endregion

            #region ExteriorGraphics

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

            #endregion

            modelBuilder.Entity<MedicalRecord>(m =>
            {
                m.HasData(
                  new MedicalRecord
                  {
                      PersonalId = "1209001129123",
                      BloodType = BloodType.AB_positive,
                      Height = 186,
                      Weight = 90,
                      Profession = "Professor",
                      DoctorId = "nelex",
                      PatientId = "imbiamba"
                  },
                  new MedicalRecord
                  {
                      PersonalId = "1209222129123",
                      BloodType = BloodType.O_positive,
                      Height = 186,
                      Weight = 90,
                      Profession = "Professor",
                      DoctorId = "nelex",
                      PatientId = "kristina"
                  });
                // m.HasKey(m => new { m.Id, m.PatientId });

            });

            modelBuilder.Entity<PatientAllergen>(a =>
            {
                a.HasData(new PatientAllergen()
                {
                    PatientId = "imbiamba",
                    AllergenId = 1

                });
                a.HasKey(pa => new { pa.PatientId, pa.AllergenId });
                a.HasOne<Patient>(p => p.Patient).WithMany(p => p.PatientAllergens)
                .HasForeignKey(pa => pa.PatientId);
                a.HasOne<Allergen>(a => a.Allergen).WithMany(p => p.PatientAllergens)
                .HasForeignKey(pa => pa.AllergenId);

            });


            modelBuilder.Entity<Patient>(p =>
            {
                p.HasData(
                    new Patient("imbiamba")
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
                        Address = "Sime Milosevica, 5",
                        IsBlocked = false,
                        IsActivated = false,
                        Token = new Guid("601ccaa8-3a07-4a7c-89b9-9953e6eac8a7"),
                        City = "Novi Sad",
                        Country = "Serbia",
                    },
                    new Patient("kristina")
                    {
                        Id = "kristina",
                        Name = "Kristina",
                        Surname = "Tamindzija",
                        ParentName = "Zoran",
                        Username = "kristina",
                        Password = "kristinica",
                        LoginType = LoginType.patient,
                        Gender = "female",
                        DateOfBirth = new DateTime(1999, 11, 9),
                        Phone = "019919195191",
                        Email = "sdjfsj@gmail.com",
                        Address = "Sime Milosevica, 9",
                        IsBlocked = false,
                        IsActivated = true,
                        Token = new Guid("601ccaa8-3a07-4a7c-89b9-9923e6bac8a7"),
                        City = "Novi Sad",
                        Country = "Serbia",
                    }
                    );
            });

            modelBuilder.Entity<Doctor>(d =>
            {

                d.HasData(
                    new Doctor("nelex")
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
                        Address = "Sime Milutinovica, 2",
                        City = "Novi Sad",
                        Country = "Serbia",
                        IsBlocked = false,
                        IsActivated = false,
                        UsedOffDays = 12,
                        Specialization = Specialization.none,
                        RoomId = 1
                    },
                    new Doctor("mkisic")
                    {
                        Id = "mkisic",
                        Name = "Mihajlo",
                        Surname = "Kisic",
                        ParentName = "Zvezdan",
                        Username = "mkisic",
                        Password = "ftn",
                        LoginType = LoginType.doctor,
                        Gender = "male",
                        DateOfBirth = new DateTime(1999, 7, 14),
                        Phone = "019919199191",
                        Email = "nemanjar@gmail.com",
                        Address = "Sime Milutinovica, 2",
                        City = "Novi Sad",
                        Country = "Serbia",
                        IsBlocked = false,
                        IsActivated = false,
                        UsedOffDays = 12,
                        Specialization = Specialization.cardiologist,
                        RoomId = 7
                    }
                );
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

            modelBuilder.Entity<Survey>(s =>
                {
                    s.HasData(
                        new Survey()
                        {
                            Id = -1,
                            PatientId = "imbiamba",
                            SubmissionDate = new DateTime(2021, 11, 18),
                            VisitId = 1
                        });
                });

            modelBuilder.Entity<Question>(q =>
            {
                q.HasData(
                    new Question()
                    {
                        SurveyId = -1,
                        Id = -1,
                        Value = 1,
                        Category = QuestionCategory.hospital
                    });

                q.HasKey(q => new { q.SurveyId, q.Id });
            });


            modelBuilder.Entity<Visit>(v =>
            {
                v.HasData(
                    new Visit()
                    {
                        Id = -1,
                        DoctorId = "nelex",
                        PatientId = "imbiamba",
                        StartTime = new DateTime(2021, 11, 30, 19, 00, 00),
                        EndTime = new DateTime(2021, 11, 30, 19, 30, 00),
                        VisitType = VisitType.examination,
                        IsReviewed = false,
                        IsCanceled = false
                    });
            });
        }
    }
}