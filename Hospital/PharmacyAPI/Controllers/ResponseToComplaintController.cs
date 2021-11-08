
using PharmacyAPI.Adapters;
using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace PharmacyAPI.Controllers
{

    [Route("api3/responses")]
    [ApiController]
    public class ResponseToComplaintController : ControllerBase
    {

        private readonly PharmacyDbContext dbContext;

        public ResponseToComplaintController(PharmacyDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]       // GET /api/response
        public IActionResult Get()
        {
            List<ResponseToComplaintDTO> result = new List<ResponseToComplaintDTO>();
            Console.WriteLine("Udjem u get");
            dbContext.ResponsesToComplaint.ToList().ForEach(responseToComplaint => result.Add(ResponseToComplaintAdapter.ResponseToResponseDto(responseToComplaint)));
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/pharmacy/1
        public IActionResult Get(long id)
        {

            ResponseToComplaint response = dbContext.ResponsesToComplaint.FirstOrDefault(response => response.ResponseToComplaintId == id);
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ResponseToComplaintAdapter.ResponseToResponseDto(response));
            }
        }

        [HttpPost]      // POST /api/pharmacy Request body: {"pharmacyUrl":"someUrl", "pharmacyName":"someName", "pharmacyAddress":"someAddress", "pharmacyApiKey":"someApiKey"}
        public IActionResult Add(ResponseToComplaintDTO dto)
        {
            if (dto.Date.Equals("") || dto.Content.Length <= 0)
            {
                return BadRequest();
            }


            long id = dbContext.ResponsesToComplaint.ToList().Count > 0 ? dbContext.ResponsesToComplaint.Max(ResponseToComplaint => ResponseToComplaint.ResponseToComplaintId) + 1 : 1;
            ResponseToComplaint response = ResponseToComplaintAdapter.ResponseDtoToResponse(dto);
            response.ResponseToComplaintId = id;

            dbContext.ResponsesToComplaint.Add(response);
            dbContext.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id?}")]
        public IActionResult Delete(long id = 0)
        {
            ResponseToComplaint response = dbContext.ResponsesToComplaint.SingleOrDefault(response => response.ResponseToComplaintId == id);
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.ResponsesToComplaint.Remove(response);
                dbContext.SaveChanges();
                return Ok();
            }
        }
    }
}
