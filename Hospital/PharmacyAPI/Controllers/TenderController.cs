using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Adapter;
using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using PharmacyLibrary.Service;
using PharmacyLibrary.Tendering.Model;
using PharmacyLibrary.Tendering.Service;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api3/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private ITenderService tenderService;
        private IHospitalService hospitalService;
        public TenderController(ITenderService tenderService, IHospitalService hospitalService
            )
        {
            this.tenderService = tenderService;
            this.hospitalService = hospitalService;
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

        [HttpGet("close/{id?}")]
        public IActionResult CloseTender(int id)
        {

            Tender tender = tenderService.Get(id);
            if(tender == null)
            {
                return NotFound();
            }
            tender.Open = false;
            string hospitalUrl = ""; 
            foreach(Hospital hospital in hospitalService.Get())
            {
                if (hospital.PharmacyApiKey.Equals(tender.ApiKeyPharmacy))
                {
                    hospitalUrl = hospital.HospitalUrl;
                }
            }
            tenderService.Update(tender);
            var client = new RestClient(hospitalUrl);
            var request = new RestRequest("/tender/close/" + tender.Id, Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();
            client.ExecuteAsync(request, cancellationTokenSource.Token);
            return Ok();

        }

        [HttpGet("notwon/{id?}")]
        public IActionResult CloseNotWonTender(int id)
        {

            Tender tender = tenderService.Get(id);
            if (tender == null)
            {
                return NotFound();
            }
            tender.Open = false;
            tender.IsWon = false;
            tenderService.Update(tender);
            return Ok();

        }

    }
}
