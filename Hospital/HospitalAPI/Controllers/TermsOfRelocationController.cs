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
        private IMapper _mapper;
        private IRelocationEquipmentService _relocationEquipmentService;

        public TermsOfRelocationController(IMapper mapper, IRelocationEquipmentService relocationEquipmentService)
        {
            _mapper = mapper;
            _relocationEquipmentService = relocationEquipmentService;
        }


        [HttpPost]
        public IActionResult GetTermsOfRelocation([FromBody] ParamsOfRelocationEquipmentDTO paramsOfRelocationEquipmentDTO)
        {
            ParamsOfRelocationEquipment paramsOfRelocationEquipment = paramsOfRelocationEquipmentDTO.GenerateModel();

            List<TimeInterval> listOfPossibleTermsOfRelocation =_relocationEquipmentService.GetFreePossibleTermsOfRelocation(paramsOfRelocationEquipment);
            return Ok(listOfPossibleTermsOfRelocation);   
        }

        [HttpPut]
        public IActionResult CreateTermOfRelocation([FromBody] ParamsOfRelocationEquipmentDTO paramsOfRelocationEquipmentDTO)
        {
            ParamsOfRelocationEquipment paramsOfRelocationEquipment = paramsOfRelocationEquipmentDTO.GenerateModel();

            TermOfRelocationEquipment termOfRelocationEquipment = _relocationEquipmentService.CreateTermsOfRelocation(paramsOfRelocationEquipment);
            if (termOfRelocationEquipment == null)
            {
                return BadRequest("unsuccessfully");
            }
            ParamsOfRelocationEquipmentDTO termOfRelocationEquipmentDTO = new ParamsOfRelocationEquipmentDTO(termOfRelocationEquipment);
            return Ok(termOfRelocationEquipmentDTO);
        }

    }
}
