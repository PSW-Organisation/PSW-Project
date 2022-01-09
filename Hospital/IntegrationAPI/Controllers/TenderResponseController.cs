using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class TenderResponseController : ControllerBase
    {
        private ITenderResponseService tenderResponseService;

        public TenderResponseController(ITenderResponseService tenderResponseService)
        {
            this.tenderResponseService = tenderResponseService;
        }

        [HttpGet("accept/{id?}")]
        public IActionResult AcceptOffer(int id)
        {
            TenderResponse tenderResponse = tenderResponseService.Get(id);
            if (tenderResponse == null)
            {
                return NotFound();
            }
            tenderResponse.IsWinner = true;
            Tender tender = tenderResponse.Tender;
            Pharmacy pharmacy = tenderResponse.Pharmacy;
            tender.ApiKeyPharmacy = pharmacy.PharmacyApiKey;
            tenderResponseService.Update(tenderResponse);
            return Ok();
        }
    }
}
