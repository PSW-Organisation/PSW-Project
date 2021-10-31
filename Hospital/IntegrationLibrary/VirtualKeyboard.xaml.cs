using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace vezba
{
    public partial class VirtualKeyboard : Window, INotifyPropertyChanged
    {
        private String letterInput;

        public String LetterInput
        {
            get { return letterInput; }
            set { letterInput = value; OnPropertyChanged("LetterInput"); }
        }

        public System.Windows.Controls.TextBox TextInput { get; set; }
        public VirtualKeyboard(System.Windows.Controls.TextBox text)
        {
            InitializeComponent();
            this.DataContext = this;
            TextInput = text;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }  

        private void BtnQ_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "q"; 
        }

        private void BtnSpace_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + " ";
        }

        private void BtnComma_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + ",";
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + ".";
        }

        private void BtnW_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "w";
        }

        private void BtnE_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "e";
        }

        private void BtnR_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "r";
        }

        private void BtnT_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "t";
        }

        private void BtnY_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "y";
        }

        private void BtnU_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "u";
        }

        private void BtnI_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "i";
        }

        private void BtnO_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "o";
        }

        private void BtnP_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "p";
        }

        private void BtnA_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "a";
        }

        private void BtnS_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "s";
        }

        private void BtnD_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "d";
        }

        private void BtnF_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "f";
        }

        private void BtnG_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "g";
        }

        private void BtnH_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "h";
        }

        private void BtnJ_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "j";
        }

        private void BtnK_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "k";
        }

        private void BtnL_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "l";
        }

        private void BtnZ_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "z";
        }

        private void BtnX_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "x";
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "c";
        }

        private void BtnV_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "v";
        }

        private void BtnB_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "b";
        }

        private void BtnN_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "n";
        }

        private void BtnM_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput + "m";
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            LetterInput = LetterInput.Replace(LetterInput.Substring(LetterInput.Length - 1), "");
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            TextInput.Text = LetterInput;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
