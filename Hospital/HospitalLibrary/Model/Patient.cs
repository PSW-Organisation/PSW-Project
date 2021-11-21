using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ehealthcare.Model
{
    [Serializable]
    [Table("Patients")]
    public class Patient : User
    {
        public virtual MedicalRecord Medical { get; set; }

        public int MedicalRecordId { get; set; }

        public virtual ICollection<MedicalPermit> MedicalPermit { get; set; }

        public Patient(string id) : base(id) { }
      
        public Patient(string id, MedicalRecord medical, int medicalRecordId) : base(id)
        {
            Medical = medical;
            MedicalRecordId = medicalRecordId;
        }
    }
}