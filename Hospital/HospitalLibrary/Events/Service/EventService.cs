using HospitalLibrary.Events.Model;
using HospitalLibrary.Events.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Service
{
    public class EventService : IEventService
    {

        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository _eventRepository)
        {
            this.eventRepository = _eventRepository;
        }

        public IList<Event> GetAllEvents()
        {
            return eventRepository.GetAll();
        }

        public Event GetEvent(int id)
        {
            return eventRepository.Get(id);
        }

        public Event Save(Event e)
        {
            throw new NotImplementedException();
        }
    }

}
