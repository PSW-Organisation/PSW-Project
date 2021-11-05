using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ehealthcare.Model;


namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFeedbacksController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public PatientFeedbacksController(HospitalDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> PutFeedback(string id, PatientFeedback feedback)
        {
            if (id != feedback.Id)
            {
                return BadRequest();
            }

            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Feedbacks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult<PatientFeedback> PostFeedback(PatientFeedback feedback)
        {
            if (!ModelState.IsValid)
                return NoContent();

            _context.PatientFeedbacks.Add(feedback);
            _context.SaveChanges();

            return Ok(feedback);
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

        private bool FeedbackExists(string id)
        {
            return _context.PatientFeedbacks.Any(e => e.Id == id);
        }
    }
}
