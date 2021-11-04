using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
    public class PersonalizedNotificationController
    {
        private PersonalizedNotificationService personalizedNotificationService;

        public PersonalizedNotificationController()
        {
            personalizedNotificationService = new PersonalizedNotificationService();
        }

        /**
        * <summary>Method returns all personalized notifications for the given account.</summary>
        */
        public List<PersonalizedNotification> GetAllPersonalizedNotificationsForAccount(string username)
        {
            return personalizedNotificationService.GetAllPersonalizedNotificationsForAccount(username);
        }

        public List<PersonalizedNotification> GetAllPersonalizedNotifications()
        {
            return personalizedNotificationService.GetAllPersonalizedNotifications();
        }

        public void CreatePersonalizedNotification(PersonalizedNotification newNotification)
        {
            personalizedNotificationService.CreatePersonalizedNotification(newNotification);
        }

        public void UpdatePersonalizedNotification(Notification oldNotification, PersonalizedNotification updatedNotification)
        {
            personalizedNotificationService.UpdatePersonalizedNotification(oldNotification, updatedNotification);
        }

        public void DeletePersonalizedNotification(Notification notification)
        {
            personalizedNotificationService.DeletePersonalizedNotification(notification);
        }

    }
}
