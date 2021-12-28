using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.GraphicalEditor.Service;
using FluentResults;
using ehealthcare.Model;
using Microsoft.Extensions.DependencyInjection;
using HospitalLibrary.RoomsAndEquipment.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace HospitalAPI.Controllers
{
    [Route("api/exterior")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Authorize(Policy = "Manager")]
    public class ExteriorViewController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IExteriorGraphicService _exteriorGraphicService;

        public ExteriorViewController(IMapper mapper, IExteriorGraphicService exteriorGraphicService)
        {
            _mapper = mapper;
            _exteriorGraphicService = exteriorGraphicService;
        }

        [HttpGet]
        public ActionResult<List<ExteriorGraphicDTO>> GetExteriorGraphics()
        {
            var result = _exteriorGraphicService.GetExteriorGraphics();
            return Ok(result.Select(r => _mapper.Map<ExteriorGraphicDTO>(r)).ToList());
        }

    }
}
