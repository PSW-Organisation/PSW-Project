using HospitalLibrary.Events.Model;
using HospitalLibrary.Events.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Service
{
    public class EventService : IEventService,IEventMoveEquipmentService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventMoveEquipmentRepository _eventMoveEqipmentRepository;

        public EventService(IEventRepository eventRepository,IEventMoveEquipmentRepository eventMoveEqipmentRepository)
        {
            this._eventRepository = eventRepository;
            this._eventMoveEqipmentRepository = eventMoveEqipmentRepository;
        }
        
        public object GetAbortStepBreakdown()
        {
            return this._eventRepository.GetAbortStepBreakdown();
        }

        public IList<Event> GetAllEvents()
        {
            return _eventRepository.GetAll();
        }

        public Event GetEvent(int id)
        {
            return _eventRepository.Get(id);
        }

        public object GetStepDurationBreakdown()
        {
            return _eventRepository.GetStepDurationBreakdown();
        }

        public object GetSuccessfullSchedulingPerMonth()
        {
            return _eventRepository.GetSuccessfullSchedulingPerMonth();
        }

        public object GetUnsuccessfullSchedulingPerMonth()
        {
            return _eventRepository.GetUnsuccessfullSchedulingPerMonth();
        }

        public object GetSchedulingPerTimeOfDay()
        {
            return _eventRepository.GetSchedulingPerTimeOfDay();
        }

        public void Save(Event e)
        {
            _eventRepository.Insert(e);
        }

        public void UpdateEventDuration(string eventGuid, float duration)
        {
            _eventRepository.UpdateEventDuration(eventGuid, duration);
        }

        public object GetUnsuccessfullSchedulingByAgeGroup()
        {
            return _eventRepository.GetUnsuccessfullSchedulingByAgeGroup();
        }

        public object GetAverageStats()
        {
            return _eventRepository.GetAverageStats();
        }

        public EventMoveEquipment GetMoveEquipmentEvent(int id)
        {
            return _eventMoveEqipmentRepository.Get(id);
        }

        public IList<EventMoveEquipment> GetAllMoveEquipmentEvents()
        {
            return _eventMoveEqipmentRepository.GetAll();
        }

        public void SaveMoveEquipmentEvent(EventMoveEquipment e)
        {
            _eventMoveEqipmentRepository.Insert(e);
        }

        public List<EventMoveEquipmentActions> GetMoveEquipmentEventActions(string idUser)
        {
            return _eventMoveEqipmentRepository.GetActionsForManager(idUser);
        }
    }
}
