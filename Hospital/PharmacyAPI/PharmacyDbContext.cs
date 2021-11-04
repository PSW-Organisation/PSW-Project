using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyAPI
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }

        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) { }

        protected PharmacyDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>().HasData(new Pharmacy()
            {
                PharmacyId = 1,
                PharmacyName = "Apoteka Jankovic",
                PharmacyAddress = "Bul. Cara Lazara 58",
                PharmacyUrl = "",
                PharmacyApiKey = ""
            });
        }
    }
}
