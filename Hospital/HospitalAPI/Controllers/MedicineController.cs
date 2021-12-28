using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Medicines.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/medicine")]
    [ApiController]
    [Authorize(Policy = "Manager")]
    public class MedicineController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMedicineService _medicineService;
        public MedicineController(IMapper mapper, IMedicineService _medicineService)
        {
            this._mapper = mapper;
            this._medicineService = _medicineService;
        }

        [HttpGet] // GET /api/medicine
        public IActionResult Get()
        {
            var result = _medicineService.GetAllMedicine();
            return Ok(result.Select(m => _mapper.Map<MedicineDTO>(m)).ToList());
        }

        [HttpPut]
        public IActionResult Put(MedicineDTO dto)
        {
            Medicine medicine = _medicineService.GetMedicine(dto.Id);
            if (medicine == null)
            {
                return NotFound();
            }
            _medicineService.Update(_mapper.Map<Medicine>(dto));
            return Ok();
        }

        [HttpPost]// POST /api/medicine Request body:
        public IActionResult Add(MedicineDTO dto)
        {
            if (dto.MedicineName.Length <= 0 || dto.MedicineAmount <= 0)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<MedicineDTO>(_medicineService.Save(_mapper.Map<Medicine>(dto))));

        }

        [HttpGet("{id?}")]// GET /api/medicine/1:
        public IActionResult GetMedicineByName(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Medicine medicine = _medicineService.GetMedicine(id);
            if (medicine == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MedicineDTO>(_medicineService.GetMedicine(id)));
        }

        [HttpDelete("{id?}")]// DELETE /api/medicine/1
        public IActionResult Delete(int id)
        {
            Medicine medicine = _medicineService.GetMedicine(id);
            if (medicine == null)
            {
                return NotFound();
            }
            else
            {
                _medicineService.DeleteMedicine(medicine);
                return Ok();
            }
        }
    }
}
