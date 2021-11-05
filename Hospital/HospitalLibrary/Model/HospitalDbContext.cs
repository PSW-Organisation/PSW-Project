using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ehealthcare.Model
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }

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
        }
    }
}
