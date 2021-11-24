using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service
{
    public class MedicineConsumptionService : IMedicineConsumptionService
    {
        private MedicineRepository medicineRepository;
        private MedicineTransactionRepository transactionRepository;

        public MedicineConsumptionService(MedicineRepository medicineRepository, MedicineTransactionRepository transactionRepository)
        {
            this.medicineRepository = medicineRepository;
            this.transactionRepository = transactionRepository;
        }

        public List<MedicineConsumption> GetMedicineConsumptionForDates(DateTime startTime, DateTime endTime)
        {
            Dictionary<int, int> medicineCount = CountMedicineForDates(startTime, endTime);

            var consumption = new List<MedicineConsumption>();
            foreach (var temp in medicineCount)
            {
                var total = new MedicineConsumption(medicineRepository.Get(temp.Key).Name, temp.Value);
                consumption.Add(total);
            }
            return consumption;
        }

        private Dictionary<int, int> CountMedicineForDates(DateTime startTime, DateTime endTime)
        {
            Dictionary<int, int> medicineCount = new Dictionary<int, int>();
            foreach (var transaction in transactionRepository.GetAll())
            {
                if (IsTransactionBetweenDates(startTime, endTime, transaction))
                {
                    if (medicineCount.ContainsKey(transaction.MedicineId))
                        medicineCount[transaction.MedicineId] += transaction.MedicineAmmount;
                    else
                        medicineCount[transaction.MedicineId] = transaction.MedicineAmmount;
                }
            }

            return medicineCount;
        }

        private static bool IsTransactionBetweenDates(DateTime startTime, DateTime endTime, MedicineTransaction transaction)
        {
            return DateTime.Compare(transaction.TransactionTime, startTime) > 0 && DateTime.Compare(transaction.TransactionTime, endTime) < 0;
        }
    }
}
