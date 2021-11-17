using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface ITherapyNotificationService
    {
        public void AddTherapyNotificationToStorage(TherapyNotification therapyNotification);
        public List<TherapyNotification> GetTherapyNotificationsForPatient(int id);
        public bool TherapyNotificationExists(TherapyNotification therapyNotification);
        public void RemoveTherapyNotificationFromStorage(TherapyNotification id);
    }
}
