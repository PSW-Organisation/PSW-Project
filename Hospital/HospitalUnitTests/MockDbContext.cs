using ehealthcare.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return context;
        }
    }
}
