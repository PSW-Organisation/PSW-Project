using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Adapter;
using PharmacyAPI.DTO;
using PharmacyLibrary.Tendering.Model;
using PharmacyLibrary.Tendering.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api3/[controller]")]
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

        [HttpGet("accept/{id?}")]
        public IActionResult AcceptOffer(int id)
        {
            Tender tender = tenderService.Get(id);
            if (tender == null)
            {
                return NotFound();
            }
            tender.IsWon = true;
            tenderService.Update(tender);
            return Ok();
        }
    }
}
