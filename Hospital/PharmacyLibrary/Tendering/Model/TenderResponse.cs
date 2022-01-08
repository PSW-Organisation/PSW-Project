using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Model
{
    public class TenderResponse : Entity
    {
        private List<TenderItem> _tenderItems;
        private Tender _tender;
        private int _tenderId;
        private DateTime _responseReceivedTime;
        private string _pharmacyApiKey;
        private double _totalPrice;

        public DateTime ResponseReceivedTime { get => _responseReceivedTime; set => _responseReceivedTime = value; }
      
        public virtual List<TenderItem> TenderItems { get => _tenderItems; set => _tenderItems = value; }
        public virtual Tender Tender { get => _tender; set => _tender = value; }
        public int TenderId { get => _tenderId; set => _tenderId = value; }
        public double TotalPrice { get => _totalPrice; set => _totalPrice = value; }
        public string PharmacyApiKey { get => _pharmacyApiKey; set => _pharmacyApiKey = value; }

        public TenderResponse() : base(-1) { }
    }
}
