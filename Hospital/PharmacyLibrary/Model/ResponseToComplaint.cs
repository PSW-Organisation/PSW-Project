using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyAPI.Model
{
   public  class ResponseToComplaint
    {
        private long responseToComplaintId;
        private DateTime date;
        private String content;
        private long complaintId;
        public long ResponseToComplaintId { get => responseToComplaintId; set => responseToComplaintId = value; }

        public DateTime Date { get => date; set => date = value; }
        public String Content { get => content; set => content = value; }
        public long ComplaintId { get => complaintId; set => complaintId = value; }

        public ResponseToComplaint() { }

        public ResponseToComplaint(long responseId, DateTime date, string content)
        {
            this.responseToComplaintId = responseId;
            this.date = date;
            this.content = content;
        }
    }
}
