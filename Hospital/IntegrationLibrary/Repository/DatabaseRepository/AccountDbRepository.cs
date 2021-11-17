using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class AccountDbRepository : GenericDatabaseRepository<Account>, AccountRepository
    {
        public AccountDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
        public void DeleteAccountByPatientId(int patientId)
        {
            foreach (Account account in base.GetAll())
            {
                if (account.LoginType == LoginType.patient)
                {
                    if (account.User.Id == patientId)
                    {
                        base.GetAll().Remove(account);
                        break;
                    }
                }

            }
            base.SaveAll();
        }

        public int GetUsername(int patientId)
        {
            List<Account> patientAccounts = base.GetAll().Where(probe => probe.LoginType == LoginType.patient).ToList();
            foreach (Account account in patientAccounts)
            {
                if (account.User.Id == patientId)
                {
                    return account.Id;
                }
            }
            return -1;
        }

        public Account GetAccountByPatientId(int patientId)
        {
            foreach (Account acc in base.GetAll())
            {
                if (acc.LoginType == LoginType.patient)
                {
                    if (acc.User.Id == patientId)
                    {
                        return acc;
                    }
                }
            }
            return null;
        }


        public void PromoteAccount(int id)
        {
            foreach (Account account in base.GetAll())
            {
                if (account.LoginType == LoginType.guestPatient)
                {
                    if (account.User.Id == id)
                    {
                        account.LoginType = LoginType.patient;
                        break;
                    }
                }
            }
            base.SaveAll();
        }

        
    }

}
