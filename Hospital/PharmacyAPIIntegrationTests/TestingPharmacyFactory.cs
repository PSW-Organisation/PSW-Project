using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PharmacyAPI;
using PharmacyAPI.Model;
using PharmacyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyAPIIntegrationTests
{
    class TestingPharmacyFactory<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<PharmacyDbContext>));

                if (dbContext != null)
                    services.Remove(dbContext);

                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<PharmacyDbContext>(options =>
                {
                    options.UseInMemoryDatabase("fake");
                    options.UseInternalServiceProvider(serviceProvider);
                });
                var sp = services.BuildServiceProvider();


                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<PharmacyDbContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureCreated();
                            SeedData(appContext);
                            appContext.SaveChanges();
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            });

        }

        private static void SeedData(PharmacyDbContext context)
        {
            context.Hospitals.Add(new Hospital { HospitalAddress = "Narodnog fronta 43", HospitalApiKey = "e77210eb-ff60-40b0-9bd6-b192661514fe", HospitalId = 1, HospitalName = "LeanOn hospital", HospitalUrl = "http://localhost:16928/api2", PharmacyApiKey = "0b233d98-b569-4224-b968-db10ffe3d3b6" });
            context.Medicines.Add(new Medicine { Id = 1, Name = "Panklav", Quantity = 25 });
        }
    }
}
