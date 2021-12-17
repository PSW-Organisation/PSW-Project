using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Utils
{
    public class TermsUtils
    {
        public List<TimeInterval> GetFreePossibleTimeIntevalForTwoRooms(RoomTermParams roomTermParams)
        {
            List<TimeInterval> allTimeIntervals = GetAllTimeIntevalsInOneList(roomTermParams.TimeIntervalRoomA , roomTermParams.TimeIntervalRoomB);
            sortTimeIntevals(allTimeIntervals);

            List<TimeInterval> unionTimeInteval = GetUnionTimeInteval(allTimeIntervals);
            List<TimeInterval> unionTimeIntevalInRange = GetTimeIntevalInRange(unionTimeInteval, roomTermParams);
            List<TimeInterval> freeTimeIntevalInRange = GetFreeTimeIntevalInRange(unionTimeIntevalInRange, roomTermParams);
            List<TimeInterval> freePossibleTimeIntervals = GetFreePossibleTimeIntervals(freeTimeIntevalInRange, roomTermParams);

            return freePossibleTimeIntervals;
        }

        public List<TimeInterval> GetFreePossibleTimeIntevalForOneRoom(RoomTermParams roomTermParams)
        {
            List<TimeInterval> timeIntevals = roomTermParams.TimeIntervalRoomA;
            sortTimeIntevals(timeIntevals);

            List<TimeInterval> timeIntevalInRange = GetTimeIntevalInRange(timeIntevals, roomTermParams);
            List<TimeInterval> freeTimeIntevalInRange = GetFreeTimeIntevalInRange(timeIntevalInRange, roomTermParams);
            List<TimeInterval> freePossibleTermsOfRelocation = GetFreePossibleTimeIntervals(freeTimeIntevalInRange, roomTermParams);

            return freePossibleTermsOfRelocation;
        }
        

        // PRIVATE

        public void sortTimeIntevals(List<TimeInterval> timeIntervals)
        {
            timeIntervals.Sort((t1, t2) => t1.StartTime.CompareTo(t2.StartTime));
        }

        private List<TimeInterval> GetAllTimeIntevalsInOneList(List<TimeInterval> sourceRoomTerms, List<TimeInterval> destinationRoomTerms)
        {   
            List<TimeInterval> unionTimeIntervals = new List<TimeInterval>();
            unionTimeIntervals.AddRange(sourceRoomTerms);
            unionTimeIntervals.AddRange(destinationRoomTerms);
            return unionTimeIntervals;
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

        private List<TimeInterval> GetTimeIntevalInRange(List<TimeInterval> unionTimeInteval, RoomTermParams roomTermParams)
        {
            List<TimeInterval> unionTimeIntevalInRange = new List<TimeInterval>();
            foreach (TimeInterval timeInteval in unionTimeInteval)
            {
                if (
                    !(timeInteval.StartTime < roomTermParams.StartTime && timeInteval.EndTime < roomTermParams.StartTime ||
                    timeInteval.StartTime > roomTermParams.EndTime)
                    )
                {
                    unionTimeIntevalInRange.Add(timeInteval);
                }
            }
            return unionTimeIntevalInRange;
        }

        private List<TimeInterval> GetFreeTimeIntevalInRange(List<TimeInterval> unionTimeIntevalInRange, RoomTermParams roomTermParams)
        {
            TimeInterval timeInterval;
            List<TimeInterval> freeTimeIntevalInRange = new List<TimeInterval>();
            if (unionTimeIntevalInRange.Count > 0)
            {
                timeInterval = unionTimeIntevalInRange[0];
                if (timeInterval.StartTime > roomTermParams.StartTime)
                {
                    freeTimeIntevalInRange.Add(new TimeInterval(roomTermParams.StartTime, timeInterval.StartTime));
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
                if (timeInterval.EndTime < roomTermParams.EndTime)
                {
                    freeTimeIntevalInRange.Add(new TimeInterval(timeInterval.EndTime, roomTermParams.EndTime));
                }
            }
            else
            {
                freeTimeIntevalInRange.Add(new TimeInterval(roomTermParams.StartTime, roomTermParams.EndTime));
            }
            return freeTimeIntevalInRange;
        }

        private List<TimeInterval> GetFreePossibleTimeIntervals(List<TimeInterval> freeTimeIntevalInRange, RoomTermParams roomTermParams)
        {
            List<TimeInterval> freePossibleTermsOfRelocation = new List<TimeInterval>();
            foreach (TimeInterval freeTimeInteval in freeTimeIntevalInRange)
            {
                TimeSpan durationOfFreeTimeInteval = freeTimeInteval.EndTime - freeTimeInteval.StartTime;
                double totalMinutes = durationOfFreeTimeInteval.TotalMinutes;
                double numberOfPossibleTermins = totalMinutes / roomTermParams.DurationInMinutes;
                if (numberOfPossibleTermins >= 1)
                {
                    int n = (int)numberOfPossibleTermins;
                    DateTime time = freeTimeInteval.StartTime;
                    int dur = roomTermParams.DurationInMinutes;
                    for (int i = 0; i < n; i++)
                    {
                        freePossibleTermsOfRelocation.Add(new TimeInterval(time.AddMinutes(i * dur), time.AddMinutes((i + 1) * dur)));
                    }
                }
            }
            return freePossibleTermsOfRelocation;
        }

        public bool IsCancelAllowed(DateTime termStartTime)
        {
            return (DateTime.Now <= termStartTime.AddHours(-24) && DateTime.Now <= termStartTime);
        }

    }
}
