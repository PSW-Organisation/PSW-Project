﻿using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using vezba.Command;

namespace vezba.ViewModel.PatientViewModel
{
    public class OrderTimeAppointmentViewModel
    {
        public NavigationService NavigationService { get; set; }
        public static ObservableCollection<Doctor> Doctors { get; set; }
        private DoctorService DoctorService { get; set; }
        private AppointmentService AppointmentService { get; set; }
        public DateTime SelectedDate { get; set; }
        public String SelectedTime { get; set; }
        public Doctor SelectedDoctor { get; set; }
        public RelayCommand OrderAppointmentCommand { get; set; }

        public OrderTimeAppointmentViewModel(NavigationService navigation)
        {
            this.NavigationService = navigation;
            DoctorService = new DoctorService();
            AppointmentService = new AppointmentService();
            List<Doctor> doctors = DoctorService.GetAllDoctors();
            Doctors = new ObservableCollection<Doctor>(doctors);

            OrderAppointmentCommand = new RelayCommand(Execute_OrderAppointmentCommand, CanExecuteCommand);
        }

        public void Execute_OrderAppointmentCommand(object obj)
        {
            if (HasAllInfo())
            {
                DateTime dateTimeFinal = AppointmentService.ParseTime(SelectedDate, SelectedTime);
                Appointment a = new Appointment(SelectedDoctor, dateTimeFinal, PatientView.Patient);

                if (AppointmentService.CanSchedule(SelectedDate))
                {
                    AppointmentService.PatientCanScheduleAppointment(a);
                }
                else
                {
                    PatientNotification noti = new PatientNotification("Unet datum nije validan!");
                    noti.ShowDialog();
                }
            }
            else
            {
                PatientNotification noti = new PatientNotification("Molimo Vas popunite sva potrebna polja!");
                noti.ShowDialog();
            }
        }

        public bool CanExecuteCommand(object obj)
        {
            return true;
        }

        private Boolean HasAllInfo()
        {
            if (SelectedDate != null && (SelectedTime != null && !SelectedTime.Equals("")) && SelectedDoctor != null)
                return true;
            return false;
        }
    }
}
