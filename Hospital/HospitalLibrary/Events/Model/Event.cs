using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Model
{
    public class Event : EntityDb
    {
        public String IdUser { get; set; }
        public DateTime TimeStamp { get; set; }
        public ApplicationName EventAppName { get; set; }
        public EventClass EventClass { get; set; }

        public Event() { }

        public Event(int argId, String argIdUser, ApplicationName argEventAppName, EventClass argEventClass)
        {
            Id = argId;
            IdUser = argIdUser;
            TimeStamp = DateTime.Now;
            EventAppName = argEventAppName;
            EventClass = argEventClass;

        }


    }
}
