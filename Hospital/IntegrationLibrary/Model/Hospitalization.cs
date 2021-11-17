using ehealthcare.Proxies;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Model
{
    public class Hospitalization : Entity
    {
        private DateTime startTime;
        private DateTime endTime;
        private IRoom lazyRoom;
        private Room room;
        private IPatient lazyPatient;
        private Patient patient;
        private bool isActive;

        public Hospitalization() : base(-1)
        {
            lazyRoom = new RoomProxyImpl();
            lazyPatient = new PatientProxyImpl();
        }

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Room Room
        {
            get
            {
                if (room == null)
                {
                    room = lazyRoom.GetRoom(RoomId);
                }
                return room;
            }
            set
            {
                room = value;
                RoomId = value.Id;
            }
        }

        public int RoomId { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public Patient Patient
        {
            get
            {
                if (patient == null)
                {
                    patient = lazyPatient.GetPatient(base.Id);
                }
                return patient;
            }
            set
            {
                patient = value;
                base.Id = value.Id;
            }
        }

        public int PatientId { get; set; }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
            }
        }
    }
}
