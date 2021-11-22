using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Model
{
    public class PatientAllergen
    {
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int AllergenId { get; set; }
        public virtual Allergen Allergen { get; set; }

        public PatientAllergen()
        {
                
        }
    }
}
