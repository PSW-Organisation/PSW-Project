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
            modelBuilder.Entity<ResponseToComplaint>().HasData(new ResponseToComplaint()
            {
                ResponseToComplaintId = 1,
                Date = DateTime.Now,
                Content = "Imali smo problema sa nabavkom leka panadol, izvinjavamo se na zakasneloj porudzbini"
               
            }); 
            modelBuilder.Entity<Complaint>().HasData(new Complaint()
            {
                ComplaintId = 1,
                Date = DateTime.Now,
                Title = "Losa isporuka",
                Content = "Razbijene epruvete",
                HospitalId = 1
            });
            modelBuilder.Entity<Hospital>().HasData(new Hospital()
            {
                HospitalId = 1,
                HospitalName = "Institut za zdravstvenu zastitu dece i omladine Vojvodine",
                HospitalAddress = "Kralja Petra 32",
                HospitalApiKey = "",
                HospitalUrl = "",
            });
        }
    }
}
