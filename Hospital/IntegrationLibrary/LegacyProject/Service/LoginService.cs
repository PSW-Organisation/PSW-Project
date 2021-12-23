using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.PatientApp.ApplicationData;
using IntegrationLibrary.Repository;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IntegrationLibrary.Service
{
	public class LoginService : ILoginService
    {
        private AccountRepository accountRepository;

        public LoginService(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        /**
         * <summary>Method checks login credentials and sets global account for the given credentials. <br/>
         * Returns true if the username and password belond to a registered user in database, and false if otherwise.</summary>
         */
        public bool AttemptLogin(string usernameAttempt, string passwordAttempt)
		{
            List<Account> accounts = accountRepository.GetAll();
            foreach (Account acc in accounts)
            {
                if (usernameAttempt.Equals(acc.Id) && passwordAttempt.Equals(acc.Password) && acc.IsBlocked == false)
                {
                    SetLoggedInAccount(acc);
                    return true;
                }
            }
            return false;
        }

        public void SetLoggedInAccount(Account acc)
        {
            AppData.getInstance().LoggedInAccount = acc;
        }

	}
}