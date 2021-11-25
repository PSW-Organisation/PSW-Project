using FluentResults;
using HospitalLibrary.RoomsAndEquipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public interface IRelocationEquipmentService
    {
        Result<IList<TermOfRelocationEquipment>> GetTermsOfRelocationEquipment();
        List<TimeInterval> GetFreePossibleTermsOfRelocation(ParamsOfRelocationEquipment paramsOfRelocationEquipment);
        List<TermOfRelocationEquipment> GetTermsOfRelocationByRoomId(int id);
        TermOfRelocationEquipment CreateTermsOfRelocation(ParamsOfRelocationEquipment paramsOfRelocationEquipment);
    }
}
