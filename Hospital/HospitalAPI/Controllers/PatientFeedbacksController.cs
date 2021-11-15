using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ehealthcare.Model;
using HospitalAPI.DTO;
using HospitalAPI.Mapper;
using System.Net;
using AutoMapper;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.FeedbackAndSurvey.Repository;
using HospitalLibrary.FeedbackAndSurvey.Service;
using HospitalLibrary.Service;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFeedbacksController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IPatientFeedbackService _patientFeedbackService;
        private readonly IMapper _mapper;


        public PatientFeedbacksController(IPatientFeedbackService patientFeedbackService, IMapper mapper)
        {
            _patientFeedbackService = patientFeedbackService;
            _mapper = mapper;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public ActionResult<IEnumerable<PatientFeedback>> GetFeedbacks()
        {
            return _patientFeedbackService.GetAllFeedbacks().ToList();
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
        public IActionResult PutFeedback(int id, PatientFeedbackDTO feedbackDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _patientFeedbackService.UpdatePatientFeedback(_mapper.Map<PatientFeedback>(feedbackDto));

            return Ok();
        }

        // POST: api/Feedbacks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult PostFeedback(PatientFeedbackDTO feedbackDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _patientFeedbackService.AddPatientFeedback(_mapper.Map<PatientFeedback>(feedbackDto));

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
