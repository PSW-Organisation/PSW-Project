using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository
{
    public interface HolidayRepository : GenericRepository<Holiday>
    {
        public List<Holiday> GetHolidaysForDoctor(int doctorId);
    }
}
