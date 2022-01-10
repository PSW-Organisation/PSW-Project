using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ehealthcare.Service;
using HospitalAPI.DTO;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Service;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAPI.Controllers
{
    [Route("api/floorGraphics")]
    [ApiController]
    [Authorize(Policy = "Manager")]
    public class FloorGraphicController : ControllerBase
    {
        private readonly IFloorGraphicService _floorGraphicService;
        private readonly IMapper _mapper;

        public FloorGraphicController(IFloorGraphicService floorGraphicService, IMapper mapper)
        {
            _floorGraphicService = floorGraphicService;
            _mapper = mapper;
        }

        [HttpGet("{roomId}")]
        public int GetBuildingForRoom(int roomId)
        {
            return _floorGraphicService.GetBuildingForRoom(roomId);
        }

    }
}
