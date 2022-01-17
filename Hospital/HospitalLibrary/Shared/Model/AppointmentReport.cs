using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalLibrary.Shared.Model
{
    public class AppointmentReport
    {
        [Key]
        public int AppointmentId { get; set; }

        public DateTime Date { get; set; }

        public string PatientUsername { get; set; }

        public string DoctorUsername { get; set; }

        public string Anamnesis { get; set; }

        public string Diagnosis { get; set; }

        public string Notes { get; set; }

        public AppointmentReport() { }

        public AppointmentReport(int appointmentId, DateTime date, string patientUsername,
            string doctorUsername, string anamnesis, string diagnosis, string notes)
        {
            AppointmentId = appointmentId;
            Date = date;
            PatientUsername = patientUsername;
            DoctorUsername = doctorUsername;
            Anamnesis = anamnesis;
            Diagnosis = diagnosis;
            Notes = notes;
        }
    }
}
