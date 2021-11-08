﻿using Microsoft.EntityFrameworkCore;
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

        }
    }
}
