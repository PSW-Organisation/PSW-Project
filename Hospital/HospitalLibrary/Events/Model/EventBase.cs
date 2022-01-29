using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.Model;

namespace HospitalLibrary.Events.Model
{
    public class EventBase:EntityDb
    {
        public String IdUser { get; set; }
        public DateTime TimeStamp { get; set; }

        public EventBase() { }

        public EventBase(int argId, String argIdUser)
        {
            Id = argId;
            IdUser = argIdUser;
            TimeStamp = DateTime.Now;

        }
    }
}
