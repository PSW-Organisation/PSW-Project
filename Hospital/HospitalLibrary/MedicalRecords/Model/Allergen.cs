using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Allergen : EntityDb
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual MedicalRecord MedicalRecord { get; set; }

        public Allergen() { }

        public Allergen(string name)
        {
            Name = name;
        }
    }
}