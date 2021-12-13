
using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAPI.DTO;
using IntegrationLibrary.DTO;
using IntegrationLibrary.SharedModel.Model;

namespace IntegrationAPI.Adapters
{
    public class NotificationsForAppAdapter
    {

        public static NotificationsForAppDto NotificationsToDTO(NotificationsForApp notifications)
        {
            NotificationsForAppDto dto = new NotificationsForAppDto();
            dto.Content = notifications.Content;
            dto.Date = notifications.Date;
            dto.Seen = notifications.Seen;
            dto.Id = notifications.Id;
            return dto;
        }

        public static NotificationsForApp NotificationsFromDTO(NotificationsForAppDto dto)
        {
            NotificationsForApp notification = new NotificationsForApp();
            notification.Content = dto.Content;
            notification.Date = dto.Date;
            notification.Seen = dto.Seen;
            notification.Id = dto.Id;
            return notification;
        }
    }
}
