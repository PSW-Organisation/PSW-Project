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
using AutoMapper;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.GraphicalEditor.Repository;
using ehealthcare.Service;
using ehealthcare.Repository;
using HospitalLibrary.Repository;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.FeedbackAndSurvey.Service;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.FeedbackAndSurvey.Repository;
using HospitalAPI.DTO;
using HospitalLibrary.RoomsAndEquipment.Service;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.MedicalRecord.Repository;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using AllergenService = HospitalLibrary.MedicalRecords.Service.AllergenService;
using HospitalLibrary;
using PatientService = HospitalLibrary.MedicalRecords.Service.PatientService;
using Newtonsoft.Json;
using HospitalAPI.Validators;

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
                    assembly => assembly.MigrationsAssembly(typeof(HospitalDbContext).Assembly.FullName)).UseLazyLoadingProxies();
            });

            services.AddMvc(setup =>
            {
                //...mvc setup...
            }).AddFluentValidation().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddTransient<IValidator<PatientFeedbackDTO>, PatientFeedbackValidator>();
            services.AddTransient<IValidator<PatientDto>, PatientValidator>();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .WithOrigins(new[] { "http://localhost:4200" })
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IRoomGraphicService, RoomGraphicService>();
            services.AddScoped<IRoomGraphicRepository, RoomGraphicRepository>();

            services.AddScoped<IFloorGraphicService, FloorGraphicService>();
            services.AddScoped<IFloorGraphicRepository, FloorGraphicRepository>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomDbRepository>();

            services.AddScoped<IExteriorGraphicService, ExteriorGraphicService>();
            services.AddScoped<IExteriorGraphicRepository, ExteriorGraphicRepository>();

            services.AddScoped<IRelocationEquipmentService, RelocationEquipmentService>();
            services.AddScoped<IRelocationEquipmentRepository, RelocationEquipmentRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<GenericSTRINGIDRepository<User>, UserDbRepository>();
            services.AddScoped<IUserRepository, UserDbRepository>();

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<GenericSTRINGIDRepository<Patient>, PatientDbRepository>();
            services.AddScoped<IPatientRepository, PatientDbRepository>();

            services.AddScoped<IPatientFeedbackService, PatientFeedbackService>();
            services.AddScoped<GenericDbRepository<PatientFeedback>, PatientFeedbackDbRepository>();
            services.AddScoped<IPatientFeedbackRepository, PatientFeedbackDbRepository>();
            services.AddScoped<IRoomEquipmentService, RoomEquipmentService>();
            services.AddScoped<IRoomEquipmentRepository, RoomEquipmentRepository>();
            services.AddScoped<GenericSTRINGIDRepository<Doctor>, DoctorDbRepository>();
            services.AddScoped<IDoctorRepository, DoctorDbRepository>();
            services.AddScoped<IDoctorService, DoctorService>();

            services.AddScoped<IAllergenService, AllergenService>();
            services.AddScoped<GenericDbRepository<Allergen>, AllergenDbRepository>();
            services.AddScoped<IAllergenRepository, AllergenDbRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseCors("CorsPolicy");


            app.UseHttpsRedirection();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
