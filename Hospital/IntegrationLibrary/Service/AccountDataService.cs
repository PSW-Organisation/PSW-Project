using ehealthcare.Model;
using ehealthcare.PatientApp.ApplicationData;
using ehealthcare.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
	public class AccountDataService : IAccountDataService
	{
		private AccountDataRepository accountDataRepository;
		private int spamActionsLimit = 10;
		private int cancelledVisitsLimit = 3;
		public AccountDataService(AccountDataRepository repository)
		{
			this.accountDataRepository = repository;
		}

		public int GetNumberOfReadNotificationsForAccount(int username)
		{
			AccountData accountData = accountDataRepository.Get(username);
			if(accountData != null)
			{
				return accountData.NumberOfReadNotifications;
			}
			return 0;
		}

		public void SetNumberOfReadNotificationsForAccount(int username, int numberOfReadNotifications)
		{
			AccountData accountData = accountDataRepository.Get(username);
			if(accountData != null)
			{
				accountData.NumberOfReadNotifications = numberOfReadNotifications;
				accountDataRepository.Update(accountData);
			}
		}

		public void AddNewAccountData(Account account)
		{
			accountDataRepository.Save(new AccountData() { Account = account, NumberOfReadNotifications = 0, SpamActionDates = new List<DateTime>(), NumberOfSpamActions = 0, NumberOfCancelledVisits = 0, CancelledVisitsDates = new List<DateTime>() });
		}

		public void AddSpamActionForAccount(int username)
		{
			AccountData accountData = accountDataRepository.Get(username);
			accountData.NumberOfSpamActions++;
			accountData.SpamActionDates.Add(DateTime.Now);
			accountDataRepository.Update(accountData);
		}

		public bool IsAccountSpamming(int username)
		{
			AccountData accountData = accountDataRepository.Get(username);
			if(accountData.NumberOfSpamActions > spamActionsLimit)
			{
				return true;
			}
			return false;
		}

		public bool IsAccountCancellingTooMuch(int username)
		{
			AccountData accountData = accountDataRepository.Get(username);
			if (accountData.NumberOfCancelledVisits == cancelledVisitsLimit)
			{
				return true;
			}
			return false;
		}

		public void AddCanceledVisitForAccount(int username)
		{
			AccountData accountData = accountDataRepository.Get(username);
			accountData.NumberOfCancelledVisits++;
			accountData.CancelledVisitsDates.Add(DateTime.Now);
			accountDataRepository.Update(accountData);
		}

		public void RefreshCancelActionsForAccount(int username)
		{
			AccountData accountData = accountDataRepository.Get(username);
			DateTime timeNow = DateTime.Now;
			for (int i = accountData.NumberOfCancelledVisits - 1; i >= 0; i--)
			{
				if (accountData.CancelledVisitsDates[i].AddDays(30) <= timeNow)
				{
					accountData.CancelledVisitsDates.RemoveAt(i);
					accountData.NumberOfCancelledVisits--;
				}
			}
			accountDataRepository.Update(accountData);
		}

		public void RefreshSpamActionsForAccount(int username)
		{
			AccountData accountData = accountDataRepository.Get(username);
			DateTime timeNow = DateTime.Now;
			if(accountData.SpamActionDates != null)
			{
				if (accountData.SpamActionDates.Count != 0)
				{
					for (int i = accountData.NumberOfSpamActions - 1; i >= 0; i--)
					{
						if (accountData.SpamActionDates[i].AddDays(30) <= timeNow)
						{
							accountData.SpamActionDates.RemoveAt(i);
							accountData.NumberOfSpamActions--;
						}
					}
					accountDataRepository.Update(accountData);
				}
			}
		}

        public void DeleteAccountData(AccountData username)
        {
			accountDataRepository.Delete(username);
        }

        public void DeleteSpamBehaviorData(int username)
        {
			accountDataRepository.DeleteSpamBehaviorData(username);
        }
	}
}
