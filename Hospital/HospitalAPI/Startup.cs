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
using ehealthcare.Service;
using HospitalLibrary.Service;
using ehealthcare.Repository;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.FeedbackAndSurvey.Repository;
using HospitalLibrary.FeedbackAndSurvey.Service;
using HospitalLibrary.Repository;
using HospitalLibrary.Repository.DbRepository;

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

            services.AddTransient<IValidator<PatientFeedbackDTO>, PatientFeedbackValidator>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IRoomGraphicService, RoomGraphicService>();
            services.AddScoped<IRoomGraphicRepository, RoomGraphicRepository>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomDbRepository>();

            services.AddScoped<IExteriorGraphicService, ExteriorGraphicService>();
            services.AddScoped<IExteriorGraphicRepository, ExteriorGraphicRepository>();

            services.AddScoped<IPatientFeedbackService, PatientFeedbackService>();
            services.AddScoped<GenericDbRepository<PatientFeedback>, PatientFeedbackDbRepository>();
            services.AddScoped<IPatientFeedbackRepository, PatientFeedbackDbRepository>();

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
