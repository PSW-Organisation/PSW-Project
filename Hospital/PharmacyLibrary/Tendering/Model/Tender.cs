using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Model
{
    public class Tender : Entity
    {
        private List<TenderItem> _tenderItems;
        private DateTime _tenderOpenDate;
        private DateTime _tenderCloseDate;
        private bool _open;
        //private List<TenderResponse> _tenderResponses;
        private string _apiKeyPharmacy;
        private bool _isWon;

        public virtual List<TenderItem> TenderItems { get => _tenderItems; set => _tenderItems = value; }
        public DateTime TenderOpenDate { get => _tenderOpenDate; set => _tenderOpenDate = value; }

        public DateTime TenderCloseDate { get => _tenderCloseDate; set => _tenderCloseDate = value; }

        public bool Open { get => _open; set => _open = value; }
        //public virtual List<TenderResponse> TenderResponses { get => _tenderResponses; set => _tenderResponses = value; }
        public string ApiKeyPharmacy { get => _apiKeyPharmacy; set => _apiKeyPharmacy = value; }
        public bool IsWon { get => _isWon; set => _isWon = value; }

        public Tender() : base(-1) { }
    }
}
