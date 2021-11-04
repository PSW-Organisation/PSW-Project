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

            //services.AddCors(options =>
            //    options.AddDefaultPolicy(
            //        builder => builder.WithOrigins("https://localhost:16928")));
            //options.AddPolicy(allowSpecificOrigins,

            //builder =>

            //{

            //    builder.WithOrigins("https://localhost:4200")

            //            .AllowAnyHeader()

            //            .AllowAnyMethod();

            //});



            /*services.AddMvc()
                .AddNewtonsoftJson();*/

            /*services.AddDbContext<IntegrationDbContext>(options =>
            {
                options.UseNpgsql(ConfigurationExtensions.GetConnectionString(Configuration, "DefaultConnection"));
            });*/


            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .WithOrigins(new[] { "http://localhost:4200" })
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

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

            //app.UseCors(allowSpecificOrigins);
            //app.UseCors(corsPolicyBuilder => corsPolicyBuilder.WithOrigins("http://localhost:16928").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(options => options.AllowAnyOrigin());

        

            app.UseAuthorization();

            app.UsePathBase("/api2");

           app.UseEndpoints(endpoints =>
           {
            endpoints.MapControllers();
           });

        }
    }
}
