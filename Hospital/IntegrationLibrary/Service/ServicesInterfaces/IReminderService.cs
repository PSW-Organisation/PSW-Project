using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IReminderService
    {
        public void CreateNewReminder(Reminder reminder);
        public void GenerateNewNoteNotifications();
        public List<Reminder> GetAllRemindersForAccount(int username);
    }
}
