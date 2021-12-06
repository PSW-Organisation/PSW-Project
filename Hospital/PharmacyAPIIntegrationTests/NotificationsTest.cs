using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Shouldly;
using PharmacyLibrary.Repository.NotificationsRepository;
using PharmacyLibrary.Service;
using PharmacyLibrary.Model;

namespace PharmacyAPIIntegrationTests
{
   
    public  class NotificationsTest
    {
        [Fact]
        public void Add_notification()
        {
            var stubRepository = new Mock<INotificationsForAppRepository>();
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
            var stubRepository = new Mock<INotificationsForAppRepository>();
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
