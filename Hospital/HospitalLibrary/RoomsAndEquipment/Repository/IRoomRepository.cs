using ehealthcare.Model;
using HospitalLibrary.Repository;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEquipment.Repository
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        List<Room> GetAllByName(string name);
    }

}
