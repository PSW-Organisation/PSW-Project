using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class MedicineTransaction : Entity
    {
        private string medicineId;
        private int medicineAmmount;
        private DateTime transactionTime;
        public MedicineTransaction() : base(-1) { }

        public string MedicineId { get => medicineId; set => medicineId = value; }
        public int MedicineAmmount { get => medicineAmmount; set => medicineAmmount = value; }
        public DateTime TransactionTime { get => transactionTime; set => transactionTime = value; }
    }
}
