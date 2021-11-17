
using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class AccountDataController
	{

		private IAccountDataService accountDataService;

		public AccountDataController(IAccountDataService accountDataService)
		{
			this.accountDataService = accountDataService;
		}

		public int GetNumberOfReadNotificationsForAccount(int username)
		{
			return accountDataService.GetNumberOfReadNotificationsForAccount(username);
		}

		public void SetNumberOfReadNotificationsForAccount(int username, int numberOfReadNotifications)
		{
			accountDataService.SetNumberOfReadNotificationsForAccount(username, numberOfReadNotifications);
		}

		public void AddNewAccountData(Account account)
		{
			accountDataService.AddNewAccountData(account);
		}

		public void AddSpamActionForAccount(int username)
		{
			accountDataService.AddSpamActionForAccount(username);
		}

		public bool IsAccountSpamming(int username)
		{
			return accountDataService.IsAccountSpamming(username);
		}

		public bool IsAccountCancellingTooMuch(int username)
		{
			return accountDataService.IsAccountCancellingTooMuch(username);
		}

		public void AddCanceledVisitForAccount(int username)
		{
			accountDataService.AddCanceledVisitForAccount(username);
		}

		public void RefreshCancelActionsForAccount(int username)
		{
			accountDataService.RefreshCancelActionsForAccount(username);
		}

		public void RefreshSpamActionsForAccount(int username)
		{
			accountDataService.RefreshSpamActionsForAccount(username);
		}

		public void DeleteAccountData(AccountData username)
		{
			accountDataService.DeleteAccountData(username);
		}

		public void DeleteSpamBehaviorData(int username)
		{
			accountDataService.DeleteSpamBehaviorData(username);
		}
	}
}
