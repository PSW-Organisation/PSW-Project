using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class Complaint
    {
        private long complaintId;
     
        private DateTime date;
        private string title;
        private string content;
        private long pharmacyId;


        public long ComplaintId { get => complaintId; set => complaintId = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public long PharmacyId { get => pharmacyId; set => pharmacyId = value; }

        public Complaint() { }

        public Complaint(long complaintId, DateTime date,  string title,  string content, long pharmacyId)
        {
            this.complaintId = complaintId;
            this.date = date;
            this.title = title;
            this.content = content;
            this.pharmacyId = pharmacyId;
        }
    }
}
