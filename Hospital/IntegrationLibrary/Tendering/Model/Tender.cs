using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Model
{
    public class Tender : Entity
    {
        private List<MedicineTransaction> _medicineTransactions;
        private DateTime _tenderOpenDate;
        private DateTime _tenderCloseDate;
        private bool _open;
        private List<TenderResponse> _tenderResponses;

        

        public virtual List<MedicineTransaction> MedicineTransactions { get => _medicineTransactions; set => _medicineTransactions = value; }
        public DateTime TenderOpenDate { get => _tenderOpenDate; set => _tenderOpenDate = value; }

        public DateTime TenderCloseDate { get => _tenderCloseDate; set => _tenderCloseDate = value; }

        public bool Open { get => _open; set => _open = value; }
        public virtual List<TenderResponse> TenderResponses { get => _tenderResponses; set => _tenderResponses = value; }

        public Tender() : base(-1) { }

    }
}
