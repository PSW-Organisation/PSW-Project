using ehealthcare.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using FluentValidation;
using HospitalAPI.DTO;
using AutoMapper;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.GraphicalEditor.Repository;

namespace HospitalAPI
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
            services.AddControllers();
            services.AddDbContext<HospitalDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(HospitalDbContext).Assembly.FullName));
            });

            services.AddMvc(setup => {
                //...mvc setup...
            }).AddFluentValidation().AddNewtonsoftJson();

            services.AddTransient<IValidator<PatientFeedbackDto>, PatientFeedbackValidator>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IRoomGraphicService, RoomGraphicService>();
            services.AddScoped<IRoomGraphicRepository, RoomGraphicRepository>();

            services.AddScoped<IExteriorGraphicService, ExteriorGraphicService>();
            services.AddScoped<IExteriorGraphicRepository, ExteriorGraphicRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
