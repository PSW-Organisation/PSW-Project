using IntegrationLibrary.Proxies;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Model
{
    public class Reminder : Entity
    {
        private IAccount lazyAccount;
        private Account account;
        private DateTime startTime;
        private List<DayOfWeek> days;
        private int hour;
        private int minute;
        private string title;
        private string description;

        public Reminder() : base(-1)
        {
            lazyAccount = new AccountProxyImpl();
        }

        [System.Xml.Serialization.XmlIgnore]
        public Account Account
        {
            get
            {
                if (account == null)
                {
                    account = lazyAccount.GetAccount(AccountUsername);
                }
                return account;
            }
            set
            {
                account = value;
                AccountUsername = value.Id;
            }
        }

        public int AccountUsername { get; set; }

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public List<DayOfWeek> Days
        {
            get { return days; }
            set { days = value; }
        }

        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }

        public int Minute
        {
            get { return minute; }
            set { minute = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}