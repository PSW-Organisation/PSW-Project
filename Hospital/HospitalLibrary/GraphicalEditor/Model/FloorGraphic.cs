using System.Collections.Generic;
using HospitalLibrary.Model;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class FloorGraphic : EntityDb
    {
        public int BuildingId { get; set; }
        public int Floor { get; set; }
        public virtual List<RoomGraphic> RoomGraphics { get; set; }

        public FloorGraphic()
        {
        }
    }
}
