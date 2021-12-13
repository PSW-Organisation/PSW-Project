using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Service;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/termsofrenovation")]
    [ApiController]
    public class TermOfRenovationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITermOfRenovationService _termOfRenovationService;

        public TermOfRenovationController(IMapper mapper, ITermOfRenovationService termOfRenovationService)
        {
            _mapper = mapper;
            _termOfRenovationService = termOfRenovationService;
        }

        [HttpPost]
        public ActionResult<List<TimeInterval>> GetTermsOfRenovation([FromBody] ParamsOfRenovationDTO paramsOfRenovationDTO)
        {
            ParamsOfRenovation paramsOfRenovation = _mapper.Map<ParamsOfRenovation>(paramsOfRenovationDTO);
            List<TimeInterval> listOfPossibleTermsOfRenovation = _termOfRenovationService.GetFreePossibleTermsOfRenovation(paramsOfRenovation);
            return Ok(listOfPossibleTermsOfRenovation);
        }

        [HttpPut]
        public ActionResult<TermOfRenovationDTO> CreateTermOfRelocation([FromBody] TermOfRenovationDTO termOfRenovationDTO)
        {
            TermOfRenovation termOfRenovation = _mapper.Map<TermOfRenovation>(termOfRenovationDTO);
            TermOfRenovation termOfRenovationRetVal = _termOfRenovationService.CreateTermsOfRenovation(termOfRenovation);

            if (termOfRenovationRetVal == null) return BadRequest("unsuccessfully");

            TermOfRenovationDTO termOfRenovationDTORetVal = _mapper.Map<TermOfRenovationDTO>(termOfRenovationRetVal);
            return Ok(termOfRenovationDTORetVal);
        }


        [HttpGet]
        public ActionResult<List<ScheduleTermDTO>> GetTermsOfRenovation()
        {
            var result = _termOfRenovationService.GetTermsOfRenovation();
            List<ScheduleTermDTO> scheduleTermDTOS = new List<ScheduleTermDTO>();
            foreach (TermOfRenovation t in result)
            {
                ScheduleTermDTO scheduleTermDTO = _mapper.Map<ScheduleTermDTO>(t);
                scheduleTermDTO.Type = "Renovation";
                scheduleTermDTOS.Add(scheduleTermDTO);
            }
            return Ok(scheduleTermDTOS);
        }

        [HttpGet]
        [Route("{roomId}")]
        public ActionResult<List<ScheduleTermDTO>> GetTermsOfRenovationByRoomId(int roomId)
        {
            var result = _termOfRenovationService.GetTermsOfRenovationByRoomId(roomId);
            List<ScheduleTermDTO> scheduleTermDTOS = new List<ScheduleTermDTO>();
            foreach (TermOfRenovation t in result)
            {
                ScheduleTermDTO scheduleTermDTO = _mapper.Map<ScheduleTermDTO>(t);
                scheduleTermDTO.Type = "Renovation";
                scheduleTermDTOS.Add(scheduleTermDTO);
            }
            return Ok(scheduleTermDTOS);
        }


    }
}
