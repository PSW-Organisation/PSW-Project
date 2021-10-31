using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;

namespace vezba.PatientPages
{
    public partial class Statistics : Page
    {
        public SeriesCollection SeriesCollectionn { get; set; }
        public string[] BarLabels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public Statistics()
        {
            InitializeComponent();
            this.DataContext = this;
            SeriesCollectionn = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "mesec",
                    Values = new ChartValues<double> { 2, 3, 0, 6 , 2, 4, 3, 7, 0, 0, 0, 0}
                }
            };

            BarLabels = new[] { "jan", "feb", "mar", "apr", "maj", "jun", "jul", "avg", "sep", "okt", "nov", "dec" };
            Formatter = value => value.ToString("N");
        }   
    }
}
