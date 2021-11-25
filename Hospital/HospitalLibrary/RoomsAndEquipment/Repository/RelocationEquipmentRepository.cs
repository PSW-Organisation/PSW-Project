using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEquipment.Repository
{
    public class RelocationEquipmentRepository : GenericDbRepository<TermOfRelocationEquipment>, IRelocationEquipmentRepository
    {
        private HospitalDbContext _dbContext;

        public RelocationEquipmentRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TermOfRelocationEquipment> GetTermsOfRelocationByRoomId(int id)
        {
            return _dbContext.TermOfRelocationEquipments.Where(t => t.IdDestinationRoom == id || t.IdSourceRoom == id).ToList();
        }

        public int GetNewID()
        {
            return GetAll().Count() + 1;
        }


        public List<TermOfRelocationEquipment> CheckTermOfRelocationByDate()
        {
            return _dbContext.TermOfRelocationEquipments.Where(t => t.FinishedRelocation == false && t.EndTime <= DateTime.Now && t.EndTime >= DateTime.Now.AddMinutes(-2)).ToList();
        }

    }
}
