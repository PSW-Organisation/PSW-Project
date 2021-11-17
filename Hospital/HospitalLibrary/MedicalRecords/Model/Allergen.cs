using ehealthcare.Model;
using HospitalLibrary.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Allergen : EntityDb
    {
        public string Name { get; set; }

        
        public virtual ICollection<PatientAllergen> PatientAllergens { get; set; }

        [JsonConstructor]
        public Allergen() { }

        public Allergen(string name)
        {
            Name = name;
        }
    }
}