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

namespace HospitalAPI.Controllers
{
    [Route("api/exterior")]
    [ApiController]
    public class ExteriorViewController : Controller
    {
        private IMapper _mapper;
        private IExteriorGraphicService _exteriorGraphicService;


        public ExteriorViewController(IMapper mapper, IExteriorGraphicService exteriorGraphicService)
        {
            _mapper = mapper;
            _exteriorGraphicService = exteriorGraphicService;
        }
        [HttpGet]
        public ActionResult<List<ExteriorGraphicDTO>> GetExteriorGraphics()
        {
            var result = _exteriorGraphicService.GetExteriorGraphics();
            return Ok(result.Value.Select(r => _mapper.Map<ExteriorGraphicDTO>(r)).ToList());
        }

    }
}
