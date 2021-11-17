using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IMedicineTransactionService
    {
        public List<MedicineTransaction> GetAll();
        public MedicineTransaction Get(int id);
        public void Save(MedicineTransaction transaction);
        public void Delete(MedicineTransaction transaction);
    }
}
