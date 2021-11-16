using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IAccountService
    {
        public Account GetAccountByUsername(int username);
        public List<Account> GetAllAccounts();
        public void BlockAccount(int username);
        public void UnblockAccount(int username);
        public bool IsAccountBlocked(int username, string password);
        public void DeleteAccount(Account account);
        public void DeleteAccountByPatientId(int patientId);
        public int GetUsername(int patientId);
        public void RegisterGuestAccount(int id);
        public void AddNewAccount(Account account);
        public void PromoteAccount(int id);

    }
}
