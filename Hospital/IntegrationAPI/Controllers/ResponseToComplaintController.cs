
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using IntegrationLibrary.Model;
using IntegrationAPI.DTO;
using IntegrationAPI.Adapters;
using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;

namespace IntegrationAPI.Controllers
{

    [Route("api2/responses")]
    [ApiController]
    public class ResponseToComplaintController : ControllerBase
    {

        private IResponseToComplaintService responseService;
        private IPharmacyService pharmacyService;
        private IComplaintService complaintService;

        public ResponseToComplaintController(IResponseToComplaintService responseService, IPharmacyService pharmacyService, IComplaintService complaintService)
        {
            this.responseService = responseService;
            this.pharmacyService = pharmacyService;
            this.complaintService = complaintService;
        }

        [HttpGet]       // GET /api/response
        public IActionResult Get()
        {
            List<ResponseToComplaintDTO> result = new List<ResponseToComplaintDTO>();
            responseService.GetAll().ForEach(responseToComplaint => result.Add(ResponseToComplaintAdapter.ResponseToResponseDto(responseToComplaint)));
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/pharmacy/1
        public IActionResult Get(int id)
        {

            ResponseToComplaint response = responseService.Get(id);
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ResponseToComplaintAdapter.ResponseToResponseDto(response));
            }
        }

        [HttpPost("{pharmaciesAccessApiKey?}")]      // POST /api/pharmacy Request body: {"pharmacyUrl":"someUrl", "pharmacyName":"someName", "pharmacyAddress":"someAddress", "pharmacyApiKey":"someApiKey"}
        public IActionResult Add(ResponseToComplaintDTO dto, string pharmaciesAccessApiKey)
        {
            if (dto.Date.Equals("") || dto.Content.Length <= 0)
            {
                return BadRequest();
            }
            List<Pharmacy> allPharmacies = pharmacyService.GetAll();
            Pharmacy pharmacy = new Pharmacy();
            //Pharmacy pharmacy = dbContext.Pharmacies.FirstOrDefault(pharmacy => pharmacy.PharmacyApiKey == pharmaciesAccessApiKey);
            foreach(Pharmacy p in allPharmacies)
            {
                if (p.PharmacyApiKey == pharmaciesAccessApiKey)
                    pharmacy = p;
            }

            if(pharmacy != null)
             {
                List<Complaint> allComplaints = complaintService.GetAll();
                Complaint complaint = new Complaint();
                    foreach ( Complaint c in allComplaints)
                    {
                        if (c.PharmacyId == pharmacy.Id)
                            complaint = c;
                    }
                       // Complaint complaint = dbContext.Complaints.FirstOrDefault(complaint => complaint.PharmacyId == pharmacy.Id);

                    if(complaint != null) { 
                           
             
                      responseService.Save(ResponseToComplaintAdapter.ResponseDtoToResponse(dto));
             
                      return Ok();
                    }
                
             }
            return NotFound();
          

        }

        [HttpDelete("{id?}")]
        //bila nula, ne znam zasto NIKOLA???
        public IActionResult Delete(int id = 0)
        {
            ResponseToComplaint response = responseService.Get(id); 

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                responseService.Delete(response);
                return Ok();
            }
        }
    }
}
