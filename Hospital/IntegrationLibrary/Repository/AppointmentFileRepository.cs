using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json.Linq;
using Service;

namespace vezba.Repository
{
    public class AppointmentFileRepository: IAppointmentRepository
    {
        public String FileName { get; set; }

        public AppointmentFileRepository()
        {
            this.FileName = "../../appointments.json";
        }

        public List<Appointment> GetAll()
        {
            List<Appointment> appointments = new List<Appointment>();
            List<Appointment> storedAppointments = ReadFromFile();
            for (int i = 0; i < storedAppointments.Count; i++)
            {
                if (storedAppointments[i].IsDeleted == false)
                {
                    appointments.Add(storedAppointments[i]);
                }
            }
            return appointments;
        }

        public Boolean Save(Appointment newAppointment)
        {
            newAppointment.AppointentId = GenerateNextId();
            List<Appointment> storedAppointments = ReadFromFile();
            for (int i = 0; i < storedAppointments.Count; i++)
            {
                if (storedAppointments[i].AppointentId.Equals(newAppointment.AppointentId))
                    return false;
            }
            storedAppointments.Add(newAppointment);
            WriteToFile(storedAppointments);
            return true;
        }

        public Boolean Update(Appointment editedAppointment)
        {
            List<Appointment> storedAppointments = ReadFromFile();
            foreach (Appointment appointment in storedAppointments)
            {
                if (appointment.AppointentId.Equals(editedAppointment.AppointentId) && appointment.IsDeleted == false)
                {
                    appointment.StartTime = editedAppointment.StartTime;
                    appointment.DurationInMunutes = editedAppointment.DurationInMunutes;
                    appointment.ApointmentDescription = editedAppointment.ApointmentDescription;
                    appointment.Patient = editedAppointment.Patient;
                    appointment.Room = editedAppointment.Room;
                    appointment.Doctor = editedAppointment.Doctor;
                    appointment.IsEmergency = editedAppointment.IsEmergency;
                    appointment.Note = editedAppointment.Note;
                    WriteToFile(storedAppointments);
                    return true;
                }
            }
            return false;
        }

        public Appointment GetOne(int id)
        {
            List<Appointment> appointments = GetAll();
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].AppointentId == id)
                    return appointments[i];
            }
            return null;
        }

        public Boolean Delete(int id)
        {
            List<Appointment> storedAppointments = ReadFromFile();

            for (int i = 0; i < storedAppointments.Count; i++)
            {
                if (storedAppointments[i].AppointentId == id && storedAppointments[i].IsDeleted == false)
                {
                    storedAppointments[i].IsDeleted = true;
                    WriteToFile(storedAppointments);
                    return true;
                }
            }
            return false;
        }
        private List<Appointment> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);

                var deserializedAppointments = JsonConvert.DeserializeObject<List<JObject>>(jsonFromFile);
                var appointments = CreateAppointments(deserializedAppointments);

                return appointments;
            }
            catch { }
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return new List<Appointment>();
        }

        private List<Appointment> CreateAppointments(List<JObject> deserializedAppointments)
        {
            var appointments = new List<Appointment>();
            PatientFileRepository patientRepository = new PatientFileRepository();
            RoomFileRepository roomRepository = new RoomFileRepository();
            DoctorFileRepository doctorRepository = new DoctorFileRepository();
            foreach (var deserializedAppointment in deserializedAppointments)
            {
                var patientId = (String) deserializedAppointment["patientId"];
                deserializedAppointment.Remove("patientId");

                var roomId = (int) deserializedAppointment["roomId"];
                deserializedAppointment.Remove("roomId");

                var doctorId = (String) deserializedAppointment["doctorId"];
                deserializedAppointment.Remove("doctorId");

                var appointment = deserializedAppointment.ToObject<Appointment>();
                appointment.Patient = patientRepository.GetOne(patientId);
                appointment.Room = roomRepository.GetOne(roomId);
                appointment.Doctor = doctorRepository.GetOne(doctorId);

                appointments.Add(appointment);
            }

            return appointments;
        }

        private void WriteToFile(List<Appointment> appointments)
        {
            try
            {
                var appointmentsForSerialization = PrepareForSerialization(appointments);
                var jsonToFile = JsonConvert.SerializeObject(appointmentsForSerialization, Formatting.Indented);

                using (StreamWriter writer = new StreamWriter(this.FileName))
                {
                    writer.Write(jsonToFile);
                }
            }
            catch
            {
                MessageBox.Show("Neuspesno pisanje u fajl" + this.FileName + "!");
            }
        }

        private int GenerateNextId()
        {
            List<Appointment> appointments = ReadFromFile();
            return appointments.Count;
		}

        private List<JObject> PrepareForSerialization(List<Appointment> appointments)
        {
            var appointmentsForSerialization = new List<JObject>();
            foreach (var appointment in appointments)
            {
                JObject appointmentForSerialization = JObject.FromObject(appointment);

                appointmentForSerialization.Add("patientId", appointment.Patient.Jmbg);
                appointmentForSerialization.Add("roomId", appointment.Room.RoomNumber);
                appointmentForSerialization.Add("doctorId", appointment.Doctor.Jmbg);

                appointmentsForSerialization.Add(appointmentForSerialization);
            }

            return appointmentsForSerialization;
        }

    }
}