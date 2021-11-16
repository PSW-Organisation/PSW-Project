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
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<MedicineTransaction> MedicineTransactions { get; set; }
        public DbSet<MedicineIngredient> Ingredients { get; set; }
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }
        protected IntegrationDbContext() { }
    }
}
