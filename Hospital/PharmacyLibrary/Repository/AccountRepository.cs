using ehealthcare.Model;
using System.Collections.Generic;
using System.Linq;

namespace ehealthcare.Repository
{
    public interface AccountRepository : GenericRepository<Account>
    {
        public void DeleteAccountByPatientId(string patientId);
        public string GetUsername(string patientId);
        public Account GetAccountByPatientId(string patientId);
        public void PromoteAccount(string id);

    }
}
