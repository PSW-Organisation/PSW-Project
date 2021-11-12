using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PharmacyAPI.DTO;
using PharmacyLibrary.Service;
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
        private readonly IPharmacyService pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }


        [HttpGet]       // GET /api3/pharmacy
        public List<Pharmacy> GetAllPharmacies()
        {
            return pharmacyService.Get();
        }

        [HttpGet("{id?}")]
        public Pharmacy Get(long id)
        {
            return pharmacyService.Get(id);
        }

        [HttpPost]
        public Boolean Add(Pharmacy newPharmacy)
        {
            return pharmacyService.Add(newPharmacy);
        }

        [HttpDelete("{id?}")]
        public Boolean Delete(long id)
        {
            return pharmacyService.Delete(id);
        }

        [HttpPut]
        public Boolean Update(Pharmacy p)
        {
            return pharmacyService.Update(p);
        }


    }
}
