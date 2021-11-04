using ehealthcare.Model;

namespace ehealthcare.Repository
{
    public interface AccountDataRepository : GenericRepository<AccountData>
    {
        public void DeleteSpamBehaviorData(string username);
    }
}