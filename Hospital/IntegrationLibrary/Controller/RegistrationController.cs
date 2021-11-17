using ehealthcare.Model;
using ehealthcare.PatientApp.ApplicationData;
using ehealthcare.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class RegistrationController
	{
        private IAccountService accountService;
        private IPatientService patientService;

		public RegistrationController(IAccountService accountService, IPatientService patientService)
		{
            this.accountService = accountService;
            this.patientService = patientService;
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
