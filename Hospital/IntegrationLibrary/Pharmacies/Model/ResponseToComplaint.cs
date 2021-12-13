using IntegrationLibrary.Model;
using IntegrationLibrary.SharedModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Model
{
   public  class ResponseToComplaint : Entity
    {
        private DateTime date;
        private String content;
        private long complaintId;
        public long ComplaintId { get => complaintId; set => complaintId = value; }

        public DateTime Date { get => date; set => date = value; }
        public String Content { get => content; set => content = value; }

        public ResponseToComplaint() : base(-1) { }

        public ResponseToComplaint(DateTime date, string content, long complaintId) : base(-1)
        {
            this.date = date;
            this.content = content;
            this.complaintId = complaintId;
        }
    }
}
