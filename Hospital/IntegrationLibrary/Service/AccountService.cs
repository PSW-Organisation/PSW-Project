using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntegrationLibrary.Service
{
	public class AccountService : IAccountService
    {
		private AccountRepository accountRepository;
        private PatientRepository patientRepository;

        public AccountService(AccountRepository accountRepository, PatientRepository patientRepository)
		{
            this.accountRepository = accountRepository;
            this.patientRepository = patientRepository;
        }

		public Account GetAccountByUsername(int username)
		{
			return accountRepository.Get(username);
		}

        public List<Account> GetAllAccounts()
        {
            return accountRepository.GetAll();
        }

		public void BlockAccount(int username)
		{
			Account accountToBlock = accountRepository.Get(username);
			accountToBlock.IsBlocked = true;
			accountRepository.Update(accountToBlock);
		}

        public void UnblockAccount(int username)
        {
            Account account = accountRepository.Get(username);
            account.IsBlocked = false;
            accountRepository.Update(account);
        }

        public bool IsAccountBlocked(int username, string password)
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

        public void DeleteAccount(Account account)
        {
            accountRepository.Delete(account);
        }

        public void DeleteAccountByPatientId(int patientId)
        {
			accountRepository.DeleteAccountByPatientId(patientId);
        }

        public int GetUsername(int patientId)
        {
            return accountRepository.GetUsername(patientId);
        }

        public void RegisterGuestAccount(int id)
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
        
        public void PromoteAccount(int id)
        {
            accountRepository.PromoteAccount(id);
        }
    }
}
