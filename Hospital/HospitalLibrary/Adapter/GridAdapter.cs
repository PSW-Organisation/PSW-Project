using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using vezba.DoctorPages;

namespace vezba.Adapter
{
    class GridAdapter : CalendarInterface
    {

        public GridAdapter()
        {
        }

        public void AddAppointment(Appointment appointment)
        {
            AppointmentGrid.Appointments.Add(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            AppointmentGrid.Appointments.Remove(appointment);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            var previousAppointment = AppointmentGrid.Appointments.FirstOrDefault(a => a.AppointentId.Equals(appointment.AppointentId));
            if (previousAppointment != null)
                AppointmentGrid.Appointments[AppointmentGrid.Appointments.IndexOf(previousAppointment)] = appointment;
        }
    }
}
