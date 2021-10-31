using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba.Adapter
{
    public interface CalendarInterface
    {
        void AddAppointment(Appointment appointment);

        void DeleteAppointment(Appointment appointment);

        void UpdateAppointment(Appointment appointment);
    }
}
