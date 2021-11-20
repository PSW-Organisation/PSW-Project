using FluentResults;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class RelocationEquipmentService : IRelocationEquipmentService
    {

        private IRelocationEquipmentRepository _relocationEquipmentRepository;

        public RelocationEquipmentService(IRelocationEquipmentRepository relocationEquipmentRepository)
        {
            _relocationEquipmentRepository = relocationEquipmentRepository;
        }

        public Result<IList<TermOfRelocationEquipment>> GetTermsOfRelocationEquipment()
        {
            throw new NotImplementedException();
        }

        
        public List<TermOfRelocationEquipment> GetTermsOfRelocationByRoomId(int id)
        {
            return _relocationEquipmentRepository.GetTermsOfRelocationByRoomId(id);
        }
        

        public void sortTerms(List<TermOfRelocationEquipment> terms) 
        {
            terms.Sort((t1, t2) => t1.StartTime.CompareTo(t2.StartTime));
        }

        public List<TimeInterval> GetFreePossibleTermsOfRelocation(ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            List<TimeInterval> freePossibleTermsOfRelocation = new List<TimeInterval>();

            List<TermOfRelocationEquipment> sourceRoomTerms = GetTermsOfRelocationByRoomId(paramsOfRelocationEquipment.IdSourceRoom);
            List<TermOfRelocationEquipment> destinationRoomTerms = GetTermsOfRelocationByRoomId(paramsOfRelocationEquipment.IdDestinationRoom);
            List<TermOfRelocationEquipment> unionTerms = new List<TermOfRelocationEquipment>();


            foreach (TermOfRelocationEquipment t in sourceRoomTerms) unionTerms.Add(t);
            foreach (TermOfRelocationEquipment t in destinationRoomTerms) unionTerms.Add(t);
            sortTerms(unionTerms);

            List<TimeInterval> allTimeInteval = new List<TimeInterval>();
            foreach (TermOfRelocationEquipment t in unionTerms) allTimeInteval.Add(new TimeInterval(t.StartTime, t.EndTime));

            List<TimeInterval> unionTimeInteval = new List<TimeInterval>();

            int itStek = 0;
            if (allTimeInteval.Count != 0)
            {
                unionTimeInteval.Add(allTimeInteval[0]);
                for (int i = 1; i < allTimeInteval.Count; i++)
                {
                    if (unionTimeInteval[itStek].EndTime < allTimeInteval[i].StartTime)
                    {
                        unionTimeInteval.Add(allTimeInteval[i]);
                        itStek++;
                    }
                    else if (unionTimeInteval[itStek].StartTime < allTimeInteval[i].EndTime)
                    {
                        unionTimeInteval[itStek].EndTime = allTimeInteval[i].EndTime;
                    }
                }
            }

          
            // sada imamo unionTimeInteval koji sadrzi sve unije termina prostorije 1 i prostorije 2
            // i sada ja treba da uzmem samo one koji ulaze u opseg onaj poslat
            List<TimeInterval> unionTimeIntevalInRange = new List<TimeInterval>();
            foreach(TimeInterval timeInteval in unionTimeInteval)
            {
                if (
                    !((timeInteval.StartTime < paramsOfRelocationEquipment.StartTime && timeInteval.EndTime < paramsOfRelocationEquipment.StartTime) ||
                    (timeInteval.StartTime > paramsOfRelocationEquipment.endTime))
                    )
                {
                    unionTimeIntevalInRange.Add(timeInteval);
                }
            }

            TimeInterval timeInterval;
            List<TimeInterval> freeTimeIntevalInRange = new List<TimeInterval>();
            if (unionTimeIntevalInRange.Count > 0)
            {
                timeInterval = unionTimeIntevalInRange[0];
                if (timeInterval.StartTime > paramsOfRelocationEquipment.StartTime)
                {
                    freeTimeIntevalInRange.Add(new TimeInterval(paramsOfRelocationEquipment.StartTime, timeInterval.StartTime));
                }
                for(int it = 0; it < unionTimeIntevalInRange.Count-1; it++)
                {
                    freeTimeIntevalInRange.Add(new TimeInterval(
                            unionTimeIntevalInRange[it].EndTime,
                            unionTimeIntevalInRange[it+1].StartTime
                        )
                    );
                }
                timeInterval = unionTimeIntevalInRange[unionTimeIntevalInRange.Count - 1];
                if (timeInterval.EndTime < paramsOfRelocationEquipment.endTime)
                {
                    freeTimeIntevalInRange.Add(new TimeInterval(timeInterval.EndTime, paramsOfRelocationEquipment.endTime));
                }

               
            }
            else
            {
                // ako u odabranom vremensmomm opsegu
                freeTimeIntevalInRange.Add(new TimeInterval(paramsOfRelocationEquipment.StartTime, paramsOfRelocationEquipment.endTime));
            }


            // sada imamo u listi  freeTimeIntevalInRange zelene pravugaonike 
            foreach (TimeInterval freeTimeInteval in freeTimeIntevalInRange)
            {
                TimeSpan durationOfFreeTimeInteval = freeTimeInteval.EndTime - freeTimeInteval.StartTime;
                double totalMinutes = durationOfFreeTimeInteval.TotalMinutes;
                double numberOfPossibleTermins = totalMinutes / paramsOfRelocationEquipment.durationInMinutes;
                if(numberOfPossibleTermins > 1)
                {
                    int n = (int)numberOfPossibleTermins;
                    DateTime time = freeTimeInteval.StartTime;
                    int dur = paramsOfRelocationEquipment.durationInMinutes;
                    for (int i = 0; i < n; i++)
                    {
                        freePossibleTermsOfRelocation.Add(new TimeInterval(time.AddMinutes(i*dur), time.AddMinutes((i+1)*dur)));
                    }
                }
            }

            return freePossibleTermsOfRelocation;
        }
    }

}
