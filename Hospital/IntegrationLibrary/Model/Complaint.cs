using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class Complaint : Entity
    {
        private DateTime date;
        private string title;
        private string content;
        private long pharmacyId;

        public DateTime Date { get => date; set => date = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public long PharmacyId { get => pharmacyId; set => pharmacyId = value; }

        public Complaint() : base(-1) { }

        public Complaint(DateTime date,  string title,  string content, long pharmacyId) : base(-1)
        {
            this.date = date;
            this.title = title;
            this.content = content;
            this.pharmacyId = pharmacyId;
        }
    }
}
