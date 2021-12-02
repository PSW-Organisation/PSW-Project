using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.RoomsAndEquipment.Service;
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

    }
}
