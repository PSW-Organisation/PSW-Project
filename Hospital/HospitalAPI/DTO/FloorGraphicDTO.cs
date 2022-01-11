using System.Collections.Generic;
using HospitalAPI.DTO;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class FloorGraphicDTO
    {
        public long Floor { get; set; }
        public string BuildingId { get; set; }
        public List<RoomGraphicDTO> RoomGraphics { get; set; }
    }
}
