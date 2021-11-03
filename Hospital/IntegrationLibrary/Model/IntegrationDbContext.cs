using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }

        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }

        protected IntegrationDbContext() { }

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
