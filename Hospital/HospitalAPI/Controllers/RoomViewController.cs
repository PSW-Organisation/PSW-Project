using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.GraphicalEditor.Service;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ehealthcare.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomViewController : ControllerBase
    {
        private IMapper _mapper;
        private IRoomGraphicService _roomGraphicService;

        public RoomViewController(IMapper mapper, IRoomGraphicService roomGraphicService)
        {
            _mapper = mapper;
            _roomGraphicService = roomGraphicService;
        }
        [HttpGet]
        public ActionResult<List<RoomGraphicDTO>> GetRoomGraphics()
        {
            var result = _roomGraphicService.GetRoomGraphics();
            return Ok(result.Value.Select(r=> _mapper.Map<RoomGraphicDTO>(r)).ToList());
        }
            
    }
}
