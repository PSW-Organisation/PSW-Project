using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Events.Model;
using HospitalLibrary.Events.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSchedulingEventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public AppointmentSchedulingEventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet("abortStepBreakdown")]
        [Authorize(Policy = "Manager")]
        public ActionResult<object> GetAbortStepBreakdown()
        {
            return _eventService.GetAbortStepBreakdown();
        }

        [HttpGet("stepDurationBreakdown")]
        [Authorize(Policy = "Manager")]
        public ActionResult<object> GetStepDurationBreakdown()
        {
            return _eventService.GetStepDurationBreakdown();
        }

        [HttpGet("successfullSchedulingPerMonth")]
        [Authorize(Policy = "Manager")]
        public ActionResult<object> GetSuccessfullSchedulingPerMonth()
        {
            return _eventService.GetSuccessfullSchedulingPerMonth();
        }

        [HttpGet("unsuccessfullSchedulingPerMonth")]
        [Authorize(Policy = "Manager")]
        public ActionResult<object> GetUnsuccessfullSchedulingPerMonth()
        {
            return _eventService.GetUnsuccessfullSchedulingPerMonth();
        }

        [HttpGet("schedulingPerTimeOfDay")]
        [Authorize(Policy = "Manager")]
        public ActionResult<object> GetUnsuccessfullSchedulingPerTimeOfDay()
        {
            return _eventService.GetSchedulingPerTimeOfDay();
        }

        [HttpGet("unsuccessfullSchedulingByAgeGroup")]
        [Authorize(Policy = "Manager")]
        public ActionResult<object> GetUnsuccessfullSchedulingByAgeGroup()
        {
            return _eventService.GetUnsuccessfullSchedulingByAgeGroup();
        }

        [HttpGet("averageStats")]
        [Authorize(Policy = "Manager")]
        public ActionResult<object> GetAverageStats()
        {
            return _eventService.GetAverageStats();
        }

        [HttpPost]
        [Authorize(Policy = "Patient")]
        public ActionResult PostEvent(Event schedulingEvent)
        {
            _eventService.Save(schedulingEvent);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "Patient")]
        public ActionResult UpdateEventDuration(EventDurationDto durationDto)
        {
            _eventService.UpdateEventDuration(durationDto.EventGuid, durationDto.Duration);
            return Ok();
        }
    }
}
