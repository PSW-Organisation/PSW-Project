using ehealthcare.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalUnitTests
{
    public class MockDbContext
    {
        public static HospitalDbContext InitMockContext()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>().
                UseInMemoryDatabase(databaseName: "fake").Options;
            var context = new HospitalDbContext(options);
            DetachAll(context);
            return context;
        }

        public static void DetachAll(HospitalDbContext context)
        {
            var changedEntriesCopy = context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified
                    || e.State == EntityState.Deleted).ToList();
            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
            context.SaveChanges();

        }
    }
}
