using ehealthcare.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Model
{
    [Serializable]
    public abstract class Feedback : Entity
    {
        private IAccount lazyAccount;
        private Account account;

        public Feedback() : base("undefinedNumberKey")
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
                    account = lazyAccount.GetAccount(AccountId);
                }
                return account;
            }
            set
            {
                account = value;
                AccountId = value.Id;
            }
        }
        public string AccountId { get; set; }
    }
}
