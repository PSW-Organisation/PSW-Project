using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Repository
{
    public class TermOfRenovationRepository : GenericDbRepository<TermOfRenovation>, ITermOfRenovationRepository
    {
        private HospitalDbContext _dbContext;
        public TermOfRenovationRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetNewID()
        {
            return GetAll().Count() + 1;
        }

        public List<TermOfRenovation> GetTermsOfRenovationByRoomId(int id)
        {
            return _dbContext.TermOfRenovations.Where(t => t.IdRoomA == id || t.IdRoomB == id).ToList();
        }
    }
}
