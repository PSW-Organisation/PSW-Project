
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Adapters;
using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api3/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private IComplaintService service;

        public ComplaintController(IComplaintService service)
        {
            this.service = service;
        }

        [HttpGet]       // GET /api/complaint
        public IActionResult Get()
        {
            List<ComplaintDTO> result = new List<ComplaintDTO>();
            foreach (Complaint c in service.GetAll())
            {
                result.Add(ComplaintAdapter.ComplaintToComplaintDto(c));
            }
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }



        [HttpGet("{id?}")]      // GET /api/complaint/1
        public IActionResult Get(long id)
        {

            Complaint complaint = service.Get(id);
            if (complaint == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ComplaintAdapter.ComplaintToComplaintDto(complaint));
            }
        }

        [HttpPost("{hospitalApiKey?}")]      // POST /api/complaint Request body: {"complaintId":num,  "date":"date", "title":"someTitle", "content": "something", "pharmacyId":num}
        //http://localhost:29631/api3/complaint/  + apiKey
        public IActionResult Add(ComplaintDTO dto, String hospitalApiKey)
        {
            if (dto.Title.Length <= 0 || dto.Content.Length <= 0) //date sklonjen iz provere
            {
                return BadRequest();
            }

            dto.Date = DateTime.Now;
            if (service.Save(ComplaintAdapter.ComplaintDtoToComplaint(dto), hospitalApiKey) == true)
            {
                return Ok();
            }
            else {
                return NotFound();
            }




        }

        [HttpDelete("{id?}")]       // DELETE /api/complaint/delete
        [Route("/delete")]
        public IActionResult Delete(long id)
        {
            Complaint complaint = service.Get(id);
            if (complaint == null)
            {
                return NotFound();
            }
            else
            {
                service.Delete(id);
                return Ok();
            }
        }
    }
}
