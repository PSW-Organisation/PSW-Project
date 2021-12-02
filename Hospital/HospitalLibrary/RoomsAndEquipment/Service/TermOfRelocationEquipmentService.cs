using FluentResults;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class TermOfRelocationEquipmentService : ITermOfRelocationEquipmentService
    {

        private readonly ITermOfRelocationEquipmentRepository _relocationEquipmentRepository;

        public TermOfRelocationEquipmentService(ITermOfRelocationEquipmentRepository relocationEquipmentRepository)
        {
            _relocationEquipmentRepository = relocationEquipmentRepository;
        }
        
        public List<TermOfRelocationEquipment> GetTermsOfRelocationByRoomId(int id)
        {
            return _relocationEquipmentRepository.GetTermsOfRelocationByRoomId(id);
        }

        public void sortTerms(List<TermOfRelocationEquipment> terms) 
        {
            terms.Sort((t1, t2) => t1.StartTime.CompareTo(t2.StartTime));
        }

        private List<TermOfRelocationEquipment> GetUnionFromTermsOfRelocation(List<TermOfRelocationEquipment> sourceRoomTerms, List<TermOfRelocationEquipment> destinationRoomTerms)
        {
            List<TermOfRelocationEquipment> unionTerms = new List<TermOfRelocationEquipment>();
            foreach (TermOfRelocationEquipment t in sourceRoomTerms) unionTerms.Add(t);
            foreach (TermOfRelocationEquipment t in destinationRoomTerms) unionTerms.Add(t);
            return unionTerms;
        }

        private List<TimeInterval> GetUnionTimeInteval(List<TimeInterval> allTimeInteval)
        {
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
            return unionTimeInteval;
        }

        private List<TimeInterval> GetUnionTimeIntevalInRange(List<TimeInterval> unionTimeInteval, ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            List<TimeInterval> unionTimeIntevalInRange = new List<TimeInterval>();
            foreach (TimeInterval timeInteval in unionTimeInteval)
            {
                if (
                    !((timeInteval.StartTime < paramsOfRelocationEquipment.StartTime && timeInteval.EndTime < paramsOfRelocationEquipment.StartTime) ||
                    (timeInteval.StartTime > paramsOfRelocationEquipment.EndTime))
                    )
                {
                    unionTimeIntevalInRange.Add(timeInteval);
                }
            }
            return unionTimeIntevalInRange;
        }

        private List<TimeInterval> GetFreeTimeIntevalInRange(List<TimeInterval> unionTimeIntevalInRange, ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            TimeInterval timeInterval;
            List<TimeInterval> freeTimeIntevalInRange = new List<TimeInterval>();
            if (unionTimeIntevalInRange.Count > 0)
            {
                timeInterval = unionTimeIntevalInRange[0];
                if (timeInterval.StartTime > paramsOfRelocationEquipment.StartTime)
                {
                    freeTimeIntevalInRange.Add(new TimeInterval(paramsOfRelocationEquipment.StartTime, timeInterval.StartTime));
                }
                for (int it = 0; it < unionTimeIntevalInRange.Count - 1; it++)
                {
                    freeTimeIntevalInRange.Add(new TimeInterval(
                            unionTimeIntevalInRange[it].EndTime,
                            unionTimeIntevalInRange[it + 1].StartTime
                        )
                    );
                }
                timeInterval = unionTimeIntevalInRange[unionTimeIntevalInRange.Count - 1];
                if (timeInterval.EndTime < paramsOfRelocationEquipment.EndTime)
                {
                    freeTimeIntevalInRange.Add(new TimeInterval(timeInterval.EndTime, paramsOfRelocationEquipment.EndTime));
                }
            }
            else
            {
                freeTimeIntevalInRange.Add(new TimeInterval(paramsOfRelocationEquipment.StartTime, paramsOfRelocationEquipment.EndTime));
            }
            return freeTimeIntevalInRange;
        }

        private List<TimeInterval> GetFreePossibleTermsOfRelocation(List<TimeInterval> freeTimeIntevalInRange, ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            List<TimeInterval> freePossibleTermsOfRelocation = new List<TimeInterval>();
            foreach (TimeInterval freeTimeInteval in freeTimeIntevalInRange)
            {
                TimeSpan durationOfFreeTimeInteval = freeTimeInteval.EndTime - freeTimeInteval.StartTime;
                double totalMinutes = durationOfFreeTimeInteval.TotalMinutes;
                double numberOfPossibleTermins = totalMinutes / paramsOfRelocationEquipment.DurationInMinutes;
                if (numberOfPossibleTermins >= 1)
                {
                    int n = (int)numberOfPossibleTermins;
                    DateTime time = freeTimeInteval.StartTime;
                    int dur = paramsOfRelocationEquipment.DurationInMinutes;
                    for (int i = 0; i < n; i++)
                    {
                        freePossibleTermsOfRelocation.Add(new TimeInterval(time.AddMinutes(i * dur), time.AddMinutes((i + 1) * dur)));
                    }
                }
            }
            return freePossibleTermsOfRelocation;
        }

        public List<TimeInterval> GetFreePossibleTermsOfRelocation(ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            List<TermOfRelocationEquipment> sourceRoomTerms = GetTermsOfRelocationByRoomId(paramsOfRelocationEquipment.IdSourceRoom);
            List<TermOfRelocationEquipment> destinationRoomTerms = GetTermsOfRelocationByRoomId(paramsOfRelocationEquipment.IdDestinationRoom);
            List<TermOfRelocationEquipment> unionTerms = GetUnionFromTermsOfRelocation(sourceRoomTerms, destinationRoomTerms);
            sortTerms(unionTerms);

            List<TimeInterval> allTimeInteval = new List<TimeInterval>();
            foreach (TermOfRelocationEquipment t in unionTerms) allTimeInteval.Add(new TimeInterval(t.StartTime, t.EndTime));

            List<TimeInterval> unionTimeInteval = GetUnionTimeInteval(allTimeInteval);
            List<TimeInterval> unionTimeIntevalInRange = GetUnionTimeIntevalInRange(unionTimeInteval, paramsOfRelocationEquipment);
            List<TimeInterval> freeTimeIntevalInRange = GetFreeTimeIntevalInRange(unionTimeIntevalInRange, paramsOfRelocationEquipment);
            List<TimeInterval> freePossibleTermsOfRelocation = GetFreePossibleTermsOfRelocation(freeTimeIntevalInRange, paramsOfRelocationEquipment);

            return freePossibleTermsOfRelocation;
        }

       

        public TermOfRelocationEquipment CreateTermsOfRelocation(ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            TermOfRelocationEquipment newTermOfRelocationEquipment = new TermOfRelocationEquipment(paramsOfRelocationEquipment);
            List<TimeInterval> termForRelocation = GetFreePossibleTermsOfRelocation(paramsOfRelocationEquipment);
            if(termForRelocation.Count == 1)
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
    }

}
