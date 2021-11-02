using ehealthcare.Model;
using ehealthcare.PatientApp.ApplicationData;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
	public class PatientService
	{
		private PatientRepository patientRepository;

        public PatientService()
		{
			patientRepository = new PatientXMLRepository();
        }

		public Patient GetPatientById(String id)
		{
			return patientRepository.Get(id);
		}

        public List<Patient> GetAllPatients()
        {
            return patientRepository.GetAll();
        }

        public Patient GetPatientByName(string fullName)
        {
            return patientRepository.GetPatientByName(fullName);
        }

        public void SetPatientsMedicalPermit(Patient patient, MedicalPermit medicalPermit)
        {
            if (patient.MedicalPermit.Equals(null))
            {
                patient.MedicalPermit = new List<MedicalPermit>();
            }
            patient.MedicalPermit.Add(medicalPermit);
            patientRepository.Update(patient);
        }
        
        public void DeletePatient(string id)
        {
            patientRepository.Delete(id);
        }

        public void UpdatePatient(Patient updatedPatient)
        {
            patientRepository.Update(updatedPatient);
        }

        /**
        * <summary>Method adds new patient to storage.</summary>
        */
        public void AddPatientToStorage(Patient patient)
        {
            patientRepository.Save(patient);
        }
    }
}
