using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyAPI.Model
{
    public class Complaint
    {
        private long complaintId;
     
        private DateTime date;
        private string title;
        private string content;
        private long hospitalId;


        public long ComplaintId { get => complaintId; set => complaintId = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public long HospitalId { get => hospitalId; set => hospitalId = value; }

        public Complaint() { }

        public Complaint(long complaintId, DateTime date,  string title,  string content, long hospitalId)
        {
            this.complaintId = complaintId;
            this.date = date;
            this.title = title;
            this.content = content;
            this.hospitalId = hospitalId;
        }
    }
}
