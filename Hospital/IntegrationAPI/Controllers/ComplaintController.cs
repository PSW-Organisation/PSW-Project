﻿using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
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
        private readonly IntegrationDbContext dbContext;

        public ComplaintController(IntegrationDbContext context)
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
            
            Complaint complaint = dbContext.Complaints.FirstOrDefault(complaint => complaint.Id == id);
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

            
            int id = dbContext.Complaints.ToList().Count > 0 ? dbContext.Complaints.Max(Complaint => Complaint.Id) + 1 : 1;

            DateTime date = DateTime.Now;
            Complaint complaint = ComplaintAdapter.ComplaintDtoToComplaint(dto);
            complaint.Id = id;
            complaint.Date = date;
            dbContext.Complaints.Add(complaint);
            dbContext.SaveChanges();
            return Ok();

        }

        [HttpPut]      // 
        public IActionResult AddNew(ComplaintDTO dto)
        {
            if (dto.Title.Length <= 0 || dto.Content.Length <= 0)
            {
                return BadRequest();
            }


            int id = dbContext.Complaints.ToList().Count > 0 ? dbContext.Complaints.Max(Complaint => Complaint.Id) + 1 : 1;

            DateTime date = DateTime.Now;
            Complaint complaint = ComplaintAdapter.ComplaintDtoToComplaint(dto);
            complaint.Id = id;
            complaint.Date = date;
            dbContext.Complaints.Add(complaint);
            dbContext.SaveChanges();
            return Ok();

        }


        [HttpDelete("{id?}")]       // DELETE /api/complaint/1
        public IActionResult Delete(long id = 0)
        {
            
            Complaint complaint = dbContext.Complaints.SingleOrDefault(complaint => complaint.Id == id);
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
