using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;

namespace ehealthcare.Proxies
{
	interface IAccount
	{
		public Account GetAccount(int id);
	}

	public class AccountImpl : IAccount
	{
		AccountRepository accountRepository;
		public Account GetAccount(int id)
		{
			if (accountRepository == null)
				accountRepository = new AccountXMLRepository();
			return accountRepository.Get(id);
		}
	}

	public class AccountProxyImpl : IAccount
	{
		private IAccount account;
		public Account GetAccount(int id)
		{
			if (account == null)
			{
				account = new AccountImpl();
			}
			return account.GetAccount(id);
		}
	}
}
