using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.DoctorSchedule.Service;
using HospitalLibrary.FeedbackAndSurvey.Model;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShiftService _shiftService;

        public ShiftController(IMapper mapper, IShiftService shiftService)
        {
            _mapper = mapper;
            _shiftService = shiftService;
        }

        [HttpGet]
        public ActionResult<List<ShiftDTO>> GetShifts()
        {
            var result = _shiftService.GetAllShifts();
            return Ok(result.Select(r => _mapper.Map<ShiftDTO>(r)).ToList());
        }


        [HttpPost]
        public ActionResult<ShiftDTO> CreateShift(ShiftDTO shiftDto)
        {
            var result = _shiftService.CreateShift(_mapper.Map<Shift>(shiftDto));
            return Ok(_mapper.Map<ShiftDTO>(result));
        }

        [HttpPut]
        public ActionResult<ShiftDTO> UpdateShift(ShiftDTO shiftDto)
        {
            var shift = _shiftService.GetShift(shiftDto.Id);
            if (shift == null) return NotFound();
            var result = _shiftService.UpdateShift(shift, _mapper.Map<Shift>(shiftDto));
            return Ok(_mapper.Map<ShiftDTO>(result));
        }

        [HttpDelete("{id?}")]
        public ActionResult<ShiftDTO> Delete(int id)
        {
            var shift = _shiftService.GetShift(id);
            if (shift == null) return NotFound();
            var result = _shiftService.DeleteShift(shift);
            return Ok(_mapper.Map<ShiftDTO>(result));
        }
    }
}
