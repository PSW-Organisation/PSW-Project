using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Adapter;
using PharmacyAPI.DTO;
using PharmacyLibrary.Tendering.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api3/[controller]")]
    [ApiController]
    public class TenderResponseController : ControllerBase
    {
        private readonly ITenderResponsePublishService tenderResponsePublishService;

        public TenderResponseController(ITenderResponsePublishService tenderResponsePublishService)
        {
            this.tenderResponsePublishService = tenderResponsePublishService;
        }

        [HttpPost]
        public IActionResult Add(TenderResponseDto dto)
        {
            return Ok(tenderResponsePublishService.AnnounceResponse(TenderResponseAdapter.TenderResponseDtoToTenderResponse(dto)));
        }
    }
}
