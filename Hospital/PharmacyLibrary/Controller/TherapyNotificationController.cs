using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
    public class TherapyNotificationController
    {
        private TherapyNotificationService therapyNotificationService;

        public TherapyNotificationController()
        {
            therapyNotificationService = new TherapyNotificationService();
        }

        /**
        * <summary>Method adds new TherapyNotification to storage.</summary>
        */
        public void AddTherapyNotificationToStorage(TherapyNotification therapyNotification)
        {
            therapyNotificationService.AddTherapyNotificationToStorage(therapyNotification);
        }

        public List<TherapyNotification> GetTherapyNotificationsForPatient(string id)
        {

            return therapyNotificationService.GetTherapyNotificationsForPatient(id);
        }

        public bool TherapyNotificationExists(TherapyNotification therapyNotification)
        {
            return therapyNotificationService.TherapyNotificationExists(therapyNotification);
        }

        public void RemoveTherapyNotificationFromStorage(string id)
        {
            therapyNotificationService.RemoveTherapyNotificationFromStorage(id);
        }
    }
}
