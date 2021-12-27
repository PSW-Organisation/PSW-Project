using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Repository
{
    public class TermOfRelocationEquipmentRepository : GenericDbRepository<TermOfRelocationEquipment>, ITermOfRelocationEquipmentRepository
    {
        private HospitalDbContext _dbContext;

        public TermOfRelocationEquipmentRepository(HospitalDbContext dbContext) : base(dbContext)
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
            return _dbContext.TermOfRelocationEquipments.Where(t => t.RelocationState == StateOfTerm.PENDING && t.Time.EndTime <= DateTime.Now && t.Time.EndTime >= DateTime.Now.AddMinutes(-2)).ToList();
        }

    }
}
