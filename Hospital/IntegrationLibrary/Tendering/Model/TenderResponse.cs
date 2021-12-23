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

        private List<TenderItem> _tenderItems;
        private Tender _tender;
        private int _tenderId;
        private DateTime _responseReceivedTime;
        private double _totalPrice;
        private bool _isWinner;
        private string _pharmacyApiKey;
        public DateTime ResponseReceivedTime { get => _responseReceivedTime; set => _responseReceivedTime = value; }
        public int PharmacyId { get => _pharmacyId; set => _pharmacyId = value; }
        public virtual Pharmacy Pharmacy { get => _pharmacy; set => _pharmacy = value; }
        public virtual List<TenderItem> TenderItems { get => _tenderItems; set => _tenderItems = value; }
        public virtual Tender Tender { get => _tender; set => _tender = value; }
        public int TenderId { get => _tenderId; set => _tenderId = value; }
        public double TotalPrice { get => _totalPrice; set => _totalPrice = value; }
        public bool IsWinner { get => _isWinner; set => _isWinner = value; }
        public string PharmacyApiKey { get => _pharmacyApiKey; set => _pharmacyApiKey = value; }

        public TenderResponse() : base(-1) { }

    }
}
