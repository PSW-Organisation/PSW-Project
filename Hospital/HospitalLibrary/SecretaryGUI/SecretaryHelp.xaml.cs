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
    /// Interaction logic for SecretaryHelp.xaml
    /// </summary>
    public partial class SecretaryHelp : Window
    {
        public SecretaryHelp()
        {
            InitializeComponent();
            String text = "";
            text += "Da bi se korisnicima olakšao rad sa tastature omogućene su sledeće prečice:\n\n";
            text += "Kretanje kroz tabove korišćenjem F-Key tastera:\n";
            text += "\t F1 - Pacijenti\n";
            text += "\t F2 - Termini\n";
            text += "\t F3 - Lekari\n";
            text += "\t F4 - Prostorije\n";
            text += "\t F5 - Obaveštenja\n";
            text += "\t F6 - Notifikacije\n";
            text += "\t F7 - Podešavanje teme i jezika\n";
            text += "\t F8 - Help\n";
            text += "\t F9 - Ostavljanje feedback-a\n";

            text += "\n";
            text += "Dodatne prečice za rad sa podacima u tabelama su naglašene na samom prikazu, ispod dugmeta za koga su vezane.\n";
            text += "Svi dijalozi se mogu zatvoriti pritiskom na ESC, dok se potvrda vrši pritiskoom na ENTER.\n\n";
            text += "Imajte na umu da se kroz aplikaciju uvek možete kretati koristeći TAB.\n\n";
            TextBlock.Text = text;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            if (e.Key == Key.Enter)
                this.Close();
        }
    }
}