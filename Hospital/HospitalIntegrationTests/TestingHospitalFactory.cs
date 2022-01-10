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
using HospitalLibrary.Model;

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
                                Info = new UserPersonalInfo("coalukas", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9)),
                                IsActivated = true,
                                Token = new Guid("98dd3304-2326-4e8e-9f6d-868f30f9a9cc"),
                                Medical = new HospitalLibrary.MedicalRecords.Model.MedicalRecord()
                                {
                                    PatientId = "coalukas",
                                    DoctorId = "nelex",
                                    Doctor = null
                                }
                            });
                            SeedData(appContext);

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

        private static void SeedData(HospitalDbContext context)
        {
            context.Doctors.Add(new Doctor("nemanja")
            {
                Specialization = Specialization.none,
                UsedOffDays = 2,
                Patients = new List<Patient>(){
                    new Patient("luka") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("luka", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },
                    new Patient("lukaaa") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("lukaaa", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    }
                }
            });
            context.Doctors.Add(new Doctor("maja")
            {
                Specialization = Specialization.none,
                UsedOffDays = 2,
                Patients = new List<Patient>(){
                    new Patient("milica") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("milica", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },
                    new Patient("zora") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("zora", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },
                    new Patient("milan") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("milan", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },

                }
            });
            context.Doctors.Add(new Doctor("mirko")
            {
                Specialization = Specialization.none,
                UsedOffDays = 2,
                Patients = new List<Patient>(){
                    new Patient("milicaaa") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("milicaaa", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },
                    new Patient("zoraaa") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("zoraaa", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },
                    new Patient("milanaa") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("milanaa", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },
                    new Patient("milana") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("milana", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },
                    new Patient("milanaaaa") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("milanaaaa", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },
                }
            });
            context.Doctors.Add(new Doctor("mihajlo")
            {
                Specialization = Specialization.cardiologist,
                UsedOffDays = 2,
                Patients = new List<Patient>(){
                    new Patient("jovana") {
                        LoginType = 0,
                        Password = "Coa1999!",
                        Info = new UserPersonalInfo("jovana", "Aleksandar", "Peric", "Zoran", "male", new DateTime(2001, 11, 9))
                    },

                }
            });
        }
    }
}
