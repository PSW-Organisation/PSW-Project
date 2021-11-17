using System;
using System.Xml.Serialization;

namespace ehealthcare.Model
{
    [Serializable]
    [XmlInclude(typeof(PersonalizedNotification))]
    public class Notification : Entity
    {
        private String subject;
        private String description;
        private DateTime date;
        private NotificationRole notificationRole;

        public Notification() : base(-1) { }

        public string Subject
        {
            get { return subject; }

            set { subject = value; }
        }

        public string Description
        {
            get { return description; }

            set { description = value; }
        }

        public DateTime Date
        {
            get { return date; }

            set { date = value; }
        }

        public NotificationRole NotificationRole
        {
            get { return notificationRole; }
            set { notificationRole = value; }
        }
    }
}