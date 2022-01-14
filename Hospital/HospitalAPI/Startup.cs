using ehealthcare.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using FluentValidation;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.FeedbackAndSurvey.Service;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.Shared.Service;
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
using HospitalLibrary.RoomsAndEquipment.Terms.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Service;
using HospitalLibrary.Medicines.Repository;
using HospitalLibrary.Medicines.Service;
using HospitalLibrary.Schedule.Service;
using HospitalLibrary.Schedule.Repository;
using HospitalLibrary.DoctorSchedule.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HospitalLibrary.Shared.Repository;
using HospitalAPI.JWT;
using Microsoft.AspNetCore.Authorization;
using HospitalLibrary.DoctorSchedule.Repository;

namespace HospitalAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtToken:Audience"],
                    ValidIssuer = Configuration["JwtToken:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:SigningKey"]))
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Patient", policy => policy.Requirements.Add(new RoleRequirement("patient")));
                options.AddPolicy("Manager", policy => policy.Requirements.Add(new RoleRequirement("manager")));
            });
            services.AddSingleton<IAuthorizationHandler, RoleAuthorizationHandler>();

            services.AddDbContext<HospitalDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                assembly => assembly.MigrationsAssembly(typeof(HospitalDbContext).Assembly.FullName)).UseLazyLoadingProxies();
                //assembly => assembly.MigrationsAssembly(typeof(HospitalDbContext).Assembly.FullName));
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

            services.AddTransient<IValidator<SurveyQuestionDto>, SurveyValidator>();
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                //.AllowCredentials();
            }));
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IRoomGraphicService, RoomGraphicService>();
            services.AddScoped<IRoomGraphicRepository, RoomGraphicRepository>();

            services.AddScoped<IFloorGraphicService, FloorGraphicService>();
            services.AddScoped<IFloorGraphicRepository, FloorGraphicRepository>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IExteriorGraphicService, ExteriorGraphicService>();
            services.AddScoped<IExteriorGraphicRepository, ExteriorGraphicRepository>();

            services.AddScoped<ITermOfRelocationEquipmentService, TermOfRelocationEquipmentService>();
            services.AddScoped<ITermOfRelocationEquipmentRepository, TermOfRelocationEquipmentRepository>();

            services.AddScoped<ITermOfRenovationService, TermOfRenovationService>();
            services.AddScoped<ITermOfRenovationRepository, TermOfRenovationRepository>();

            services.AddScoped<IDoctorVacationService, DoctorVacationService>();
            services.AddScoped<IDoctorVacationRepository, DoctorVacationRepository>();

            services.AddScoped<IOnCallShiftService, OnCallShiftService>();
            services.AddScoped<IOnCallShiftRepository, OnCallShiftRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<GenericSTRINGIDRepository<User>, UserDbRepository>();
            services.AddScoped<IUserRepository, UserDbRepository>();

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<GenericSTRINGIDRepository<Patient>, PatientDbRepository>();
            services.AddScoped<IPatientRepository, PatientDbRepository>();

            services.AddScoped<GenericSTRINGIDRepository<Doctor>, DoctorDbRepository>();
            services.AddScoped<IDoctorRepository, DoctorDbRepository>();
            services.AddScoped<IDoctorService, DoctorService>();

            services.AddScoped<IAllergenService, AllergenService>();
            services.AddScoped<GenericDbRepository<Allergen>, AllergenDbRepository>();
            services.AddScoped<IAllergenRepository, AllergenDbRepository>();

            services.AddScoped<IVisitService, VisitService>();
            services.AddScoped<GenericDbRepository<Visit>, VisitDbRepository>();
            services.AddScoped<IVisitRepository, VisitDbRepository>();

            services.AddScoped<IRoomEquipmentService, RoomEquipmentService>();
            services.AddScoped<IRoomEquipmentRepository, RoomEquipmentRepository>();

            services.AddScoped<IPatientFeedbackService, PatientFeedbackService>();
            services.AddScoped<GenericDbRepository<PatientFeedback>, PatientFeedbackDbRepository>();
            services.AddScoped<IPatientFeedbackRepository, PatientFeedbackDbRepository>();

            services.AddHostedService<ScheduleBackgroundService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<GenericDbRepository<Survey>, SurveyDbRepository>();
            services.AddScoped<ISurveyRepository, SurveyDbRepository>();

            services.AddScoped<IMedicinePrescriptionService, MedicinePrescriptionService>();
            services.AddScoped<IMedicinePrescriptionRepository, MedicinePrescriptionDbRepository>();

            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IShiftRepository, ShiftRepository>();
            services.AddScoped<IShiftService, ShiftService>();
            
            services.AddHostedService<RenovationBackgroundService>();
            services.AddHostedService<ShiftBackgroundService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
