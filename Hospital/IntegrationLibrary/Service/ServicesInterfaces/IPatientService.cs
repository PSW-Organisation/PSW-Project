using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IPatientService
    {
        public Patient GetPatientById(int id);
        public List<Patient> GetAllPatients();
        public Patient GetPatientByName(string fullName);
        public void SetPatientsMedicalPermit(Patient patient, MedicalPermit medicalPermit);
        public void DeletePatient(Patient id);
        public void UpdatePatient(Patient updatedPatient);
        public void AddPatientToStorage(Patient patient);
    }
}
