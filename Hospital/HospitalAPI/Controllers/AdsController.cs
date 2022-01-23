using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using ehealthcare.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AdsController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AdsController(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetAllAds()
        {
            var client = new RestClient(_configuration["PharmacyAPI:Path"]);
            var request = new RestRequest("/api3/ads", Method.GET);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(response.Content);
            return NotFound();
        }
    }
}
