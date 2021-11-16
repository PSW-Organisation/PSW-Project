using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	public class HolidayXMLRepository : GenericXMLRepository<Holiday>, HolidayRepository
	{
		public HolidayXMLRepository() : base("holidays.xml") { }

        public List<Holiday> GetHolidaysForDoctor(string doctorId)
        {
            List<Holiday> doctorsHolidays = new List<Holiday>();
            foreach (Holiday holiday in base.GetAll())
            {
                if (holiday.DoctorId == doctorId)
                {
                    doctorsHolidays.Add(holiday);
                }
            }

            return doctorsHolidays;
        }
    }
}
