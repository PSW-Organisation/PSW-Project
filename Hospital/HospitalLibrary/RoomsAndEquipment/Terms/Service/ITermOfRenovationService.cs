using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Service
{
    public interface ITermOfRenovationService
    {
        List<TimeInterval> GetFreePossibleTermsOfRenovation(ParamsOfRenovation paramsOfRenovation);
        TermOfRenovation CreateTermsOfRenovation(TermOfRenovation termOfRenovation);
        IList<TermOfRenovation> GetTermsOfRenovation();
        List<TermOfRenovation> GetTermsOfRenovationByRoomId(int id);

    }
}
