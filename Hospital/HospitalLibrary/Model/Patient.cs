using System;
using System.Collections.Generic;

namespace Model
{
    public class Patient : User
    {
        public Boolean IsBlocked { get; set; }
        public Patient(Boolean isGuest, string name, string surname, string jmbg , DateTime date, Sex sex, string phoneNumber, string adress, string email, string idNum, string emContact, MedicalRecord med, string username, string password, Boolean block = false)
        {

            this.IsDeleted = false;
            this.IsGuest = isGuest;
            this.Name = name;
            this.Surname = surname;
            this.Jmbg = jmbg;
            this.DateOfBirth = date;
            this.Sex = sex;
            this.PhoneNumber = phoneNumber;
            this.Adress = adress;
            this.Email = email;
            this.IdCard = idNum;
            this.EmergencyContact = emContact;
            this.MedicalRecord = med;
            this.Username = username;
            this.Password = password;
            this.appointment = null;
            this.Type = UserType.patient;
            this.IsBlocked = block;
        }
        public Boolean IsGuest { get; set; }
        public String EmergencyContact { get; set; }

        public MedicalRecord MedicalRecord { get; set; }

        public string NameAndSurname
        {
            get
            {
                return Name + " " + Surname;
            }
        }

        public List<Appointment> appointment;


        public List<Appointment> Appointment
        {
            get
            {
                if (appointment == null)
                    appointment = new List<Appointment>();
                return appointment;
            }
            set
            {
                RemoveAllAppointment();
                if (value != null)
                {
                    foreach (Appointment oAppointment in value)
                        AddAppointment(oAppointment);
                }
            }
        }


        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new System.Collections.Generic.List<Appointment>();
            if (!this.appointment.Contains(newAppointment))
            {
                this.appointment.Add(newAppointment);
                newAppointment.Patient = this;
            }
        }


        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointment != null)
                if (this.appointment.Contains(oldAppointment))
                {
                    this.appointment.Remove(oldAppointment);
                    oldAppointment.Patient = null;
                }
        }


        public void RemoveAllAppointment()
        {
            if (appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.Patient = null;
                tmpAppointment.Clear();
            }
        }

        public override string ToString()
        {
            return this.Name + " " + this.Surname;
        }

    }
}