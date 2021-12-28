using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HospitalAPI.DTO;
using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibrary.Shared.Service;
using System.Collections.Generic;
using HospitalLibrary.Shared.Model;
using Microsoft.Extensions.Configuration;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserDTO userDTO)
        {
            var user = _userService.GetUser(userDTO.Username);

            if (user == null) return Unauthorized();

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim("password", user.Password));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.LoginType.ToString()));


            var token = JwtHelper.GetJwtToken(
                user.Username,
                _configuration["JwtToken:SigningKey"],
                _configuration["JwtToken:Issuer"],
                _configuration["JwtToken:Audience"],
                DateTime.Now.AddHours(10),
                claims.ToArray());

            return Ok(new JwtDto()
            {
                User = user,
                Token = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expires = token.ValidTo
                }
            });
        }
    }
}

