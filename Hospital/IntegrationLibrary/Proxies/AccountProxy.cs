using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;
using IntegrationLibrary.Model;

namespace IntegrationLibrary.Proxies
{
	interface IAccount
	{
		public Account GetAccount(string id);
	}

	public class AccountImpl : IAccount
	{
		AccountRepository accountRepository;
		public Account GetAccount(string id)
		{
			if (accountRepository == null)
				accountRepository = new AccountXMLRepository();
			return accountRepository.Get(id);
		}
	}

	public class AccountProxyImpl : IAccount
	{
		private IAccount account;
		public Account GetAccount(string id)
		{
			if (account == null)
			{
				account = new AccountImpl();
			}
			return account.GetAccount(id);
		}
	}
}
