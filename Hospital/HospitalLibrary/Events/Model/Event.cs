using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalLibrary.Events.Model
{
    public class Event : EntityDb
    {
        public String IdUser { get; set; }
        public DateTime TimeStamp { get; set; }
        public ApplicationName EventAppName { get; set; }
        public EventClass EventClass { get; set; }
        public Guid EventGuid { get; set; }
        public float Duration { get; set; }

        public Event() { }

        public Event(int argId, String argIdUser, ApplicationName argEventAppName, EventClass argEventClass, string eventGuid, float duration)
        {
            Id = argId;
            IdUser = argIdUser;
            TimeStamp = DateTime.Now;
            EventAppName = argEventAppName;
            EventClass = argEventClass;
            EventGuid = new Guid(eventGuid);
            Duration = duration;
        }
    }
}
