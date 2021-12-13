using HospitalLibrary.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Repository
{
    public interface ITermOfRenovationRepository : IGenericRepository<TermOfRenovation>
    {
        int GetNewID();
        List<TermOfRenovation> GetTermsOfRenovationByRoomId(int id);
        List<TermOfRenovation> GetPendingTerms();
    }
}
