using ehealthcare.Model;
using ehealthcare.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class AccountController
	{
		private IAccountService accountService;

		public AccountController(IAccountService accountService)
		{
			this.accountService = accountService;
		}

		public Account GetAccountByUsername(int username)
		{
			return accountService.GetAccountByUsername(username);
		}

		public List<Account> GetAllAccounts()
		{
			return accountService.GetAllAccounts();
		}

		public void BlockAccount(int username)
		{
			accountService.BlockAccount(username);
		}

		public void UnblockAccount(int username)
		{
			accountService.UnblockAccount(username);
		}

		public bool IsAccountBlocked(int username, string password)
		{
			return accountService.IsAccountBlocked(username, password);
		}

		public void DeleteAccount(Account username)
		{
			accountService.DeleteAccount(username);
		}

		public void DeleteAccountByPatientId(int patientId)
		{
			accountService.DeleteAccountByPatientId(patientId);
		}

		public int GetUsername(int patientId)
		{
			return accountService.GetUsername(patientId);
		}

        public void PromoteAccount(int id)
        {
            accountService.PromoteAccount(id);
        }

		public void RegisterGuestAccount(int id)
		{
			accountService.RegisterGuestAccount(id);
		}

		public void AddNewAccount(Account account)
		{
			accountService.AddNewAccount(account);
		}
	}
}
