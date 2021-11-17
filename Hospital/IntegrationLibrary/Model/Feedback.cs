using IntegrationLibrary.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public abstract class Feedback : Entity
    {
        private IAccount lazyAccount;
        private Account account;

        public Feedback() : base(-1)
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
        public int AccountId { get; set; }
    }
}
