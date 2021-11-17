using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.GraphicalEditor.Service;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ehealthcare.Model;
using HospitalLibrary.Service;
using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomViewController : ControllerBase
    {
        private IMapper _mapper;
        private IRoomGraphicService _roomGraphicService;
        private IFloorGraphicService _floorGraphicService;
        private IRoomService _roomService;
        private readonly HospitalDbContext _dbcontext;

        public RoomViewController(IMapper mapper, IRoomGraphicService roomGraphicService, IRoomService roomService, IFloorGraphicService floorGraphicService, HospitalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _roomGraphicService = roomGraphicService;
            _roomService = roomService;
            _floorGraphicService = floorGraphicService;
        }

        [HttpGet]
        public ActionResult<List<RoomGraphicDTO>> GetRoomGraphics()
        {
            var result = _roomGraphicService.GetRoomGraphics();
            return Ok(result.Value.Select(r => _mapper.Map<RoomGraphicDTO>(r)).ToList());
        }

        [HttpGet]
        [Route("floors")]
        public ActionResult<List<FloorGraphicDTO>> GetFloorGraphics()
        {
            var result = _floorGraphicService.GetFloorGraphics();
            return Ok(result.Value.Select(r => _mapper.Map<FloorGraphicDTO>(r)).ToList());
        }

        [HttpPut]
        public IActionResult Put(RoomDTO dto)
        { 
            Room room = _dbcontext.Rooms.SingleOrDefault(room => room.Id.Equals(dto.Id));
            room.RoomType = dto.RoomType;
            room.Name = dto.Name;
            room.Sector = dto.Sector;
            Room updatedRoom = _roomService.SetRoom(room);

            if (updatedRoom == null) {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<RoomDTO>(updatedRoom));
            }
        }



    }
}
