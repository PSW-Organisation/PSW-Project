using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.SharedModel.Model
{
    public class NotificationsForApp : Entity
    {
        private String content;
        private DateTime date;
        private bool seen;

        public string Content { get => content; set => content = value; }
        public DateTime Date { get => date; set => date = value; }
        public bool Seen { get => seen; set => seen = value; }

        public NotificationsForApp()  : base(-1) { }

        public NotificationsForApp(string content, DateTime date, bool seen) : base(-1)
        {
            this.content = content;
            this.date = date;
            this.seen = seen;
        }


        public NotificationsForApp(int id, string v1, DateTime now, bool v2) : base(id)
        {
            Id = id;
            content = v1;
            date = now;
            seen = v2;
        }

    }
}
