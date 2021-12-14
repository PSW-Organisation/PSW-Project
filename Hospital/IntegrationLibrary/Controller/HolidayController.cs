using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class HolidayController
	{
		private IHolidayService holidayService;

		public HolidayController(IHolidayService holidayService)
		{
            this.holidayService = holidayService;
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