using ehealthcare.Service;
using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ehealthcare.Model
{
    [Serializable]
    public class MedicalRecord
    {
        [Key]
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string PersonalId { get; set; }
        public int BloodType { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Profession { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string DoctorId { get; set; }

        public MedicalRecord() { }

        public MedicalRecord(string patientId, Patient patient, string personalId, int bloodType,
                             int height, int weight, string profession, Doctor doctor, string doctorId)
        {
            PatientId = patientId;
            Patient = patient;
            PersonalId = personalId;
            BloodType = bloodType;
            Height = height;
            Weight = weight;
            Profession = profession;
            Doctor = doctor;
            DoctorId = doctorId;
        }
    }
}