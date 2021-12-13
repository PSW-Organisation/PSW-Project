using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using IntegrationLibrary.Parnership.Repository.RepoInterfaces;
using IntegrationLibrary.Parnership.Service.ServiceInterfaces;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Parnership.Service.ServiceImpl
{
    public class MedicineTransactionService : IMedicineTransactionService
    {
        private MedicineTransactionRepository transactionRepository;

        public MedicineTransactionService(MedicineTransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public void Delete(MedicineTransaction transaction)
        {
            transactionRepository.Delete(transaction);
        }

        public MedicineTransaction Get(int id)
        {
            return transactionRepository.Get(id);
        }

        public List<MedicineTransaction> GetAll()
        {
            return transactionRepository.GetAll();
        }

        public void Save(MedicineTransaction transaction)
        {
            transaction.Id = transactionRepository.GenerateId();
            transactionRepository.Save(transaction);
        }
    }
}
