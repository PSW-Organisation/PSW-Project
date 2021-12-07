using FluentResults;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Service
{
    public interface ITermOfRelocationEquipmentService
    {
        List<TimeInterval> GetFreePossibleTermsOfRelocation(ParamsOfRelocationEquipment paramsOfRelocationEquipment);
        List<TermOfRelocationEquipment> GetTermsOfRelocationByRoomId(int id);
        TermOfRelocationEquipment CreateTermsOfRelocation(ParamsOfRelocationEquipment paramsOfRelocationEquipment);
    }
}
