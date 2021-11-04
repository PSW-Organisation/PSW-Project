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
    public class VisitTimesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public VisitTimesController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/VisitTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitTime>>> GetVisitTimes()
        {
            return await _context.VisitTimes.ToListAsync();
        }

        // GET: api/VisitTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitTime>> GetVisitTime(string id)
        {
            var visitTime = await _context.VisitTimes.FindAsync(id);

            if (visitTime == null)
            {
                return NotFound();
            }

            return visitTime;
        }

        // PUT: api/VisitTimes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitTime(string id, VisitTime visitTime)
        {
            if (id != visitTime.Id)
            {
                return BadRequest();
            }

            _context.Entry(visitTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitTimeExists(id))
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

        // POST: api/VisitTimes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VisitTime>> PostVisitTime(VisitTime visitTime)
        {
            _context.VisitTimes.Add(visitTime);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VisitTimeExists(visitTime.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVisitTime", new { id = visitTime.Id }, visitTime);
        }

        // DELETE: api/VisitTimes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VisitTime>> DeleteVisitTime(string id)
        {
            var visitTime = await _context.VisitTimes.FindAsync(id);
            if (visitTime == null)
            {
                return NotFound();
            }

            _context.VisitTimes.Remove(visitTime);
            await _context.SaveChangesAsync();

            return visitTime;
        }

        private bool VisitTimeExists(string id)
        {
            return _context.VisitTimes.Any(e => e.Id == id);
        }
    }
}
