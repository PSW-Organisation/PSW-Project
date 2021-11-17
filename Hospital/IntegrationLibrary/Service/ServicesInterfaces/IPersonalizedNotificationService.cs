using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IPersonalizedNotificationService
    {
        public List<PersonalizedNotification> GetAllPersonalizedNotificationsForAccount(int username);
        public List<PersonalizedNotification> GetAllPersonalizedNotifications();
        public void CreatePersonalizedNotification(PersonalizedNotification newNotification);
        public void UpdatePersonalizedNotification(Notification oldNotification, PersonalizedNotification updatedNotification);
        public void DeletePersonalizedNotification(Notification notification);
    }
}
