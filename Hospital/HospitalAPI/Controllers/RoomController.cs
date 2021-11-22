using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;
using ehealthcare.Service;
using HospitalAPI.DTO;
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("api/baseRooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;
        private IMapper _mapper;
        public RoomController(IRoomService roomService,IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public List<RoomDTO> GetRooms()
        {
            var result = _roomService.GetAllRooms();
            return result.Select(r => _mapper.Map<RoomDTO>(r)).ToList();
        }
    }
}
