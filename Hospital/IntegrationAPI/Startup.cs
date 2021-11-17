using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using IntegrationLibrary.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Repository.DatabaseRepository;

namespace IntegrationAPI
{
    public class Startup
    {
        readonly string allowSpecificOrigins = "_allowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<IntegrationDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(IntegrationDbContext).Assembly.FullName));
            });
            services.AddScoped<AccountRepository, AccountDbRepository>();
            services.AddScoped<AccountDataRepository, AccountDataDbRepository>();
            services.AddScoped<AllergenRepository, AllergenDbRepository>();
            services.AddScoped<BugReportRepository, BugReportDbRepository>();
            services.AddScoped<DoctorRepository, DoctorDbRepository>();
            services.AddScoped<HolidayRepository, HolidayDbRepository>();
            services.AddScoped<DoctorReviewRepository, DoctorReviewDbRepository>();
            services.AddScoped<HospitalizationRepository, HospitalizationDbRepository>();
            services.AddScoped<HospitalReviewRepository, HospitalReviewDbRepository>();
            services.AddScoped<MedicineRepository, MedicineDbRepository>();
            services.AddScoped<NotificationRepository, NotificationDbRepository>();
            services.AddScoped<PatientRepository, PatientDbRepository>();
            services.AddScoped<PersonalizedNotificationRepository, PersonalizedNotificationDbRepository>();
            services.AddScoped<ReminderRepository, ReminderDbRepository>();
            services.AddScoped<ReviewReportRepository, ReviewReportDbRepository>();
            services.AddScoped<RoomRepository, RoomDbRepository>();
            services.AddScoped<RoomInventoryRepository, RoomInventoryDbRepository>();
            services.AddScoped<TherapyRepository, TherapyDbRepository>();
            services.AddScoped<TherapyNotificationRepository, TherapyNotificationDbRepository>();
            services.AddScoped<VisitRepository, VisitDbRepository>();
            services.AddScoped<VisitReportRepository, VisitReportDbRepository>();
            services.AddScoped<WorkdayRepository, WorkdayDbRepository>();


            //added for Cors error
            //______________________________________________________________________
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .WithOrigins(new[] { "http://localhost:4200" })
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
            //______________________________________________________________________
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            //added for Cors error
            //______________________________________________________________________
            app.UseCors("CorsPolicy");
            //______________________________________________________________________

            app.UseHttpsRedirection();

            //added for Cors error
            //______________________________________________________________________
            app.UseCors(options => options.AllowAnyOrigin());
            //______________________________________________________________________

            app.UseAuthorization();

            app.UsePathBase("/api2");

           app.UseEndpoints(endpoints =>
           {
            endpoints.MapControllers();
           });

        }
    }
}
