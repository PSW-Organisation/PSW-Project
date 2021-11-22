using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ehealthcare.Model
{
    [Serializable]
    [Table("Patients")]
    public class Patient : User
    {
        public virtual MedicalRecord Medical { get; set; }

        public virtual ICollection<MedicalPermit> MedicalPermits { get; set; }

        public virtual ICollection<PatientAllergen> PatientAllergens { get; set; }

        [JsonConstructor]
        public Patient(string id) : base(id) { }

        
        public Patient(string id, MedicalRecord medical, int medicalRecordId) : base(id)
        {
            Medical = medical;
        }
    }
}