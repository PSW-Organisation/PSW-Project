
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository.AdsRepository;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyAPI.Controllers

{
    [Route("api3/[controller]")]
    [ApiController]
   
    public class AdsController : ControllerBase
    {
        private readonly IAdsService adsService;

        public AdsController(IAdsService adsService)
        {
            this.adsService = adsService;
        }


        [HttpGet]       // GET /api3/adds
        public List<Ad> GetAllAdds()
        {
            return adsService.GetAll();
        }

        [HttpGet("{id?}")]
        public Ad Get(long id)
        {
            return adsService.GetById(id);
        }

        [HttpPost]
        public void Add(Ad newAd)
        {
            adsService.Add(newAd);
        }

        [HttpDelete("{id?}")]
        public void Delete(long id)
        {
            adsService.Delete(id);
        }
    }
    }