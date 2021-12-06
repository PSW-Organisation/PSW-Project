using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAPIIntegrationTests
{
   public  class NotificationsTest
    {
        [Fact]
        public void Add_notification()
        {
            var stubRepository = new Mock<NotificationsForAppRepository>();
            INotificationsForAppService notificationService = new NotificationsForAppService(stubRepository.Object);
            List<NotificationsForApp> allNotifications = new List<NotificationsForApp>();
            NotificationsForApp notification = new NotificationsForApp("nova", DateTime.Now, false);
            stubRepository.Setup(n => n.Save(notification)).Callback((NotificationsForApp n) => allNotifications.Add(n));
            notificationService.Save(notification);

            allNotifications.ShouldNotBeEmpty();
        }
        [Fact]
        public void ChangeToSeen()
        {
            var stubRepository = new Mock<NotificationsForAppRepository>();
            INotificationsForAppService notificationService = new NotificationsForAppService(stubRepository.Object);
            List<NotificationsForApp> allNotifications = new List<NotificationsForApp>();
            NotificationsForApp notification = new NotificationsForApp(1, "nova", DateTime.Now, false);
            allNotifications.Add(notification);
            stubRepository.Setup(n => n.GetAll()).Returns(allNotifications);
            notificationService.Update(notification);
            notification.Seen.ShouldBeTrue();
        }

    }
}
