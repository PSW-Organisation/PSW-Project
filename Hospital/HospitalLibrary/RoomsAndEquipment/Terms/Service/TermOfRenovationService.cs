using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Service
{
    public class TermOfRenovationService : ITermOfRenovationService
    {
        private readonly ITermOfRenovationRepository _termOfRenovationRepository;
        private readonly ITermOfRelocationEquipmentRepository _termOfRelocationEquipmentRepository;
        private readonly TermsUtils _termsUtils;

        public TermOfRenovationService(ITermOfRenovationRepository termOfRenovationRepository, ITermOfRelocationEquipmentRepository termOfRelocationEquipmentRepository)
        {
            _termOfRenovationRepository = termOfRenovationRepository;
            _termOfRelocationEquipmentRepository = termOfRelocationEquipmentRepository;
            _termsUtils = new TermsUtils();
        }

        public TermOfRenovation CreateTermsOfRenovation(TermOfRenovation termOfRenovation)
        {
            TermOfRenovation newTermOfRelocationEquipment = termOfRenovation;
            List<TimeInterval> termForRelocation = GetFreePossibleTermsOfRenovation(new ParamsOfRenovation(termOfRenovation.StartTime, termOfRenovation.EndTime, termOfRenovation.DurationInMinutes, termOfRenovation.IdRoomA, termOfRenovation.IdRoomB));
            if (termForRelocation.Count == 1)
            {
                newTermOfRelocationEquipment.StartTime = termForRelocation[0].StartTime;
                newTermOfRelocationEquipment.EndTime = termForRelocation[0].EndTime;
                newTermOfRelocationEquipment.Id = _termOfRenovationRepository.GetNewID();

                _termOfRenovationRepository.Insert(newTermOfRelocationEquipment);
                return newTermOfRelocationEquipment;
            }
            else
            {
                return null;
            }
        }

        public List<TimeInterval> GetFreePossibleTermsOfRenovation(ParamsOfRenovation paramsOfRenovation)
        {

            List<TermOfRenovation> termOfRenovationRoomA = _termOfRenovationRepository.GetTermsOfRenovationByRoomId(paramsOfRenovation.IdRoomA);
            List<TermOfRelocationEquipment> termOfRelocationRoomA = _termOfRelocationEquipmentRepository.GetTermsOfRelocationByRoomId(paramsOfRenovation.IdRoomA);
            List<TimeInterval> timeIntervalOfRenovationRoomA = GetAllTimeInterval(termOfRenovationRoomA, termOfRelocationRoomA);

            List<TimeInterval> freePossibleTermsOfRenovation;

            if (paramsOfRenovation.IdRoomB != -1)
            {
                List<TermOfRenovation> termOfRenovationRoomB = _termOfRenovationRepository.GetTermsOfRenovationByRoomId(paramsOfRenovation.IdRoomB);
                List<TermOfRelocationEquipment> termOfRelocationRoomB = _termOfRelocationEquipmentRepository.GetTermsOfRelocationByRoomId(paramsOfRenovation.IdRoomB);
                List<TimeInterval> timeIntervalOfRenovationRoomB = GetAllTimeInterval(termOfRenovationRoomB, termOfRelocationRoomB);

                freePossibleTermsOfRenovation = _termsUtils.GetFreePossibleTimeIntevalForTwoRooms(new RoomTermParams(timeIntervalOfRenovationRoomA, timeIntervalOfRenovationRoomB, paramsOfRenovation.StartTime, paramsOfRenovation.EndTime, paramsOfRenovation.DurationInMinutes));

            }
            else
            {
                freePossibleTermsOfRenovation = _termsUtils.GetFreePossibleTimeIntevalForOneRoom(new RoomTermParams(timeIntervalOfRenovationRoomA, null, paramsOfRenovation.StartTime, paramsOfRenovation.EndTime, paramsOfRenovation.DurationInMinutes));
            }

            return freePossibleTermsOfRenovation;
        }

        public IList<TermOfRenovation> GetTermsOfRenovation()
        {
            return _termOfRenovationRepository.GetAll();
        }

        public List<TermOfRenovation> GetTermsOfRenovationByRoomId(int id)
        {
            return _termOfRenovationRepository.GetTermsOfRenovationByRoomId(id);
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

        public bool CancelRenovationTerm(int id)
        {
            TermOfRenovation termOfRenovation = _termOfRenovationRepository.Get(id);
            if (_termsUtils.IsCancelAllowed(termOfRenovation.StartTime))
            {
                termOfRenovation.StateOfRenovation = StateOfTerm.CANCELED;
                _termOfRenovationRepository.Save(termOfRenovation);
                return true;
            }
            else
            {
                return false;
            }
        }
  

    }
}
