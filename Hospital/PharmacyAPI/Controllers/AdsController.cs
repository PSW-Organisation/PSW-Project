using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository.AdsRepository;
using PharmacyLibrary.Service;
using System.Collections.Generic;

namespace PharmacyAPI.Controllers

{
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    [ApiController]
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