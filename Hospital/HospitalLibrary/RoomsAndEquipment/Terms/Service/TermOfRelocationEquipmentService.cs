using FluentResults;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Service
{
    public class TermOfRelocationEquipmentService : ITermOfRelocationEquipmentService
    {

        private readonly ITermOfRelocationEquipmentRepository _relocationEquipmentRepository;
        private readonly ITermOfRenovationRepository _termOfRenovationRepository;
        private readonly TermsUtils _termsUtils;

        public TermOfRelocationEquipmentService(ITermOfRelocationEquipmentRepository relocationEquipmentRepository, ITermOfRenovationRepository termOfRenovationRepository)
        {
            _relocationEquipmentRepository = relocationEquipmentRepository;
            _termOfRenovationRepository = termOfRenovationRepository;
            _termsUtils = new TermsUtils();
        }

        public List<TermOfRelocationEquipment> GetTermsOfRelocationByRoomId(int id)
        {
            return _relocationEquipmentRepository.GetTermsOfRelocationByRoomId(id);
        }


        public List<TimeInterval> GetFreePossibleTermsOfRelocation(ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            List<TermOfRelocationEquipment> sourceRoomTerms = GetTermsOfRelocationByRoomId(paramsOfRelocationEquipment.IdSourceRoom);
            List<TermOfRenovation> sourceRoomRenovationTerms = _termOfRenovationRepository.GetTermsOfRenovationByRoomId(paramsOfRelocationEquipment.IdSourceRoom);
            List<TimeInterval> sourceRoomTimeInteval = GetAllTimeInterval(sourceRoomRenovationTerms, sourceRoomTerms);

            List<TermOfRelocationEquipment> destinationRoomTerms = GetTermsOfRelocationByRoomId(paramsOfRelocationEquipment.IdDestinationRoom);
            List<TermOfRenovation> destinationRoomRenovationTerms = _termOfRenovationRepository.GetTermsOfRenovationByRoomId(paramsOfRelocationEquipment.IdSourceRoom);
            List<TimeInterval> destinationRoomTimeInterval = GetAllTimeInterval(destinationRoomRenovationTerms, destinationRoomTerms);

            List<TimeInterval> freePossibleTermsOfRelocation = _termsUtils.GetFreePossibleTimeIntevalForTwoRooms(new RoomTermParams(sourceRoomTimeInteval, destinationRoomTimeInterval, paramsOfRelocationEquipment.StartTime, paramsOfRelocationEquipment.EndTime, paramsOfRelocationEquipment.DurationInMinutes));

            return freePossibleTermsOfRelocation;
        }

        public TermOfRelocationEquipment CreateTermsOfRelocation(ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            TermOfRelocationEquipment newTermOfRelocationEquipment = new TermOfRelocationEquipment(paramsOfRelocationEquipment);
            List<TimeInterval> termForRelocation = GetFreePossibleTermsOfRelocation(paramsOfRelocationEquipment);
            if (termForRelocation.Count == 1)
            {
                newTermOfRelocationEquipment.StartTime = termForRelocation[0].StartTime;
                newTermOfRelocationEquipment.EndTime = termForRelocation[0].EndTime;
                newTermOfRelocationEquipment.Id = _relocationEquipmentRepository.GetNewID();

                _relocationEquipmentRepository.Insert(newTermOfRelocationEquipment);
                return newTermOfRelocationEquipment;
            }
            else
            {
                return null;
            }
        }


        private List<TimeInterval> GetAllTimeInterval(List<TermOfRenovation> termOfRenovationRoom, List<TermOfRelocationEquipment> termOfRelocationRoom)
        {
            List<TimeInterval> allTimeInteval = new List<TimeInterval>();
            if (termOfRenovationRoom != null)
                foreach (TermOfRenovation term in termOfRenovationRoom) allTimeInteval.Add(new TimeInterval(term.StartTime, term.EndTime));
            if (termOfRelocationRoom != null)
                foreach (TermOfRelocationEquipment term in termOfRelocationRoom) allTimeInteval.Add(new TimeInterval(term.StartTime, term.EndTime));

            return allTimeInteval;
        }

    }

}
