using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;
using Visibility = Model.Visibility;

namespace vezba.Repository
{
    public class AnnouncementFileRepository : IAnnouncementRepository
    {
        public String FileName { get; }

        public AnnouncementFileRepository()
        {
            this.FileName = "../../obavestenja.json";
        }

        public List<Announcement> GetAll()
        {
            List<Announcement> storedAnnouncements = this.ReadFromFile();
            List<Announcement> announcements = new List<Announcement>();
            for (int i = 0; i < storedAnnouncements.Count; i++)
            {
                if (storedAnnouncements[i].IsDeleted == false)
                {
                    announcements.Add(storedAnnouncements[i]);
                }
            }
            return announcements;
        }

        public Announcement GetOne(int id)
        {
            List<Announcement> announcements = GetAll();
            for (int i = 0; i < announcements.Count; i++)
            {
                if (announcements[i].Id == id && announcements[i].IsDeleted == false)
                {
                    return announcements[i];
                }
            }
            return null;
        }

        public Boolean Save(Announcement newAnnouncement)
        {
            List<Announcement> storedAnnouncements = ReadFromFile();
            newAnnouncement.Id = GenerateNextId();

            for (int i = 0; i < storedAnnouncements.Count; i++)
            {
                if (storedAnnouncements[i].Id == newAnnouncement.Id)
                    return false;
            }
            storedAnnouncements.Add(newAnnouncement);

            WriteToFile(storedAnnouncements);
            return true;
        }

        public Boolean Update(Announcement editedAnnouncement)
        {
            List<Announcement> storedAnnouncements = ReadFromFile();
            for (int i = 0; i < storedAnnouncements.Count; i++)
            {
                if (storedAnnouncements[i].Id == editedAnnouncement.Id && storedAnnouncements[i].IsDeleted == false)
                {
                    storedAnnouncements[i].Edited = editedAnnouncement.Edited;
                    storedAnnouncements[i].Title = editedAnnouncement.Title;
                    storedAnnouncements[i].Content = editedAnnouncement.Content;
                    storedAnnouncements[i].Visibility = editedAnnouncement.Visibility;

                    WriteToFile(storedAnnouncements);
                    return true;
                }
            }
            return false;
        }

        public Boolean Delete(int id)
        {
            List<Announcement> storedAnnouncements = ReadFromFile();
            for (int i = 0; i < storedAnnouncements.Count; i++)
            {
                if (storedAnnouncements[i].Id == id && storedAnnouncements[i].IsDeleted == false)
                {
                    storedAnnouncements[i].IsDeleted = true;
                    WriteToFile(storedAnnouncements);
                    return true;

                }
            }
            return false;
        }

        public List<Announcement> GetByUserType(UserType userType)
        {
            List<Announcement> allAnouncements = GetAll();
            List<Announcement> announcementsForUserType = new List<Announcement>();

            foreach (Announcement announcement in allAnouncements)
            {
                if (DoesUserTypeSeeAnnouncement(userType, announcement.Visibility))
                    announcementsForUserType.Add(announcement);
            }
            return announcementsForUserType;
        }

        public List<Announcement> GetIndividualAnnouncements(String userId)
        {
            List<Announcement> allAnnouncements = GetAll();
            List<Announcement> individualAnnouncements = new List<Announcement>();
            foreach (Announcement announcement in allAnnouncements)
            {
                if (announcement.Visibility == Visibility.individual)
                {
                    foreach (String recipient in announcement.Recipients)
                    {
                        if (recipient.Equals(userId))
                            individualAnnouncements.Add(announcement);
                    }
                }
            }
            return individualAnnouncements;
        }

        private Boolean DoesUserTypeSeeAnnouncement(UserType userType, Visibility visibility)
        {
            if (userType == UserType.menager && (visibility == Visibility.all || visibility == Visibility.staff || visibility == Visibility.menagers))
                return true;
            else if (userType == UserType.secretary && (visibility == Visibility.all || visibility == Visibility.staff || visibility == Visibility.secretaries))
                return true;
            else if (userType == UserType.doctor && (visibility == Visibility.all || visibility == Visibility.staff || visibility == Visibility.doctors))
                return true;
            else if (userType == UserType.patient && (visibility == Visibility.all || visibility == Visibility.patients))
                return true;
            else
                return false;
        }

        private List<Announcement> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);
                List<Announcement> announcements = JsonConvert.DeserializeObject<List<Announcement>>(jsonFromFile);
                return announcements;
            }
            catch {}
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return new List<Announcement>();
        }

        private void WriteToFile(List<Announcement> announcements)
        {
            try
            {
                var jsonToFile = JsonConvert.SerializeObject(announcements, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(this.FileName))
                {
                    writer.Write(jsonToFile);
                }
            }
            catch
            {
                MessageBox.Show("Neuspesno pisanje u fajl" + this.FileName + "!");
            }
        }

        private int GenerateNextId()
        {
            List<Announcement> storedAnnouncements = ReadFromFile();
            return storedAnnouncements.Count;
        }
   
   }
}