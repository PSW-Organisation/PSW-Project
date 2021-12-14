using IntegrationAPI;
using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationAPIIntegrationTests
{
    public class TestingIntegrationFactory<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<IntegrationDbContext>));

                if (dbContext != null)
                    services.Remove(dbContext);

                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<IntegrationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("fake");
                    options.UseInternalServiceProvider(serviceProvider);
                });
                var sp = services.BuildServiceProvider();


                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<IntegrationDbContext>())
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

        private static void SeedData(IntegrationDbContext context)
        {
            context.Pharmacies.Add(new Pharmacy { PharmacyName = "Benu Apoteka", HospitalApiKey = "e77210eb-ff60-40b0-9bd6-b192661514fe", Id = 1, PharmacyAddress = "Bul. Oslobodjenja 58", PharmacyApiKey= "0b233d98-b569-4224-b968-db10ffe3d3b6", PharmacyCommunicationType = PharmacyCommunicationType.SFTP, PharmacyUrl = "http://localhost:29631/api3" });
        }
    }
}
