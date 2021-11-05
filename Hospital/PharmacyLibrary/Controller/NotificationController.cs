﻿using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
    public class NotificationController
    {
        private NotificationService notificationService;

        public NotificationController()
        {
            notificationService = new NotificationService();
        }

        public List<Notification> GetAllNotifications()
        {
            return notificationService.GetAllNotifications();
        }

        public void CreateNotification(Notification newNotification)
        {
            notificationService.CreateNotification(newNotification);
        }

        public void UpdateNotification(Notification oldNotification, Notification updatedNotification)
        {
            notificationService.UpdateNotification(oldNotification, updatedNotification);
        }

        public void DeleteNotification(Notification notification)
        {
            notificationService.DeleteNotification(notification);
        }

        public List<Notification> GetNotificationsForDoctors()
        {
            return notificationService.GetNotificationsForDoctors();
        }

        public List<Notification> GetNotificationsForManagers()
        {
            return notificationService.GetNotificationsForManagers();
        }

        /**
        * <summary>Method returns all notifications intended for all patients to see.</summary>
        */
        public List<Notification> GetNotificationsForPatients()
        {
            return notificationService.GetNotificationsForPatients();
        }
    }
}