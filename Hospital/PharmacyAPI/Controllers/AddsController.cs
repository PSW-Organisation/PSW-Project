using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository.AdsRepository;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyAPI.Controllers

{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("api3/[controller]")]
    public class AdsController : ControllerBase
    {
        AdsService service = new AdsService(new AdsRepository());

        // za svrhe testiranja
        [HttpGet]
        public IActionResult GetAll()
        {
            ICollection<Ad> ads = service.GetAll();
            return Ok(ads);
        }
    }
}