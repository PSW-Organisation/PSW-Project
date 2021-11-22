using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IPatientService
    {
        public void SendEmail(string recipientEmail);
        public void Register(Patient patient, List<Allergen> allergens);
    }
}
