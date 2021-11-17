using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class PatientController
	{
		private IPatientService patientService;

		public PatientController(IPatientService patientService)
		{
            this.patientService = patientService;
		}

        public Patient GetPatientById(int id)
        {
            return patientService.GetPatientById(id);
        }

        public List<Patient> GetAllPatients()
        {
            return patientService.GetAllPatients();
        }

        public Patient GetPatientByName(string fullName)
        {
            return patientService.GetPatientByName(fullName);
        }

        public void SetPatientsMedicalPermit(Patient patient, MedicalPermit medicalPermit)
        {
            patientService.SetPatientsMedicalPermit(patient, medicalPermit);
        }

        public void DeletePatient(Patient id)
        {
            patientService.DeletePatient(id);
        }

        public void UpdatePatient(Patient updatedPatient)
        {
            patientService.UpdatePatient(updatedPatient);
        }

        public void AddPatientToStorage(Patient patient)
        {
            patientService.AddPatientToStorage(patient);
        }
    }
}
