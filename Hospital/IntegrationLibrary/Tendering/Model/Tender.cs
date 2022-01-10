using Castle.Core.Internal;
using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Model
{
    public class Tender : Entity
    {
        public List<TenderItem> TenderItems;
        public DateTime TenderOpenDate;
        public DateTime TenderCloseDate;
        public bool Open;
        public List<TenderResponse> TenderResponses;
        public string ApiKeyPharmacy;
        

      
        public Tender() : base(-1) { }

        public Tender(int id, List<TenderItem> items, DateTime tenderOpenDate, DateTime tenderCloseDate, bool open, List<TenderResponse> responses, string api) :base(id)
        {
            Validate(items, tenderOpenDate, tenderCloseDate);
            this.Id = id;
            TenderItems = items;
            TenderOpenDate = tenderOpenDate;
            TenderCloseDate = tenderCloseDate;
            Open = open;
            TenderResponses = responses;
            ApiKeyPharmacy = api;
        }

        private void Validate(List<TenderItem> items, DateTime tenderOpenDate, DateTime tenderCloseDate)
        {
            if (items.IsNullOrEmpty()) throw new  ArgumentException("Tender must have items!");
            if(tenderCloseDate < tenderOpenDate) throw new ArgumentException("Tender close date must be after open date!");
        }

        public void OpenTender()
        {
            this.Open = true;
        }
        public void CloseTender()
        {
            this.Open = false;
        }

     

    }
}
