using HospitalAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;

namespace HospitalIntegrationTests
{
    public class TestingHospitalFactory<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HospitalDbContext>));

                if (dbContext != null)
                    services.Remove(dbContext);
              
                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<HospitalDbContext>(options =>
                {
                    options.UseInMemoryDatabase("fake");
                    options.UseInternalServiceProvider(serviceProvider);
                });
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<HospitalDbContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureCreated();
                            appContext.Patients.Add(new Patient("coalukas")
                            {
                                LoginType = 0,
                                Password = "Coa1999!",
                                Name = "Aleksandar"
                            });
                            appContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            });
        }
    }
}
