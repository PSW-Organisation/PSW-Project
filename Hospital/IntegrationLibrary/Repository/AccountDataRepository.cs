using IntegrationLibrary.Model;

namespace IntegrationLibrary.Repository
{
	public interface AccountDataRepository : GenericRepository<AccountData>
	{
		public void DeleteSpamBehaviorData(int username);
	}
}