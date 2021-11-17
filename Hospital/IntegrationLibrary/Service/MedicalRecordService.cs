using ehealthcare.Model;
using ehealthcare.PatientApp.ApplicationData;
using ehealthcare.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private PatientRepository patientRepository;

        public MedicalRecordService(PatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        /**
        * <summary>Method updates the patient's personal doctor in global account and saves the patient in patient repository.</summary>
        */
        public void SetPatientsDoctor(int patientId ,Doctor doctor)
        {
            ((Patient)AppData.getInstance().LoggedInAccount.User).MedicalRecord.PersonalDoctor = doctor;
            Patient patient = patientRepository.Get(patientId);
            patient.MedicalRecord.PersonalDoctor = doctor;
            patientRepository.Save(patient);
        }
        // NE VALJA PROVERA ALERGEN ID I MEDICINE ID :)
        public bool CheckIfAlergic(Patient patient, Medicine medicine)
        {
            foreach (Allergen allergen in patient.MedicalRecord.Allergens)
            {
                if (allergen.IsAlergic == true && allergen.Id == medicine.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
