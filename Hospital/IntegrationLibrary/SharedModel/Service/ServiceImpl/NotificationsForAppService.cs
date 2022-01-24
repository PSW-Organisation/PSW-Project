using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.SharedModel.Model;
using IntegrationLibrary.SharedModel.Repository.RepoInterfaces;
using IntegrationLibrary.SharedModel.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.SharedModel.Service.ServiceImpl
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

        public int GetNumberOfUnseen()
        {
            int number = 0;
            List<NotificationsForApp> allNotifications = GetAll();
            foreach(NotificationsForApp n in allNotifications)
            {
                if (!n.Seen) number++;
            }
            return number;
        }

        public void Save(NotificationsForApp note)
        {
            note.Id = notificationsRepository.GenerateId();
            note.Date = DateTime.Now;
            notificationsRepository.Save(note);
        }

        public NotificationsForApp Update(NotificationsForApp note)
        {
            note.Seen = true;
            return this.notificationsRepository.Update(note);
        }

     
    }
}
