using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class AccountDataDbRepository : GenericDatabaseRepository<AccountData>, AccountDataRepository
    {

        public AccountDataDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }

        public void DeleteSpamBehaviorData(int username)
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
