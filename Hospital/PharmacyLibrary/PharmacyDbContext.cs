using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Model;
using PharmacyLibrary.Model;
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
        public DbSet<MedicineBenefit> MedicineBenefits { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<NotificationsForApp> Notifications { get; set; }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<MedicineAd> MedicineAds { get; set; }


        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) { }
        

        public PharmacyDbContext() { }

        //dodato da bi se mogli raditi integracioni testovi sa bazom
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString = "Server=localhost;Port=5432;Database=PharmacyDb;User ID=postgres;Password=postgres;";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
