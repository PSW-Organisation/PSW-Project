using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface INotificationService
    {
        public List<Notification> GetAllNotifications();
        public void CreateNotification(Notification newNotification);
        public void UpdateNotification(Notification oldNotification, Notification updatedNotification);
        public void DeleteNotification(Notification notification);
        public List<Notification> GetNotificationsForDoctors();
        public List<Notification> GetNotificationsForManagers();
        public List<Notification> GetNotificationsForWorkers(NotificationRole role, List<Notification> allNotifications);
        public int GetIndex(Notification notification);
        public List<Notification> GetNotificationsForPatients();

    }
}
