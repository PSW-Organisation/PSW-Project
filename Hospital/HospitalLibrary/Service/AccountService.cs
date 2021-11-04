using ehealthcare.Model;
using ehealthcare.PatientApp.ApplicationData;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ehealthcare.Service
{
	public class AccountService
	{
		private AccountRepository accountRepository;
        private PatientRepository patientRepository;

        public AccountService()
		{
			accountRepository = new AccountXMLRepository();
            patientRepository = new PatientXMLRepository();

        }

		public Account GetAccountByUsername(String username)
		{
			return accountRepository.Get(username);
		}

        public List<Account> GetAllAccounts()
        {
            return accountRepository.GetAll();
        }

		public void BlockAccount(string username)
		{
			Account accountToBlock = accountRepository.Get(username);
			accountToBlock.IsBlocked = true;
			accountRepository.Update(accountToBlock);
		}

        public void UnblockAccount(string username)
        {
            Account account = accountRepository.Get(username);
            account.IsBlocked = false;
            accountRepository.Update(account);
        }

        public bool IsAccountBlocked(string username, string password)
        {
            List<Account> accounts = accountRepository.GetAll();
            foreach (Account acc in accounts)
            {
                if (username.Equals(acc.Id) && password.Equals(acc.Password) && acc.IsBlocked == true)
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteAccount(string username)
        {
            accountRepository.Delete(username);
        }

        public void DeleteAccountByPatientId(string patientId)
        {
			accountRepository.DeleteAccountByPatientId(patientId);
        }

        public string GetUsername(string patientId)
        {
            return accountRepository.GetUsername(patientId);
        }

        public void RegisterGuestAccount(String id)
        {
            Patient user = new Patient() { Id = id };
            Account account = new Account() { Id = id, Password = "bolnica", LoginType = LoginType.guestPatient, User = user, IsBlocked = false };

            accountRepository.Save(account);
            patientRepository.Save(user);
        }

        public void AddNewAccount(Account account)
        {
            accountRepository.Save(account);

        }
        
        public void PromoteAccount(string id)
        {
            accountRepository.PromoteAccount(id);
        }
    }
}
