using System.Windows.Controls;
using vezba.ViewModel.PatientViewModel;

namespace vezba.PatientPages
{
    public partial class GradeHospitalPage : Page
    {
        public GradeHospitalPage(GradeHospitalViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void comment_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            VirtualKeyboard keyboard = new VirtualKeyboard(comment);
            keyboard.Show();
        }
    }
}
