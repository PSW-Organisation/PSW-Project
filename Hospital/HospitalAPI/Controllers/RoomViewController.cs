using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.GraphicalEditor.Service;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using HospitalLibrary.RoomsAndEquipment.Model;
using ehealthcare.Model;
using HospitalLibrary.RoomsAndEquipment.Service;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    [Authorize(Policy = "Manager")]

    public class RoomViewController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoomGraphicService _roomGraphicService;
        private readonly IFloorGraphicService _floorGraphicService;

        public RoomViewController(IMapper mapper, IRoomGraphicService roomGraphicService, IFloorGraphicService floorGraphicService)
        {
            _mapper = mapper;
            _roomGraphicService = roomGraphicService;
            _floorGraphicService = floorGraphicService;
        }

        [HttpGet]
        public ActionResult<List<RoomGraphicDTO>> GetRoomGraphics()
        {
            var result = _roomGraphicService.GetRoomGraphics();
            return Ok(result.Select(r => _mapper.Map<RoomGraphicDTO>(r)).ToList());
        }

        [HttpGet]
        [Route("floors")]
        public ActionResult<List<FloorGraphicDTO>> GetFloorGraphics()
        {
            var result = _floorGraphicService.GetFloorGraphics();
            return Ok(result.Select(r => _mapper.Map<FloorGraphicDTO>(r)).ToList());
        }

        [HttpGet]
        [Route("merge")]
        public ActionResult<List<RoomMinimalInfoDTO>> GetAllPossibleRoomsForMergWithRoomById([FromQuery(Name = "id")] int id)
        {
            List<Room> rooms = _roomGraphicService.GetAllPossibleRoomsForMergWithRoomById(id);
            if(rooms == null)
            {
                return NotFound("error");
            }

            return Ok(rooms.Select(r => _mapper.Map<RoomMinimalInfoDTO>(r)).ToList());
        }

    }
}
