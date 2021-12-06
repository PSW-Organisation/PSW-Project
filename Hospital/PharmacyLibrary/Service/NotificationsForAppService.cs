
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository.NotificationsRepository;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public class NotificationsForAppService : INotificationsForAppService
    {

        private readonly INotificationsForAppRepository notificationsRepository;

     

        public NotificationsForAppService(INotificationsForAppRepository repo)
        {
            this.notificationsRepository = repo;
        }
        public void Delete(NotificationsForApp note)
        {
            this.notificationsRepository.Delete(note.Id);
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
            note.Seen = true;

            return this.notificationsRepository.Update(note);
        }
    }
}
