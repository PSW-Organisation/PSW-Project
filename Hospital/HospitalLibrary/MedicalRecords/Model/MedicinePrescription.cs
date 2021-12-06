using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class MedicinePrescription : EntityDb
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string MedicineId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Diagnosis { get; set; }
    }
}
