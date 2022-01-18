using HospitalLibrary.Events.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Service
{
    public interface IEventService
    {
        public Event GetEvent(int id);

        public IList<Event> GetAllEvents();

        public Event Save(Event e);
    }
}
