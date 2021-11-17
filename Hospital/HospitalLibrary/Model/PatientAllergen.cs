using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Model
{
    public class PatientAllergen : EntityDb
    {
        public int MedicalRecordId { get; set; }
        public int AllergenId { get; set; }

        public PatientAllergen()
        {
                
        }
    }
}
