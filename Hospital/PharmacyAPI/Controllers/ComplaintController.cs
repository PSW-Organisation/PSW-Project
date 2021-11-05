
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Adapters;
using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly PharmacyDbContext dbContext;

        public ComplaintController(PharmacyDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]       // GET /api/complaint
        public IActionResult Get()
        {
            List<ComplaintDTO> result = new List<ComplaintDTO>();
            
            dbContext.Complaints.ToList().ForEach(complaint => result.Add(ComplaintAdapter.ComplaintToComplaintDto(complaint)));
            return Ok(result);
        }

       

        [HttpGet("{id?}")]      // GET /api/complaint/1
        public IActionResult Get(long id)
        {
            
            Complaint complaint = dbContext.Complaints.FirstOrDefault(complaint => complaint.ComplaintId == id);
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
        //http://localhost:29631/api2/complaint/  + apiKey
        public IActionResult Add(ComplaintDTO dto, String hospitalApiKey)
        {
            if ( dto.Date.Equals("") || dto.Title.Length <= 0 || dto.Content.Length <= 0)
            {
                return BadRequest();
            }
            List<Hospital> result = new List<Hospital>();
            dbContext.Hospitals.ToList().ForEach(hospital => result.Add(hospital));
            foreach(Hospital hospital in result)
            {
               
                if(hospital.HospitalApiKey == hospitalApiKey)
                {
                    long id = dbContext.Complaints.ToList().Count > 0 ? dbContext.Complaints.Max(Complaint => Complaint.ComplaintId) + 1 : 1;
                    Complaint complaint = ComplaintAdapter.ComplaintDtoToComplaint(dto);
                    complaint.ComplaintId = id;
                    complaint.HospitalId = hospital.HospitalId;
                    dbContext.Complaints.Add(complaint);
                    dbContext.SaveChanges();
                    return Ok();
                }
            }
            return NotFound(); 
            

        }

        [HttpDelete("{id?}")]       // DELETE /api/complaint/1
        public IActionResult Delete(long id = 0)
        {
            
            Complaint complaint = dbContext.Complaints.SingleOrDefault(complaint => complaint.ComplaintId == id);
            if (complaint == null)
            {
                return NotFound();
            }
            else
            {
               
                dbContext.Complaints.Remove(complaint);
                dbContext.SaveChanges();
                return Ok();
            }
        }
    }
}
