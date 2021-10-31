using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba.Repository
{
    interface IAnnouncementRepository: IGenericRepository<Announcement, int>
    {
        List<Announcement> GetByUserType(UserType userType);
        List<Announcement> GetIndividualAnnouncements(String userId);
    }
}
