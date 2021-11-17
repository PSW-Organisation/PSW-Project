using ehealthcare.Model;
using System.Collections.Generic;
using System.Linq;

namespace ehealthcare.Repository
{
	public interface AccountRepository : GenericRepository<Account>
	{
		public void DeleteAccountByPatientId(int patientId);
		public int GetUsername(int patientId);
        public Account GetAccountByPatientId(int patientId);
		public void PromoteAccount(int id);

	}
}
