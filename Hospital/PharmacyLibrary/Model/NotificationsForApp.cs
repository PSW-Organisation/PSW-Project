using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class NotificationsForApp 
    {
        private int id;
        private String content;
        private DateTime date;
        private bool seen;

        public int Id { get; set; }
        public string Content { get => content; set => content = value; }
        public DateTime Date { get => date; set => date = value; }
        public bool Seen { get => seen; set => seen = value; }
     
    
     

        public NotificationsForApp() { }

        public NotificationsForApp(int id, string content, DateTime date, bool seen) 
        {
            this.id = id;
            this.content = content;
            this.date = date;
            this.seen = seen;
        }

        public NotificationsForApp(string v1, DateTime now, bool v2)
        {
            content = v1;
            date = now;
            seen = v2;
        }
    }
}
