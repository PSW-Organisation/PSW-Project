using ehealthcare.Model;
using ehealthcare.Service;
using HospitalLibrary;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class MedicalRecord
    {
        [Key]
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual MedicalRecordInfo Info { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string DoctorId { get; set; }
       
        public MedicalRecord() { }

        public MedicalRecord(string patientId, Patient patient, string personalId, BloodType bloodType,
                             int height, int weight, string profession, Doctor doctor, string doctorId)
        {
            PatientId = patientId;
            Patient = patient;
            Info = new MedicalRecordInfo(patientId, personalId, bloodType, height, weight, profession);
            Doctor = doctor;
            DoctorId = doctorId;
        }
    }
}

