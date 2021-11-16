using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class AccountController
	{
		private AccountService accountService;

		public AccountController()
		{
			accountService = new AccountService();
		}

		public Account GetAccountByUsername(String username)
		{
			return accountService.GetAccountByUsername(username);
		}

		public List<Account> GetAllAccounts()
		{
			return accountService.GetAllAccounts();
		}

		public void BlockAccount(string username)
		{
			accountService.BlockAccount(username);
		}

		public void UnblockAccount(string username)
		{
			accountService.UnblockAccount(username);
		}

		public bool IsAccountBlocked(string username, string password)
		{
			return accountService.IsAccountBlocked(username, password);
		}

		public void DeleteAccount(string username)
		{
			accountService.DeleteAccount(username);
		}

		public void DeleteAccountByPatientId(string patientId)
		{
			accountService.DeleteAccountByPatientId(patientId);
		}

		public string GetUsername(string patientId)
		{
			return accountService.GetUsername(patientId);
		}

        public void PromoteAccount(string id)
        {
            accountService.PromoteAccount(id);
        }

		public void RegisterGuestAccount(String id)
		{
			accountService.RegisterGuestAccount(id);
		}

		public void AddNewAccount(Account account)
		{
			accountService.AddNewAccount(account);
		}
	}
}
