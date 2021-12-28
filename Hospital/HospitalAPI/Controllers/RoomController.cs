using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;
using HospitalAPI.DTO;
using System.Linq;
using HospitalLibrary.RoomsAndEquipment.Service;
using ehealthcare.Model;
using HospitalLibrary.RoomsAndEquipment.Model;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAPI.Controllers
{
    [Route("api/baseRooms")]
    [ApiController]
    [Authorize(Policy = "Manager")]
    public class RoomController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoomService _roomService;
        private readonly HospitalDbContext _dbcontext;

        public RoomController(IMapper mapper, IRoomService roomService, HospitalDbContext dbcontext)
        {
            _mapper = mapper;
            _roomService = roomService;
            _dbcontext = dbcontext;
        }
        
        [HttpGet]
        public List<RoomDTO> GetRooms()
        {
            var result = _roomService.GetAllRooms();
            return result.Select(r => _mapper.Map<RoomDTO>(r)).ToList();
        }

        [HttpGet("{id}")]
        public RoomDTO GetRoom(int id)
        {
            var result = _roomService.GetRoomById(id);
            return _mapper.Map<RoomDTO>(result);
        }

        [HttpGet]
        [Route("rooms")]
        public ActionResult<List<Room>> GetRoomsByName([FromQuery(Name = "name")] string name)
        {
            if (name == null) name = "";
            var result = _roomService.GetAllByName(name);
            return Ok(result.Select(r => _mapper.Map<RoomDTO>(r)).ToList());
        }

        [HttpPut]
        public ActionResult<RoomDTO> Put(RoomDTO dto)
        {
            Room room = _dbcontext.Rooms.SingleOrDefault(room => room.Id.Equals(dto.Id));
            room.RoomType = dto.RoomType;
            room.Name = dto.Name;
            room.Sector = dto.Sector;
            Room updatedRoom = _roomService.SetRoom(room);

            if (updatedRoom == null) return NotFound();

            return Ok(_mapper.Map<RoomDTO>(updatedRoom));
        }

    }
}
