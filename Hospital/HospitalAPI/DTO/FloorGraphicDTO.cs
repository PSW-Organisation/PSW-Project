using System.Collections.Generic;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class FloorGraphicDTO
    {
        public long Floor { get; set; }
        public string BuildingId { get; set; }
        public List<RoomGraphic> RoomGraphics { get; set; }
    }
}
