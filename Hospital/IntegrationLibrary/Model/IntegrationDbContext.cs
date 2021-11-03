using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class IntegrationDbContext : DbContext
    {
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }

        protected IntegrationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<VisitTime>().HasData(new VisitTime()
            {
                Id = "zoki",
                StartTime = new DateTime(2010, 10, 10),
                EndTime = new DateTime(2010, 10, 11)
            });*/
        }
    }
}
