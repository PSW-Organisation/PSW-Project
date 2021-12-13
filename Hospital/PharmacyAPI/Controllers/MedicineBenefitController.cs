using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmacyAPI.Adapter;
using PharmacyAPI.DTO;
using PharmacyLibrary.Service;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("api3/[controller]")]
    public class MedicineBenefitController : ControllerBase
    {
        private readonly IMedicineBenefitService medicineBenefitService;
        private readonly IPharmacyService pharmacyService;

        public MedicineBenefitController(IMedicineBenefitService medicineBenefitService, IPharmacyService pharmacyService)
        {
            this.medicineBenefitService = medicineBenefitService;
            this.pharmacyService = pharmacyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<MedicineBenefitDto> medicineBenefitDtos = new List<MedicineBenefitDto>();
            medicineBenefitService.Get().ToList().ForEach(medicineBenefit => medicineBenefitDtos.Add(MedicineBenefitAdapter.MedicineBenefitToMedicineBenefitDto(medicineBenefit)));
            return Ok(medicineBenefitDtos);
        }

        [HttpPost]
        public IActionResult Add(MedicineBenefitDto dto)
        {
            Pharmacy pharmacy =  pharmacyService.Get(1);

            return Ok(medicineBenefitService.Add(MedicineBenefitAdapter.MedicineBenefitDtoToMedicineBenefit(dto)));
        }


    }
}
