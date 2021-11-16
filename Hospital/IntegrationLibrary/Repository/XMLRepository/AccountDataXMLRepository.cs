using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	public class AccountDataXMLRepository : GenericXMLRepository<AccountData>, AccountDataRepository
    {
        public AccountDataXMLRepository() : base("accountsData.xml") { }

        public void DeleteSpamBehaviorData(string username)
        {
            foreach (AccountData accountData in base.GetAll())
            {
                if (accountData.Id == username)
                {
                    accountData.CancelledVisitsDates = new List<DateTime>();
                    accountData.NumberOfCancelledVisits = 0;
                    accountData.SpamActionDates = new List<DateTime>();
                    accountData.NumberOfSpamActions = 0;
                    break;
                }
            }
            base.SaveAll();
        }
    }
}
