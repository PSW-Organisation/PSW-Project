using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository
{
    public interface HolidayRepository : GenericRepository<Holiday>
    {
        public List<Holiday> GetHolidaysForDoctor(string doctorId);
    }
}
