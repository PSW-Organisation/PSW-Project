using ehealthcare.Model;
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
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountData> AccountData { get; set; }
        public DbSet<Allergen> Allergends { get; set; }
        public IntegrationDbContext() { }
    }
}
