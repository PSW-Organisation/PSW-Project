using Model;
using System;
using System.Collections.Generic;
using vezba.Factory;
using vezba.Repository;

namespace Service
{
   public class AnnouncementService
   {
        private IAnnouncementRepository AnnouncementRepository { get; }
        private IRepositoryFactory RepositoryFactory { get; }

        public AnnouncementService()
        {
            RepositoryFactory = (ApplicationDataSource.GetInstance()).GetRepositoryFactory();
            AnnouncementRepository = RepositoryFactory.CreateAnnouncementRepository();
            //IRepositoryFactory repositoryFactory = (new ApplicationDataSource()).CreateRepositoryFactory();
            //AnnouncementRepository = repositoryFactory.CreateAnnouncementRepository();

            //AnnouncementRepository = new AnnouncementFileRepository();
        }

        public List<Announcement> GetAllAnnouncements()
        {
            return AnnouncementRepository.GetAll();
        }

        public Boolean SaveAnnouncement(Announcement newAnnouncement)
        {
            return AnnouncementRepository.Save(newAnnouncement);
        }

        public Boolean EditAnnouncement(Announcement editedAnnouncement)
        {
            return AnnouncementRepository.Update(editedAnnouncement);
        }

        public Boolean DeleteAnnouncement(int announcementId)
        {
            return AnnouncementRepository.Delete(announcementId);
        }

        public List<Announcement> GetAnnouncementsByUserType(UserType userType)
        {
            return AnnouncementRepository.GetByUserType(userType);
        }

        public List<Announcement> GetUserIndividualAnnouncements(String userId)
        {
            return AnnouncementRepository.GetIndividualAnnouncements(userId);
        }
    }
}
