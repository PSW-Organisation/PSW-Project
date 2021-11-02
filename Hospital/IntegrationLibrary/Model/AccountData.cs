using ehealthcare.Proxies;
using ehealthcare.Service;
using System;
using System.Collections.Generic;

namespace ehealthcare.Model
{
    [Serializable]
    public class AccountData : Entity
    {
        private int numberOfReadNotifications;
        private IAccount lazyAccount;
        private Account account;
        private int numberOfSpamActions;
        private List<DateTime> spamActionDates;
        private int numberOfCancelledVisits;
        private List<DateTime> cancelledVisitsDates;

        public AccountData() : base("undefinedKey") 
        { 
            lazyAccount = new AccountProxyImpl();
        }

        public int NumberOfReadNotifications
        {
            get { return numberOfReadNotifications; }
            set { numberOfReadNotifications = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Account Account
        {
            get 
            {
                if (account == null)
                {
                    account = lazyAccount.GetAccount(base.Id);
                }
                return account;
            }
            set 
            {
                account = value;
                base.Id = value.Id;
            }
        }

        public int NumberOfSpamActions
        {
            get { return numberOfSpamActions; }
            set { numberOfSpamActions = value; }
        }

        public List<DateTime> SpamActionDates
        {
            get { return spamActionDates; }
            set { spamActionDates = value; }
        }

        public int NumberOfCancelledVisits
        {
            get { return numberOfCancelledVisits; }
            set { numberOfCancelledVisits = value; }
        }

        public List<DateTime> CancelledVisitsDates
        {
            get { return cancelledVisitsDates; }
            set { cancelledVisitsDates = value; }
        }
    }
}