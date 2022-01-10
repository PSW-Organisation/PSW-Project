using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Service;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/termsofrelocation")]
    [ApiController]
    [Authorize(Policy = "Manager")]
    public class TermsOfRelocationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITermOfRelocationEquipmentService _relocationEquipmentService;

        public TermsOfRelocationController(IMapper mapper, ITermOfRelocationEquipmentService relocationEquipmentService)
        {
            _mapper = mapper;
            _relocationEquipmentService = relocationEquipmentService;
        }

        [HttpPost]
        public ActionResult<List<TimeInterval>> GetTermsOfRelocation([FromBody] ParamsOfRelocationEquipmentDTO paramsOfRelocationEquipmentDTO)
        {
            var paramsOfRelocationEquipment = _mapper.Map<ParamsOfRelocationEquipment>(paramsOfRelocationEquipmentDTO);
            List<TimeInterval> listOfPossibleTermsOfRelocation = _relocationEquipmentService.GetFreePossibleTermsOfRelocation(paramsOfRelocationEquipment);
            return Ok(listOfPossibleTermsOfRelocation);   
        }

        [HttpPut]
        public ActionResult<ParamsOfRelocationEquipmentDTO> CreateTermOfRelocation([FromBody] ParamsOfRelocationEquipmentDTO paramsOfRelocationEquipmentDTO)
        {
            var paramsOfRelocationEquipment = _mapper.Map<ParamsOfRelocationEquipment>(paramsOfRelocationEquipmentDTO);
            var termOfRelocationEquipment = _relocationEquipmentService.CreateTermsOfRelocation(paramsOfRelocationEquipment);
            
            if (termOfRelocationEquipment == null) return BadRequest("unsuccessfully");

            ParamsOfRelocationEquipmentDTO termOfRelocationEquipmentDTO = _mapper.Map<ParamsOfRelocationEquipmentDTO>(termOfRelocationEquipment);
            return Ok(termOfRelocationEquipmentDTO);
        }

        [HttpGet]
        public ActionResult<List<ScheduleTermDTO>> GetAllTermsOfRelocation()
        {
            var result = _relocationEquipmentService.GetTermsOfRelocation();
            List<ScheduleTermDTO> scheduleTermDTOS = new List<ScheduleTermDTO>();
            foreach (TermOfRelocationEquipment t in result)
            {
                ScheduleTermDTO scheduleTermDTO = _mapper.Map<ScheduleTermDTO>(t);
                scheduleTermDTO.Type = "Relocation";
                scheduleTermDTOS.Add(scheduleTermDTO);
            }
            return Ok(scheduleTermDTOS);
        }

        [HttpGet]
        [Route("{roomId}")]
        public ActionResult<List<ScheduleTermDTO>> GetTermsOfRelocationByRoomId(int roomId)
        {
            var result = _relocationEquipmentService.GetTermsOfRelocationByRoomId(roomId);
            List<ScheduleTermDTO> scheduleTermDTOS = new List<ScheduleTermDTO>();
            foreach(TermOfRelocationEquipment t in result)
            {
                ScheduleTermDTO scheduleTermDTO = _mapper.Map<ScheduleTermDTO>(t);
                scheduleTermDTO.Type = "Relocation";
                scheduleTermDTOS.Add(scheduleTermDTO);
            }
            return Ok(scheduleTermDTOS);
        }

        [HttpPut]
        [Route("cancel/{termId}")]
        public ActionResult<bool> CancelRelocationTerm(int termId)
        {
            return Ok(_relocationEquipmentService.CancelRelocationTerm(termId));
        }
    }
}
