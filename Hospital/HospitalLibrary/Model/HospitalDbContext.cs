using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ehealthcare.Model
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }

        public DbSet<RoomGraphic> RoomGraphics { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<ExteriorGraphic> ExteriorGraphic { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected HospitalDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PatientFeedback>().HasData(new PatientFeedback()
            {
                Id = -1,
                PatientUsername = "p1",
                SubmissionDate = new DateTime(2021, 11, 4),
                Text = "alallalal",
                Anonymous = false,
                PublishAllowed = false,
                IsPublished = false
            }); 
               
            modelBuilder.Entity<RoomGraphic>().HasData(new RoomGraphic()
            {
                Id = "0",
                DoorPosition = "right",
                Width = 100,
                Height = 100,
                X = 0,
                Y = 0,
                Name = "S1",
                Floor = 0,
                Type = "Salter",
                RoomRef = null
            });

            modelBuilder.Entity<Room>().HasData(new Room()
            {
                Id = "0",
                Sector = "S!",
                Floor = 1,
                RoomType = RoomType.operation,
                IsRenovated = false,
                IsRenovatedUntill = new DateTime(2021, 6, 25),
                NumOfTakenBeds = 2,

            });

            modelBuilder.Entity<ExteriorGraphic>().HasData(new ExteriorGraphic()
            {
                Id = "0",
                X = 180,
                Y = 30,
                Width = 100,
                Height = 200,
                Name = "ZGR1",
                Type = "building",
                IdElement = "0"
            },
            new ExteriorGraphic() 
            {
                Id = "1",
                X = 380,
                Y = 120,
                Width = 180,
                Height = 110,
                Name = "ZGR2",
                Type = "building",
                IdElement = "1"
            },
            new ExteriorGraphic()
            {
                Id = "2",
                X = 0,
                Y = 250,
                Width = 600,
                Height = 50,
                Name = "",
                Type = "road",
                IdElement = "-1"
            },
            new ExteriorGraphic()
            {
                Id = "3",
                X = 0,
                Y = 290,
                Width = 50,
                Height = 110,
                Name = "",
                Type = "road",
                IdElement = "-1"
            },
            new ExteriorGraphic()
            {
                Id = "4",
                X = 305,
                Y = 0,
                Width = 50,
                Height = 400,
                Name = "",
                Type = "road",
                IdElement = "-1"
            },
            new ExteriorGraphic()
            {
                Id = "5",
                X = 245,
                Y = 310,
                Width = 50,
                Height = 80,
                Name = "P",
                Type = "parking",
                IdElement = "-1"
            },
            new ExteriorGraphic()
            {
                Id = "6",
                X = 380,
                Y = 20,
                Width = 50,
                Height = 80,
                Name = "P",
                Type = "parking",
                IdElement = "-1"
            });
            
        }
    }
}
