using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Tendering.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private ITenderService tenderService;

        public TenderController(ITenderService tenderService)
        {
            this.tenderService = tenderService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<TenderDTO> tenderDtos = new List<TenderDTO>();
            tenderService.Get().ToList().ForEach(tender => tenderDtos.Add(TenderAdapter.TenderToTenderDto(tender)));
            return Ok(tenderDtos);
        }

        [HttpPost]
        public IActionResult Add(TenderDTO dto)
        {
            
            return Ok(tenderService.Add(TenderAdapter.TenderDtoToTender(dto)));
        }
    }
}
