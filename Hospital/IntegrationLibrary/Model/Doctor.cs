using IntegrationLibrary.Service;
using System;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class Doctor : User
    {
        private Specialization specialization;
        private int usedOffdays;
        private Room doctorRoom;

        public Doctor()
        {
        }

        public Specialization Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public int UsedOffDays
        {
            get { return usedOffdays; }
            set { usedOffdays = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Room DoctorRoom
        {
            get { return doctorRoom; }
            set { doctorRoom = value; }
        }

        public String DoctorRoomId
        {
            get { return doctorRoom.Id; }
            set
            {
                RoomService roomService = new RoomService();
                doctorRoom = roomService.GetRoomById(value);
            }
        }
    }
}