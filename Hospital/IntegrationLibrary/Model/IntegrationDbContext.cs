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
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<MedicineTransaction> MedicineTransactions { get; set; }
        public DbSet<MedicineIngredient> Ingredients { get; set; }
        public DbSet<MedicineBenefit> Benefits { get; set; }
        //public DbSet<Account> Accounts { get; set; }
        //public DbSet<AccountData> AccountData { get; set; }
        //public DbSet<Allergen> Allergens { get; set; }
        public IntegrationDbContext() { }
       
    }
}
