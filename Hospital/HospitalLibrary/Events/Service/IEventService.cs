using HospitalLibrary.Events.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Service
{
    public interface IEventService
    {
        public Event GetEvent(int id);

        public IList<Event> GetAllEvents();

        public void Save(Event e);
        public object GetAbortStepBreakdown();
        public void UpdateEventDuration(string eventGuid, float duration);
        public object GetStepDurationBreakdown();
        public object GetSuccessfullSchedulingPerMonth();
        public object GetUnsuccessfullSchedulingPerMonth();
        public object GetSchedulingPerTimeOfDay();
        public object GetUnsuccessfullSchedulingByAgeGroup();
        public object GetAverageStats();
    }
}
