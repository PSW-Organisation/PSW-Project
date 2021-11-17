using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository;
using System.Collections.Generic;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public interface IFloorGraphicRepository : IGenericRepository<FloorGraphic> {

        public IList<FloorGraphic> GetAllWithRooms();
    }
}
