using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Service;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Service
{
    public class TermOfRenovationService : ITermOfRenovationService
    {
        private readonly ITermOfRenovationRepository _termOfRenovationRepository;
        private readonly ITermOfRelocationEquipmentRepository _termOfRelocationEquipmentRepository;
        private readonly TermsUtils _termsUtils;

        private readonly IRoomService _roomService;
        private readonly IFloorGraphicService _floorGraphicService;

        public TermOfRenovationService(ITermOfRenovationRepository termOfRenovationRepository, ITermOfRelocationEquipmentRepository termOfRelocationEquipmentRepository, IRoomService roomService, IFloorGraphicService floorGraphicService)
        {
            _termOfRenovationRepository = termOfRenovationRepository;
            _termOfRelocationEquipmentRepository = termOfRelocationEquipmentRepository;
            _termsUtils = new TermsUtils();
            _roomService = roomService;
            _floorGraphicService = floorGraphicService;
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

                freePossibleTermsOfRenovation  = _termsUtils.GetFreePossibleTimeIntevalForTwoRooms(new RoomTermParams(timeIntervalOfRenovationRoomA, timeIntervalOfRenovationRoomB, paramsOfRenovation.StartTime, paramsOfRenovation.EndTime, paramsOfRenovation.DurationInMinutes));

            }else
            {
                freePossibleTermsOfRenovation = _termsUtils.GetFreePossibleTimeIntevalForOneRoom(new RoomTermParams(timeIntervalOfRenovationRoomA, null, paramsOfRenovation.StartTime, paramsOfRenovation.EndTime, paramsOfRenovation.DurationInMinutes));
            }

            return freePossibleTermsOfRenovation;
        }


        private List<TimeInterval> GetAllTimeInterval(List<TermOfRenovation> termOfRenovationRoom, List<TermOfRelocationEquipment> termOfRelocationRoom)
        {
            List<TimeInterval> allTimeInteval = new List<TimeInterval>();
            if(termOfRenovationRoom != null)
                foreach (TermOfRenovation term in termOfRenovationRoom) allTimeInteval.Add(new TimeInterval(term.StartTime, term.EndTime));
            if(termOfRelocationRoom != null)
                foreach (TermOfRelocationEquipment term in termOfRelocationRoom) allTimeInteval.Add(new TimeInterval(term.StartTime, term.EndTime));

            return allTimeInteval;
        }




        public void MergeRooms(TermOfRenovation termOfRenovation)
        {
            /*
            TODO: ovu metodu cemo pozvati kad bude trebalo da se radi mergovanje
            - napraviti novi room
            - napraviti novi roomGraphics za novi room
            - prebaciti svu opremu iz roomA i roomB u novi room  
            - obrisati room sa IDRoomA i IDRoomB
            - obrisati roomGraphics za IDRoomA i IDRoomB
            */

            Room roomA = _roomService.GetRoomById(termOfRenovation.IdRoomA);
            Room roomB = _roomService.GetRoomById(termOfRenovation.IdRoomB);

            RoomGraphic roomGraphicA = _floorGraphicService.GetRoomGraphicByRoomId(termOfRenovation.IdRoomA);
            RoomGraphic roomGraphicB = _floorGraphicService.GetRoomGraphicByRoomId(termOfRenovation.IdRoomB);

            Room newRoom = _roomService.CreateNewRoom(termOfRenovation.NewNameForRoomA, termOfRenovation.NewSectorForRoomA, 2, termOfRenovation.NewRoomTypeForRoomA);
            //RoomGraphic newRoomGraphic = 



        }




    }
}
