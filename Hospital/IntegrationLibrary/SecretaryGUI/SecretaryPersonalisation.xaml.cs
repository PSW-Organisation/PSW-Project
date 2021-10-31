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

namespace vezba.SecretaryGUI
{
    /// <summary>
    /// Interaction logic for SecretaryPersonalisation.xaml
    /// </summary>
    public partial class SecretaryPersonalisation : Window
    {
        private SecretaryMainWindow parent;
        public SecretaryPersonalisation(SecretaryMainWindow p)
        {
            InitializeComponent();
            parent = p;
            List<string> languages = new List<string> { "Srpski", "Engleski" };
            Language.ItemsSource = languages;
            Language.SelectedIndex = 0;
            List<string> themes = new List<string> { "Svetla", "Tamna" };
            Theme.ItemsSource = themes;

            var app = (App)Application.Current;
            if (app.theme == "dark")
            {
                Theme.SelectedIndex = 1;
            }
            else
                Theme.SelectedIndex = 0;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var app = (App)Application.Current;
            
            if (Theme.SelectedIndex == 0)
            {
                app.ChangeTheme(new Uri("Themes/Light.xaml", UriKind.Relative), "light");
                parent.selectedTabColor = new SolidColorBrush(Color.FromRgb(206, 208, 253));
                parent.selectedButton.Background = parent.selectedTabColor;
            }
            else
            {
                app.ChangeTheme(new Uri("Themes/Dark.xaml", UriKind.Relative), "dark");
                parent.selectedTabColor = new SolidColorBrush(Color.FromRgb(101, 90, 113));
                parent.selectedButton.Background = parent.selectedTabColor;
            }

        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.Close();
        }
    }
}