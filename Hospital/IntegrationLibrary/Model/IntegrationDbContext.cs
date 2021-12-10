using IntegrationLibrary.Model;
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
    
        public IntegrationDbContext() { }

        //dodato da bi se mogli raditi integracioni testovi sa bazom
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //String connectionString = "Server=localhost;Port=5432;Database=postgres;User ID=postgres;Password=postgres;";
            String connectionString = "Server=localhost;Port=5432;Database=IntegrationDb;User ID=postgres;Password=postgres;";
            optionsBuilder.UseNpgsql(connectionString);
        }

    }
}
