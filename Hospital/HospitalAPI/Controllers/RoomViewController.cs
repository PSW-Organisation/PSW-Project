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

namespace HospitalAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomViewController : ControllerBase
    {
        private IMapper _mapper;
        private IRoomGraphicService _roomGraphicService;
        private IRoomService _roomService;
        private readonly HospitalDbContext _dbcontext;

        public RoomViewController(IMapper mapper, IRoomGraphicService roomGraphicService, IRoomService roomService)
        {
            _mapper = mapper;
            _roomGraphicService = roomGraphicService;
            _roomService = roomService;
        }
        [HttpGet]
        public ActionResult<List<RoomGraphicDTO>> GetRoomGraphics()
        {
            var result = _roomGraphicService.GetRoomGraphics();
            return Ok(result.Value.Select(r=> _mapper.Map<RoomGraphicDTO>(r)).ToList());
        }

        [HttpPut]
        public IActionResult Put(RoomDTO dto)
        { 
            Room room = _dbcontext.Rooms.SingleOrDefault(room => room.Id.Equals(dto.Id));
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
