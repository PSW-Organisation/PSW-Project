using System.Collections.Generic;
using ehealthcare.Model;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class FloorGraphic : Entity
    {
        public long Floor { get; set; }
        public IList<RoomGraphic> RoomGraphics { get; set; }
        public string BuildingId { get; set; }

        public FloorGraphic() : base("undefinedKey")
        {
        }
    }
}
