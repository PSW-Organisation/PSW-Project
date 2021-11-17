using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository.DatabaseRepository;

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
			{
				IntegrationDbContext dbContext = new IntegrationDbContext();
				accountRepository = new AccountDbRepository(dbContext);
			}
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
