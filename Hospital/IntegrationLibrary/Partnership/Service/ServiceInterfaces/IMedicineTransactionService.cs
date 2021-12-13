using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Parnership.Service.ServiceInterfaces
{
    public interface IMedicineTransactionService
    {
        public List<MedicineTransaction> GetAll();
        public MedicineTransaction Get(int id);
        public void Save(MedicineTransaction transaction);
        public void Delete(MedicineTransaction transaction);
    }
}
