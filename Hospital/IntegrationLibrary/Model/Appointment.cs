using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using vezba.Repository;
using System.ComponentModel;
using Model;

namespace Model
{
    public class Appointment : INotifyPropertyChanged
    {
        public DateTime StartTime { get; set; }
        public int DurationInMunutes { get; set; }
        public String ApointmentDescription { get; set; }
        public int AppointentId { get; set; }
        public Boolean IsDeleted { get; set; }

        [JsonIgnore]
        public Doctor Doctor { get; set; }
        
        [JsonIgnore]
        public Room Room { get; set; }

        [JsonIgnore]
        public Patient Patient { get; set; }
        public Boolean IsEmergency { get; set; }
        public Note Note { get; set; }

        public Appointment(int id, Patient patient, Doctor doctor, Room room, DateTime startTime, int duration, string apDesc, Note note, Boolean IsEmergency = false)
        {
            AppointentId = id;
            Patient = patient;
            Doctor = doctor;
            Room = room;
            StartTime = startTime;
            DurationInMunutes = duration;
            ApointmentDescription = apDesc;
            IsDeleted = false;
            Note = note;
            this.IsEmergency = IsEmergency;
        }

        public Appointment(Doctor doctor, DateTime startTime, Patient patient) {
            RoomFileRepository rs = new RoomFileRepository();
            List<Room> rooms = rs.GetAll();
            Room room = rooms[0];
            if (rooms.Count == 0)
            {
                room = null;
            }
            this.DurationInMunutes = 15;
            this.ApointmentDescription = "Pregled kod lekara opste prakse.";
            this.IsDeleted = false;
            this.Doctor = doctor;
            this.StartTime = startTime;
            this.Room = room;
            this.Patient = patient;
        }
        [JsonIgnore]
        public DateTime EndTime
        {
            get
            {
                return StartTime.AddMinutes(DurationInMunutes);
            }
        }

        [JsonIgnore]
        public String BeginTime
        {
            get
            {
                return StartTime.ToString("dd.MM.yyyy hh:mm");
            }
        }


        [JsonIgnore]
        public String PatientName
        {
            get
            {
                if (Patient != null)
                    return (Patient.Name + " " + Patient.Surname);
                else
                    return "";
            }
        }
        [JsonIgnore]
        public String RoomName
        {
            get
            {
                if (Room != null)
                    return Convert.ToString(Room.RoomNumber);
                else
                    return "";
            }
            set
            {
                OnPropertyChanged("RoomName");
            }
        }
        [JsonIgnore]
        public String DoctorName
        {
            get
            {
                if (Doctor != null)
                    return (Doctor.Name + " " + Doctor.Surname);
                else
                    return "";
            }
            set
            {
                OnPropertyChanged("DoctorName");
            }
        }

        public String AppointmentDescription
        {
            get => ApointmentDescription;
            set
            {
                ApointmentDescription = value;
                OnPropertyChanged("AppointmentDescription");
            }
        }

        public DateTime StartTimee
        {
            get => StartTime;
            set
            {
                StartTime = value;
                OnPropertyChanged("StartTimee");
            }

        }

        public Appointment() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
