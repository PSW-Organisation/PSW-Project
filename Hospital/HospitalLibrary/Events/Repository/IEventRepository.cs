using HospitalLibrary.Events.Model;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Repository
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        public object GetAbortStepBreakdown();
        void UpdateEventDuration(string eventGuid, float duration);
        public object GetStepDurationBreakdown();
        public object GetSuccessfullSchedulingPerMonth();
        public object GetUnsuccessfullSchedulingPerMonth();
        public object GetSchedulingPerTimeOfDay();
        public object GetUnsuccessfullSchedulingByAgeGroup();
        public object GetAverageStats();
    }


}
