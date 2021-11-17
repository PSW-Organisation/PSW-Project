using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class HolidayController
	{
		private HolidayService holidayService;

		public HolidayController()
		{
			holidayService = new HolidayService();
		}

        public List<Holiday> GetHolidays(int doctorId)
        {
            return holidayService.GetHolidays(doctorId);
        }

        public void NewHoliday(Holiday newHoliday)
        {
            holidayService.NewHoliday(newHoliday);
        }

        public bool CanUseHoliday(Holiday potentialHoliday)
        {
            return holidayService.CanUseHoliday(potentialHoliday);
        }

    }
}
