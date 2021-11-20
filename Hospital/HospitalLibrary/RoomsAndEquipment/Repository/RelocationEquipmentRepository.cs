using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            return _dbContext.TermOfRelocationEquipments.Where(t => t.IdDestinationRoom == id || t.IdSourceRoom == id ).ToList();
        }
    }
}
