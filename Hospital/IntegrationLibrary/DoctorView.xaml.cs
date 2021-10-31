using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Model;
using vezba.DoctorPages;
using vezba.Repository;

namespace vezba
{
    /// <summary>
    /// Interaction logic for DoctorView.xaml
    /// </summary>
    /// 

    public partial class DoctorView : Window
    {
        public Doctor DoctorUser;

        public DoctorView()
        {
            InitializeComponent();
            DoctorFileRepository ds = new DoctorFileRepository();
            DoctorUser = ds.GetOne("1708962324890");
            Main.Content = new Calendar(this);
            TbUser.Text = DoctorUser.NameAndSurname;
        }

        private void CalendarClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Calendar(this);
        }

        private void MedicineClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new MedicinePageView(this);
        }

        private void AnnouncementsClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new AnnouncementsView(UserType.doctor, this);
        }

        private void ExpandClick(object sender, RoutedEventArgs e)
        {
            if(ExpandGrid.Visibility == System.Windows.Visibility.Collapsed)
            {
                ExpandGrid.Visibility = System.Windows.Visibility.Visible;
            }
            else
                ExpandGrid.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void LogOutClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var s = new MainWindow();
            s.Show();
            Close();
        }

        private void FeedbackClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Main.Content = new DoctorFeedback(this);
            ExpandGrid.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void AppointmentGridClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new AppointmentGrid(this);
        }
    }
}
