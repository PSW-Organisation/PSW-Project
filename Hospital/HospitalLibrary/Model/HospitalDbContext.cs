using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ehealthcare.Model
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<VisitTime> VisitTimes { get; set; }
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected HospitalDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitTime>().HasData(new VisitTime()
            {
                Id = "1",
                StartTime = new DateTime(2021, 4, 5),
                EndTime = new DateTime(2021, 4, 25),
            });
            modelBuilder.Entity<PatientFeedback>().HasData(new PatientFeedback()
            {
                Id = "f1",
                PatientUsername= "p1",
                SubmissionDate = new DateTime(2021, 11, 4),
                Text = "alallalal",
                Anonymous = false,
                PublishAllowed = false,
                IsPublished = false
            }); 
        }
    }
}
