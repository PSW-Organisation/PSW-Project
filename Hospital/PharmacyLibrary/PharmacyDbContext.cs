using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyAPI
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<ResponseToComplaint> ResponsesToComplaint { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) { }

        public PharmacyDbContext() 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString = "Server=localhost;Port=5432;Database=PharmacyDb;User ID=postgres;Password=postgres;";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
