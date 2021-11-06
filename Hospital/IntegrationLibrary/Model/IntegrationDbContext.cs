using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ResponseToComplaint> ResponseToComplaint { get; set; }

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
                PharmacyApiKey = "",
                HospitalApiKey = ""
            });

            modelBuilder.Entity<Complaint>().HasData(
                new Complaint()
                {
                    ComplaintId = 1,
                    Date = DateTime.Now,
                    Title = "Prigovor o dostavi",
                    Content = "Postovani, molimo Vas da isporuke o medicinskim sredstvima vrsite u navedenom roku! ",
                    PharmacyId =1
                });
            modelBuilder.Entity<ResponseToComplaint>().HasData(new ResponseToComplaint()
            {
                ResponseToComplaintId = 1,
                Date = DateTime.Now,
                Content = "Prvi test Response to complaint",
                ComplaintId = 1
            });
        }
    }
}
