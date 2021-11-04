using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ehealthcare.Model
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<VisitTime> VisitTimes { get; set; }

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
        }
    }
}
