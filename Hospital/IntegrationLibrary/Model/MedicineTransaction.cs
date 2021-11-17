using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class MedicineTransaction : Entity
    {
        private int medicineId;
        private int medicineAmmount;
        private DateTime transactionTime;
        public MedicineTransaction() : base(-1) { }

        public int MedicineId { get => medicineId; set => medicineId = value; }
        public int MedicineAmmount { get => medicineAmmount; set => medicineAmmount = value; }
        public DateTime TransactionTime { get => transactionTime; set => transactionTime = value; }
    }
}
