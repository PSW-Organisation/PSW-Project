using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public interface IFloorGraphicRepository : IGenericRepository<FloorGraphic>
    {
        public List<FloorGraphic> GetAllWithRooms();
        public int GetBuildingForRoom(int roomId);
    }
}
