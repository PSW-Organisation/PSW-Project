using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ehealthcare.Model;
using HospitalAPI.DTO;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.FeedbackAndSurvey.Service;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly ISurveyService _surveyService;
        private readonly IMapper _mapper;

        public SurveyController(IMapper mapper, HospitalDbContext context, ISurveyService surveyService)
        {
            _surveyService = surveyService;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/<SurveyController>
        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<Survey>> GetAllSurveys()
        {
            return _surveyService.GetAllSurveys().ToList();
        }

        [HttpGet]
        [Route("surveyStats")]
        [Authorize(Policy = "Manager")]
        public ActionResult<IEnumerable<SurveyStats>> GetSurveyStats()
        {
            return _surveyService.GetSurveyStats().ToList();
        }

        // GET api/<SurveyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SurveyController>
        [HttpPost]
        [Authorize(Policy = "Patient")]
        public ActionResult PostSurvey(SurveyQuestionDto surveyQuestionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Survey mappedSurvey = _mapper.Map<Survey>(surveyQuestionDto);
            _surveyService.AddSurvey(mappedSurvey);
            return Ok();
        }

        // PUT api/<SurveyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SurveyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
