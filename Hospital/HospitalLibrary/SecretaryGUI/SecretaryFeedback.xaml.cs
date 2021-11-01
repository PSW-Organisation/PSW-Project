using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using vezba.Service;

namespace vezba.SecretaryGUI
{
    /// <summary>
    /// Interaction logic for SecretaryFeedback.xaml
    /// </summary>
    public partial class SecretaryFeedback : Window
    {
        public SecretaryFeedback()
        {
            InitializeComponent();
            this.DataContext = this;
            List<string> ratings = new List<string>();
            ratings.Add("5 - U potpunosti zadovoljan/a");
            ratings.Add("4 - Uglavnom zadovoljan/a");
            ratings.Add("3 - Delimično zadovoljan/a");
            ratings.Add("2 - Uglavnom nezadovoljan/a");
            ratings.Add("1 - U potpunosti nezadovoljan/a");
            RatingComboBox.ItemsSource = ratings;
            RatingComboBox.SelectedIndex = 0;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int rating = 0;
            if (RatingComboBox.SelectedIndex == 0)
                rating = 5;
            if (RatingComboBox.SelectedIndex == 1)
                rating = 4;
            if (RatingComboBox.SelectedIndex == 2)
                rating = 3;
            if (RatingComboBox.SelectedIndex == 3)
                rating = 2;
            if (RatingComboBox.SelectedIndex == 4)
                rating = 1;
            String content = UserExperience.Text;
            UserFeedback newUserFeedback = new UserFeedback(0, DateTime.Now, rating, content);
            UserFeedbackService r = new UserFeedbackService();
            r.SaveUserFeedback(newUserFeedback);

            SecretaryMessage m1 = new SecretaryMessage("Feedback je uspešno poslat.");
            m1.ShowDialog();
            this.Close();
        }

        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.SaveButton_Click(sender, e);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }
    }
}
