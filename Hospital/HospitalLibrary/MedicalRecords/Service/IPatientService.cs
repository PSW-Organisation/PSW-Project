using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IPatientService
    {
        public void SendEmail(string recipientEmail, Guid token);
        public void Register(Patient patient, List<Allergen> allergens);
        public int Activate(Guid guid);
        public Patient GetProfileData(string username);
        public List<Patient> GetMaliciousPatients();
        public void BlockPatient(Patient maliciousPatient);
        public Patient GetUsingCredentials(string username, string password);
    }
}
