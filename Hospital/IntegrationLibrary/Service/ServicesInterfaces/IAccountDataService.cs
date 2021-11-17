using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IAccountDataService
    {
        public int GetNumberOfReadNotificationsForAccount(int username);
        public void SetNumberOfReadNotificationsForAccount(int username, int numberOfReadNotifications);
        public void AddNewAccountData(Account account);
        public void AddSpamActionForAccount(int username);
        public bool IsAccountSpamming(int username);
        public bool IsAccountCancellingTooMuch(int username);
        public void AddCanceledVisitForAccount(int username);
        public void RefreshCancelActionsForAccount(int username);
        public void RefreshSpamActionsForAccount(int username);
        public void DeleteAccountData(AccountData username);
        public void DeleteSpamBehaviorData(int username);

    }
}
