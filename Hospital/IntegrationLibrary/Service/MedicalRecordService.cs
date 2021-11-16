using IntegrationLibrary.Model;
using IntegrationLibrary.PatientApp.ApplicationData;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
    public class MedicalRecordService
    {
        private PatientRepository patientRepository;

        public MedicalRecordService()
        {
            patientRepository = new PatientXMLRepository();
        }

        /**
        * <summary>Method updates the patient's personal doctor in global account and saves the patient in patient repository.</summary>
        */
        public void SetPatientsDoctor(string patientId ,Doctor doctor)
        {
            ((Patient)AppData.getInstance().LoggedInAccount.User).MedicalRecord.PersonalDoctor = doctor;
            Patient patient = patientRepository.Get(patientId);
            patient.MedicalRecord.PersonalDoctor = doctor;
            patientRepository.Save(patient);
        }

        public bool CheckIfAlergic(Patient patient, Medicine medicine)
        {
            foreach (Allergen allergen in patient.MedicalRecord.Allergens)
            {
                if (allergen.IsAlergic == true && allergen.Id == medicine.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
