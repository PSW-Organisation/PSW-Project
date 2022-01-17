using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalLibrary.Shared.Model
{
    public class AppointmentPrescription
    {
        [Key]
        public int AppointmentId { get; set; }

        public string Medicine { get; set; }

        public double Quantity { get; set; }

        public double RecommendedDose { get; set; }

        public string PatientUsername { get; set; }

        public string DoctorUsername { get; set; }

        public string Diagnosis { get; set; }

        public DateTime Date { get; set; }


        public AppointmentPrescription() { }
       
        public AppointmentPrescription(int appointmentId, string medicine, double quantity, double recommendedDose,
                                string patientUsername, string doctorUsername, string diagnosis, DateTime date)
        {
            AppointmentId = appointmentId;
            Medicine = medicine;
            Quantity = quantity;
            RecommendedDose = recommendedDose;
            PatientUsername = patientUsername;
            DoctorUsername = doctorUsername;
            Diagnosis = diagnosis;
            Date = date;
        }
    }
}
