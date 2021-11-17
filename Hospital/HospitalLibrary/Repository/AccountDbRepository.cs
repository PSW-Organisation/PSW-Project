using ehealthcare.Model;
using HospitalLibrary.Repository;
using HospitalLibrary.Repository.DbRepository;
using System.Collections.Generic;
using System.Linq;

namespace ehealthcare.Repository
{
	public class AccountDbRepository : GenericDbRepository<Account>, IAccountRepository
	{
		public AccountDbRepository(HospitalDbContext dbContext) : base(dbContext)
		{
		}

	}
}
