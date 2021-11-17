using System.Collections.Generic;
using ehealthcare.Model;
using HospitalLibrary.Model;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class FloorGraphic : EntityDb
    {
        public long Floor { get; set; }
        public virtual IList<RoomGraphic> RoomGraphics { get; set; }
        public int BuildingId { get; set; }

        public FloorGraphic()
        {
        }
    }
}
