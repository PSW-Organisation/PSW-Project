using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PharmacyLibrary.Repository.HospitalRepository;
using PharmacyLibrary.Repository.MedicineBenefitRepository;
using PharmacyLibrary.Repository.MedicineRepository;
using PharmacyLibrary.Repository.PharmacyRepository;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddControllers();
            services.AddDbContext<PharmacyDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(PharmacyDbContext).Assembly.FullName));
            });
        
            services.AddTransient<IPharmacyRepository, PharmacyRepository>();
            services.AddTransient<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IPublishService, RabbitMQPublishService>();
            services.AddScoped<IMedicineBenefitRepository, MedicineBenefitRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IPharmacyService, PharmacyService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IMedicineBenefitService, MedicineBenefitService>();
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

            app.UseAuthorization();

            //added for Cors error 
            //_______________________________________________________

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseCors(options => options.AllowAnyOrigin());
            //________________________________________________________
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

        }
    }
}
