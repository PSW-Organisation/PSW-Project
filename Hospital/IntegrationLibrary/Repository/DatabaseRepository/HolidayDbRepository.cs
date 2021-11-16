using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;


namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class HolidayDbRepository : GenericDatabaseRepository<Holiday>, HolidayRepository
    {
        public HolidayDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }

        public List<Holiday> GetHolidaysForDoctor(int doctorId)
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
