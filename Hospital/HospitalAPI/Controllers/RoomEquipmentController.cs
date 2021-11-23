using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HospitalAPI.Controllers
{
    [Route("api/roomEquipments")]
    [ApiController]
    public class RoomEquipmentController : ControllerBase
    {
        private IMapper _mapper;
        private IRoomEquipmentService _roomEquipmentService;


        public RoomEquipmentController(IMapper mapper, IRoomEquipmentService roomEquipmentService)
        {
            _mapper = mapper;
            _roomEquipmentService = roomEquipmentService;
        }

        [HttpGet]
        public ActionResult<List<RoomEquipmentDTO>> GetAllEquipmentInRooms()
        {
            var result = _roomEquipmentService.GetAllEquipmentInRooms();
            return Ok(result.Value.Select(r => _mapper.Map<RoomEquipmentDTO>(r)).ToList());
        }

        [HttpGet]
        [Route("quantity")]
        public ActionResult<List<RoomEquipmentQuantityDTO>> GetRoomEquipmentQuantity()
        {
            var result = _roomEquipmentService.GetRoomEquipmentQuantity();
            return Ok(result.Select(r => _mapper.Map<RoomEquipmentQuantityDTO>(r)).ToList());
        }

        [HttpGet]
        [Route("equipment/{equipmentName}")]
        public ActionResult<List<RoomEquipmentDTO>> GetEquipmentInRooms(string equipmentName)
        {
            var result = _roomEquipmentService.GetEquipmentInRooms(equipmentName);
            return Ok(result.Select(r => _mapper.Map<RoomEquipmentDTO>(r)).ToList());
        }

        [HttpGet("{roomId}")]
        public ActionResult<List<RoomEquipmentDTO>> GetAllEquipmentInRoom(int roomId)
        {
            var result = _roomEquipmentService.GetAllEquipmentInRoom(roomId);
            return Ok(result.Select(r => _mapper.Map<RoomEquipmentDTO>(r)).ToList());
        }

    }
}
