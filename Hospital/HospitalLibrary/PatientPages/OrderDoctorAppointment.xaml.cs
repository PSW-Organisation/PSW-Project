using System.Windows.Controls;
using vezba.ViewModel.PatientViewModel;

namespace vezba.PatientPages
{
    public partial class OrderDoctorAppointment : Page
    {
        public OrderDoctorAppointment(OrderDoctorAppointmentViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
