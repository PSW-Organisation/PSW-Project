using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.JWT
{
    public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor = null;

        private readonly IConfiguration _configuration;

        private readonly IServiceProvider _serviceProvider;



        public RoleAuthorizationHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var authHeader = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization];
            if (authHeader.Count == 0)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            string accessToken = authHeader[0].Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidAudience = _configuration["JwtToken:Audience"],
                ValidIssuer = _configuration["JwtToken:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:SigningKey"])),
            };

            SecurityToken validToken = null;
            try
            {
                var principal = handler.ValidateToken(accessToken, validationParameters, out validToken);

            }
            catch (Exception)
            {

                context.Fail();
                return Task.CompletedTask;
            }

            var userToken = handler.ReadJwtToken(accessToken);

            var claims = userToken.Claims.ToList();

            using (var scope = _serviceProvider.CreateScope())
            {
                var patientService = scope.ServiceProvider.GetRequiredService<IPatientService>();
                Patient loggedIn = patientService.GetUsingCredentials(claims[0].Value, claims[1].Value);
                if (loggedIn != null && loggedIn.LoginType.ToString().Equals(claims[3].Value)) context.Succeed(requirement);
                else context.Fail();
            };

            return Task.CompletedTask;
        }
    }
}
