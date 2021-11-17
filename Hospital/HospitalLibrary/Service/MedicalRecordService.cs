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
            ((Patient)AppData.getInstance().LoggedInAccount.User).Medical.Doctor = doctor;
            Patient patient = patientRepository.Get(patientId);
            patient.Medical.Doctor = doctor;
            patientRepository.Save(patient);
        }
        /*
        public bool CheckIfAlergic(Patient patient, Medicine medicine)
        {
            foreach (Allergen allergen in patient.Medical.Allergens)
            {
                if (allergen.IsAlergic == true && allergen.Id == medicine.Name)
                {
                    return true;
                }
            }
            return false;
        }*/
    }
}
