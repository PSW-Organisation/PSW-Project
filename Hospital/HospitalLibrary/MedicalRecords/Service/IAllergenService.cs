using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IAllergenService
    {
        public List<Allergen> GetAllergens();
    }
}
