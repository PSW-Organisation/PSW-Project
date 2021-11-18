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

        public Patient() { }
      
        public Patient(MedicalRecord medical, int medicalRecordId)
        {
            Medical = medical;
            MedicalRecordId = medicalRecordId;
        }
    }
}