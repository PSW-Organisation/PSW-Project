using IntegrationLibrary.Model;
using IntegrationLibrary.PatientApp.ApplicationData;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
    public class NotificationService
    {
        private NotificationRepository notificationRepository;

        public NotificationService()
        {
            notificationRepository = new NotificationXMLRepository();
        }

        public List<Notification> GetAllNotifications()
        {
            return notificationRepository.GetAll();
        }

        public void CreateNotification(Notification newNotification)
        {
            notificationRepository.Save(newNotification);
        }

        public void UpdateNotification(Notification oldNotification, Notification updatedNotification)
        {
            List<Notification> allNotifications = notificationRepository.GetAll();
            int index = GetIndex(oldNotification);
            if(index != -1)
            {
                allNotifications.ElementAt(index).Subject = updatedNotification.Subject;
                allNotifications.ElementAt(index).Date = updatedNotification.Date;
                allNotifications.ElementAt(index).Description = updatedNotification.Description;
                allNotifications.ElementAt(index).NotificationRole = updatedNotification.NotificationRole;
            }

            notificationRepository.SaveAll();
        }

        public void DeleteNotification(Notification notification)
        {
            List<Notification> allNotifications = notificationRepository.GetAll();
            int index = GetIndex(notification);

            if(index != -1)
            {
                allNotifications.RemoveAt(index);
            }

            notificationRepository.SaveAll();   
        }

        public List<Notification> GetNotificationsForDoctors()
        {
            List<Notification> notifications = new List<Notification>();
            List<Notification> allNotifications = notificationRepository.GetAll();
            notifications = GetNotificationsForWorkers(NotificationRole.doctor, allNotifications);

            return notifications;
        }

        public List<Notification> GetNotificationsForManagers()
        {
            List<Notification> notifications = new List<Notification>();
            List<Notification> allNotifications = notificationRepository.GetAll();
            notifications = GetNotificationsForWorkers(NotificationRole.manager, allNotifications);

            return notifications;
        }

        private List<Notification> GetNotificationsForWorkers(NotificationRole role, List<Notification> allNotifications)
        {
            List<Notification> notificationsForWorkers = new List<Notification>();
            foreach(Notification notification in allNotifications)
            {
                if (notification.NotificationRole == NotificationRole.all || notification.NotificationRole == NotificationRole.workers || notification.NotificationRole == role)
                {
                    notificationsForWorkers.Add(notification);
                }
            }
            return notificationsForWorkers;
        }

        private int GetIndex(Notification notification)
        {
            int index = -1;
            List<Notification> allNotificaitons = notificationRepository.GetAll();
            foreach(Notification n in allNotificaitons)
            {
                if(notification.Subject == n.Subject && notification.Description == n.Description && notification.NotificationRole == n.NotificationRole && notification.Date == n.Date)
                {
                    index = allNotificaitons.IndexOf(n);
                }
            }
            return index;
        }

        /**
        * <summary>Method returns all notifications intended for all patients to see.</summary>
        */
        public List<Notification> GetNotificationsForPatients()
        {
            List<Notification> notifications =  notificationRepository.GetAll();
            List<Notification> filteredNotifications = new List<Notification>();

            foreach (Notification notification in notifications)
            {
                if(notification.NotificationRole == NotificationRole.patient)
                {
                    filteredNotifications.Add(notification);
                }
            }

            return filteredNotifications;
        }
    }
}
