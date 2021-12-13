using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using IntegrationLibrary.Parnership.Service.ServiceInterfaces;
using IntegrationLibrary.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class MedicineBenefitController : ControllerBase
    {
        private IMedicineBenefitService medicineBenefitService;
        public MedicineBenefitController(IMedicineBenefitService medicineBenefitService)
        {
            //this.service = service;
            this.medicineBenefitService = medicineBenefitService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<MedicineBenefitDto> result = new List<MedicineBenefitDto>();
            medicineBenefitService.GetAll().ForEach(benefit => result.Add(MedicineBenefitAdapter.MedicineBenefitToMedicineBenefitDto(benefit)));
            List<MedicineBenefitDto> filteredDto = FilterPublishedMedicineBenefits(result);
            return Ok(filteredDto);
        }


        [HttpPut("{id?}")]
       public IActionResult Put(MedicineBenefitDto dto, int id)
        {
            MedicineBenefit benefit = medicineBenefitService.Get(id);
            if(benefit == null)
            {
                return NotFound();
            }
            medicineBenefitService.Update(MedicineBenefitAdapter.MedicineBenefitDtoToMedicineBenefit(dto));
            return Ok();
        }
        public List<MedicineBenefitDto> FilterPublishedMedicineBenefits(List<MedicineBenefitDto> dto)
        {
            List<MedicineBenefitDto> result = new List<MedicineBenefitDto>();
            foreach(MedicineBenefitDto item in dto)
            {
                if (item.Published.Equals(true))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
