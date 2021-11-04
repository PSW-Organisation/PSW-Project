using ehealthcare.Model;
using ehealthcare.PatientApp.ApplicationData;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
    public class RegistrationController
    {
        private AccountService accountService;
        private PatientService patientService;

        public RegistrationController()
        {
            accountService = new AccountService();
            patientService = new PatientService();
        }

        /**
        * <summary>Method updates the account of the patient and gives the account new username and new password and stores it.</summary>
        */
        public void UpdateAccountInStorage(Account newAccount)
        {
            //accountService.UpdateAccountInStorage(newAccount);
        }

        /**
        * <summary>Method adds new patient to storage.</summary>
        */
        public void AddPatientToStorage(Patient patient)
        {
            patientService.AddPatientToStorage(patient);
        }

        public void AddNewAccount(Account account)
        {
            accountService.AddNewAccount(account);
        }
    }
}
