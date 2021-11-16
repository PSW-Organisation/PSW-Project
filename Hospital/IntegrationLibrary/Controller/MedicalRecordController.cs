using IntegrationLibrary.Model;
using IntegrationLibrary.PatientApp.ApplicationData;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
    public class MedicalRecordController
    {
        private MedicalRecordService medicalRecordService;

        public MedicalRecordController()
        {
            medicalRecordService = new MedicalRecordService();
        }

        /**
        * <summary>Method updates the patient's personal doctor in global account and saves the patient in patient repository.</summary>
        */
        public void SetPatientsDoctor(Doctor doctor)
        {
            medicalRecordService.SetPatientsDoctor(AppData.getInstance().LoggedInAccount.User.Id, doctor);
        }

        public bool CheckIfAlergic(Patient patient, Medicine medicine)
        {
            return medicalRecordService.CheckIfAlergic(patient, medicine);
        }
    }
}
