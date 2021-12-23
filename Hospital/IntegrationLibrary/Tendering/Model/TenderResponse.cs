using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using IntegrationLibrary.Pharmacies.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Model
{
    public class TenderResponse : Entity
    {
        private Pharmacy _pharmacy;
        private int _pharmacyId;
        private List<MedicineTransaction> _medicineTransactions;
        private Tender _tender;
        private int _tenderId;
        private DateTime _responseReciveTime;
        public DateTime ResponseReciveTime { get => _responseReciveTime; set => _responseReciveTime = value; }
        public int PharmacyId { get => _pharmacyId; set => _pharmacyId = value; }
        public virtual Pharmacy Pharmacy { get => _pharmacy; set => _pharmacy = value; }
        public virtual List<MedicineTransaction> MedicineTransactions { get => _medicineTransactions; set => _medicineTransactions = value; }
        public virtual Tender Tender { get => _tender; set => _tender = value; }
        public int TenderId { get => _tenderId; set => _tenderId = value; }
        public TenderResponse() : base(-1) { }

    }
}
