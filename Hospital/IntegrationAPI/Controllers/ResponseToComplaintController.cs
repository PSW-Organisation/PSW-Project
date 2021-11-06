
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using IntegrationLibrary.Model;
using IntegrationAPI.DTO;
using IntegrationAPI.Adapters;

namespace IntegrationAPI.Controllers
{

    [Route("api2/responses")]
    [ApiController]
    public class ResponseToComplaintController : ControllerBase
    {

        private readonly IntegrationDbContext dbContext;

        public ResponseToComplaintController(IntegrationDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]       // GET /api/response
        public IActionResult Get()
        {
            List<ResponseToComplaintDTO> result = new List<ResponseToComplaintDTO>();
            dbContext.ResponseToComplaint.ToList().ForEach(responseToComplaint => result.Add(ResponseToComplaintAdapter.ResponseToResponseDto(responseToComplaint)));
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/pharmacy/1
        public IActionResult Get(long id)
        {

            ResponseToComplaint response = dbContext.ResponseToComplaint.FirstOrDefault(response => response.ResponseToComplaintId == id);
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
            Pharmacy pharmacy = dbContext.Pharmacies.FirstOrDefault(pharmacy => pharmacy.PharmacyApiKey == pharmaciesAccessApiKey);
            if(pharmacy != null)
                {
                    Complaint complaint = dbContext.Complaints.FirstOrDefault(complaint => complaint.PharmacyId == pharmacy.PharmacyId);
                        if(complaint != null) { 
                            long id = dbContext.ResponseToComplaint.ToList().Count > 0 ? dbContext.ResponseToComplaint.Max(ResponseToComplaint => ResponseToComplaint.ResponseToComplaintId) + 1 : 1;
                             ResponseToComplaint response = ResponseToComplaintAdapter.ResponseDtoToResponse(dto);
                            response.ResponseToComplaintId = id;
                            response.ComplaintId = complaint.ComplaintId;
                            dbContext.ResponseToComplaint.Add(response);
                            dbContext.SaveChanges();
                            return Ok();
                         }
                
            }
            return NotFound();
          

        }


    }
}
