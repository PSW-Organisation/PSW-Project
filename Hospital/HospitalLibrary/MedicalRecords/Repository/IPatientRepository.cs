using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Repository
{
    public interface IPatientRepository : IGenericSTRINGIDRepository<Patient>
    {
        public void MapPatientAllergens(Patient patient, List<Allergen> allergens);
        public int Activate(Guid guid);
        public List<Patient> GetMaliciousPatients();

        public Patient GetUsingCredentials(string username, string password);
    }
}
