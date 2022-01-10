using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.SharedModel.Model;
using IntegrationLibrary.Tendering.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class IntegrationDbContext : DbContext
    {
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ResponseToComplaint> ResponseToComplaint { get; set; }
        public DbSet<MedicineTransaction> MedicineTransactions { get; set; }
        public DbSet<MedicineBenefit> Benefits { get; set; }
        public DbSet<NotificationsForApp> Notifications { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderResponse> TenderResponses { get; set; }

        public DbSet<TenderItem> TenderItems { get; set; }

        public IntegrationDbContext() { }

        //dodato da bi se mogli raditi integracioni testovi sa bazom
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //String connectionString = "Server=localhost;Port=5432;Database=postgres;User ID=postgres;Password=postgres;";
            String connectionString = "Server=localhost;Port=5432;Database=IntegrationDb;User ID=postgres;Password=postgres;";
            optionsBuilder.UseNpgsql(connectionString);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PharmacyConfigurations());
            modelBuilder.ApplyConfiguration(new TenderResponseConfigurations());

            //  modelBuilder.Entity<Pharmacy>().HasData(
            //   new Pharmacy { Id = 1, PharmacyName = "Flos", PharmacyAddress = new IntegrationLibrary.Pharmacies.Model.Address { Street = "Pavla Papa", Number = "54", City = "Novi Sad", Country = "Srbija" }  , PharmacyUrl = "http://localhost:29631/api3", PharmacyApiKey = "bc56df25-0d34-4801-b76a-931e61b4c752", HospitalApiKey = "108817cf-dc25-40f4-a18f-244c1315840a", PharmacyCommunicationType = 0, Comment = "Sve je super!", Picture = "pharmacy.jpg" }
            // );
        }

    }
}
