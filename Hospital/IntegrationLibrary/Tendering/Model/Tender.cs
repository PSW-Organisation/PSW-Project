using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Model
{
    public class Tender : Entity
    {
        private readonly List<TenderItem> _tenderItems = new List<TenderItem>();
        public IReadOnlyCollection<TenderItem> TenderItems => _tenderItems;
        public DateTime TenderOpenDate { get; set; }
        public DateTime TenderCloseDate { get; set; }
        public bool Open { get; set; }
        public List<TenderResponse> TenderResponses { get; set; }
        public string ApiKeyPharmacy { get; set; }

        public Tender() : base(-1) { }

        public Tender(int id, DateTime openDate, DateTime closeDate): base(id)
        {
            this.Id = id;
            this.TenderOpenDate = openDate;
            this.TenderCloseDate = closeDate;

        }

        public void AddItems(TenderItem item)
        {
            _tenderItems.Add(item);
        }
    }
}
