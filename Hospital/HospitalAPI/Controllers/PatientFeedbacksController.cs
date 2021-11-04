using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ehealthcare.Model;
using HospitalLibrary.Controller;
using HospitalAPI.DTO;
using HospitalAPI.Mapper;
using System.Net;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFeedbacksController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly PatientFeedbackController _patientFeedbackController;

        public PatientFeedbacksController(HospitalDbContext context)
        {
            _context = context;
            _patientFeedbackController = new PatientFeedbackController(context);
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientFeedback>>> GetFeedbacks()
        {
            return await _context.PatientFeedbacks.ToListAsync();
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientFeedback>> GetFeedback(string id)
        {
            var feedback = await _context.PatientFeedbacks.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        // PUT: api/Feedbacks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, PatientFeedbackDto feedbackDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _patientFeedbackController.UpdatePatientFeedback(PatientFeedbackMapper.ToFeedback(feedbackDto));

            return Ok();
        }

        // POST: api/Feedbacks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult PostFeedback(PatientFeedbackDto feedbackDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _patientFeedbackController.AddPatientFeedback(PatientFeedbackMapper.ToFeedback(feedbackDto));

            return Ok();
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientFeedback>> DeleteFeedback(string id)
        {
            var feedback = await _context.PatientFeedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.PatientFeedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return feedback;
        }

        private bool FeedbackExists(int id)
        {
            return _context.PatientFeedbacks.Any(e => e.Id.Equals(id));
        }
    }
}
