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

		private AccountDataService accountDataService;

		public AccountDataController()
		{
			accountDataService = new AccountDataService();
		}

		public int GetNumberOfReadNotificationsForAccount(string username)
		{
			return accountDataService.GetNumberOfReadNotificationsForAccount(username);
		}

		public void SetNumberOfReadNotificationsForAccount(string username, int numberOfReadNotifications)
		{
			accountDataService.SetNumberOfReadNotificationsForAccount(username, numberOfReadNotifications);
		}

		public void AddNewAccountData(Account account)
		{
			accountDataService.AddNewAccountData(account);
		}

		public void AddSpamActionForAccount(string username)
		{
			accountDataService.AddSpamActionForAccount(username);
		}

		public bool IsAccountSpamming(string username)
		{
			return accountDataService.IsAccountSpamming(username);
		}

		public bool IsAccountCancellingTooMuch(string username)
		{
			return accountDataService.IsAccountCancellingTooMuch(username);
		}

		public void AddCanceledVisitForAccount(string username)
		{
			accountDataService.AddCanceledVisitForAccount(username);
		}

		public void RefreshCancelActionsForAccount(string username)
		{
			accountDataService.RefreshCancelActionsForAccount(username);
		}

		public void RefreshSpamActionsForAccount(string username)
		{
			accountDataService.RefreshSpamActionsForAccount(username);
		}

		public void DeleteAccountData(string username)
		{
			accountDataService.DeleteAccountData(username);
		}

		public void DeleteSpamBehaviorData(string username)
		{
			accountDataService.DeleteSpamBehaviorData(username);
		}
	}
}
