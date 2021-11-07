using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("api3/[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly PharmacyDbContext dbContext;

        public PharmacyController(PharmacyDbContext context)
        {
            dbContext = context;
        }


        [HttpGet]       // GET /api/pharmacy
        public IActionResult Get()
        {
            List<Pharmacy> result = new List<Pharmacy>();
            dbContext.Pharmacies.ToList().ForEach(pharmacy => result.Add(pharmacy));
            return Ok(result);
        }
    }
}
