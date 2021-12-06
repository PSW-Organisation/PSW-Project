using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service
{
    public class NotificationsForAppService : INotificationsForAppService
    {

        private NotificationsForAppRepository notificationsRepository;

     

        public NotificationsForAppService(NotificationsForAppRepository repo)
        {
            this.notificationsRepository = repo;
        }
        public void Delete(NotificationsForApp note)
        {
            this.notificationsRepository.Delete(note);
        }

        public NotificationsForApp Get(int id)
        {
            return this.notificationsRepository.Get(id);
        }

        public List<NotificationsForApp> GetAll()
        {
            return this.notificationsRepository.GetAll();
        }

        public void Save(NotificationsForApp note)
        {
            note.Id = notificationsRepository.GenerateId();
            note.Date = DateTime.Now;
            notificationsRepository.Save(note);
        }

        public NotificationsForApp Update(NotificationsForApp note)
        {
            return this.notificationsRepository.Update(note);
        }
    }
}
