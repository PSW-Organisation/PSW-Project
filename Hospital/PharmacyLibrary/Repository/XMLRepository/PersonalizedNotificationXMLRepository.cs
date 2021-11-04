using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
    public class PersonalizedNotificationXMLRepository : GenericXMLRepository<PersonalizedNotification>, PersonalizedNotificationRepository
    {
        public PersonalizedNotificationXMLRepository() : base("personalizedNotifications.xml") { }

        public void NotifyPatientOfCancellation(List<Account> accounts, DateTime dateTime)
        {
            PersonalizedNotification cancellationNotification = new PersonalizedNotification()
            {
                Subject = "Obaveštenje o otkazivanju termina",
                Description = "Poštovani,\nVaš termin koji je zakazan " + dateTime.ToString("MM/dd/yyyy") + " u " + dateTime.ToString("hh:mm tt") + " je otkazan.",
                Date = DateTime.Now,
                NotificationRole = NotificationRole.specificPatients,
                Accounts = accounts
            };

            Save(cancellationNotification);
        }
    }
}

