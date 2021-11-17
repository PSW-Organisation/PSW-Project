using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private IComplaintService complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            this.complaintService = complaintService;
        }

        [HttpGet]       // GET /api/complaint
        public IActionResult Get()
        {
            List<ComplaintDTO> result = new List<ComplaintDTO>();
            complaintService.GetAll().ForEach(complaint => result.Add(ComplaintAdapter.ComplaintToComplaintDto(complaint)));  
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/complaint/1
        public IActionResult Get(int id)
        {
            Complaint complaint = complaintService.Get(id);
            if (complaint == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ComplaintAdapter.ComplaintToComplaintDto(complaint));
            }
        }

        [HttpPost]      // POST /api/complaint Request body: {"complaintId":num,  "date":"date", "title":"someTitle", "content": "something", "pharmacyId":num}
        public IActionResult Add(ComplaintDTO dto)
        {
            if ( dto.Title.Length <= 0 || dto.Content.Length <= 0)
            {
                return BadRequest();
            }

            dto.Date = DateTime.Now;
            complaintService.Save(ComplaintAdapter.ComplaintDtoToComplaint(dto));
           
            return Ok();
        }

        [HttpDelete("{id?}")]       // DELETE /api2/complaint/1 
        //zasto je id bio id=0?
        public IActionResult Delete(int id)
        {
            Complaint complaint = complaintService.Get(id);
            if(complaint == null)
            {
                return NotFound();
            }
            else {
               complaintService.Delete(complaint);
               return Ok();
            }
        }
    }
}
