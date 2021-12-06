using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface INotificationsForAppService
    {

        public List<NotificationsForApp> GetAll();
        public NotificationsForApp Get(int id);
        public void Save(NotificationsForApp note);
        public void Delete(NotificationsForApp note);
        public NotificationsForApp Update(NotificationsForApp note);
      

    }
}
