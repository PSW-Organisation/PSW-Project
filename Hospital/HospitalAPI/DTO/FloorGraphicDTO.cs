using System.Collections.Generic;
using ehealthcare.Model;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class FloorGraphicDTO
    {
        public long Floor { get; set; }
        public IList<RoomGraphic> RoomGraphics { get; set; }
        public string BuildingId { get; set; }
    }
}
