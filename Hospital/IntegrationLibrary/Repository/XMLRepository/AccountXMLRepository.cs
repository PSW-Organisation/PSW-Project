using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	public class AccountXMLRepository : GenericXMLRepository<Account>, AccountRepository
	{
		public AccountXMLRepository() : base("accounts.xml") { }

        public void DeleteAccountByPatientId(string patientId)
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

        public string GetUsername(string patientId)
        {
            List<Account> patientAccounts = base.GetAll().Where(probe => probe.LoginType == LoginType.patient).ToList();
            foreach (Account account in patientAccounts)
            {
                if (account.User.Id == patientId)
                {
                    return account.Id;
                }
            }
            return "";
        }

        public Account GetAccountByPatientId(string patientId)
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


        public void PromoteAccount(string id)
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
