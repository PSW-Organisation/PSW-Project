using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezba.DoctorPages;

namespace vezba.Adapter
{
    class CalendarAdapter : CalendarInterface
    {
        private Calendar calendar;

        public CalendarAdapter(Calendar calendar)
        {
            this.calendar = calendar;
        }

        public void AddAppointment(Appointment appointment)
        {
            calendar.AddAppointmentToCurrentView(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            calendar.RemoveAppointment(appointment);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            calendar.RemoveAppointment(appointment);
            calendar.AddAppointmentToCurrentView(appointment);
        }
    }
}
