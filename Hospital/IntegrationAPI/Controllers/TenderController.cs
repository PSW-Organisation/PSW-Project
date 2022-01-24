using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private ITenderService tenderService;

        private IPharmacyService pharmacyService;

        public TenderController(ITenderService tenderService, IPharmacyService pharmacyService)
        {
            this.tenderService = tenderService;
            this.pharmacyService = pharmacyService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<TenderDTO> tenderDtos = new List<TenderDTO>();
            //tenderService.Get().ToList().ForEach(tender => tenderDtos.Add(TenderAdapter.TenderToTenderDto(tender)));
            foreach(Tender tender in tenderService.Get())
            {
                if(tender.TenderCloseDate < DateTime.Now)
                {
                    CloseTender(tender.Id);
                    
                }
                tenderDtos.Add(TenderAdapter.TenderToTenderDto(tender));
            }
            return Ok(tenderDtos);
        }

        [HttpPost]
        public IActionResult Add(TenderDTO dto)
        {
            return Ok(tenderService.Add(TenderAdapter.TenderDtoToTender(dto)));
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            Tender tender = tenderService.Get(id);
            if (tender == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(TenderAdapter.TenderToTenderDto(tender));
            }
        }
        
        [HttpGet("close/{id?}")]
        public IActionResult CloseTender(int id)
        {
            Ping p = new Ping();
            PingReply reply;
            reply = p.Send("");
            Tender tender = tenderService.Get(id);
            if (tender == null)
            {
                return NotFound();
            }
            tender.Open = false;
            tenderService.Update(tender);
            foreach(Pharmacy pharmacy in pharmacyService.GetAll())
            {
                var client = new RestClient(pharmacy.PharmacyUrl);
                var request = new RestRequest("/tender/notwon/" + id, Method.GET);
                var cancellationTokenSource = new CancellationTokenSource();
                client.ExecuteAsync(request, cancellationTokenSource.Token);
            }
            return Ok();
        }
    }
}
