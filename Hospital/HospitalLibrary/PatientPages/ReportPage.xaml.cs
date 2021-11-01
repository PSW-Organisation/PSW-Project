using Model;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vezba.PatientPages
{
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            using (PdfDocument doc = new PdfDocument())
            {
                PdfPage page = doc.Pages.Add();

                PdfLightTable pdfLightTable = new PdfLightTable();

                DataTable table = new DataTable();

                table.TableName = "TABELA TERAPIJA ZA ODREĐENI PERIOD";

                table.Columns.Add("     Lek");

                table.Columns.Add("     Dnevni unos");

                table.Columns.Add("     Početak terapije");

                table.Columns.Add("     Kraj terapije");

                foreach (Prescription p in PatientView.Patient.MedicalRecord.Prescription)
                {
                    if(p.StartDate.Date < endDate.SelectedDate && startDate.SelectedDate < p.StartDate.AddDays(p.DurationInDays).Date)
                    {
                        table.Rows.Add(new string[] { "     " + p.Medicine.Name, "      " + p.Number.ToString(), "      " + p.StartDate.ToString("dd/MM/yyyy"), "       " + p.StartDate.AddDays(p.DurationInDays).ToString("dd/MM/yyyy") });
                    }
                }

                pdfLightTable.DataSource = table;

                pdfLightTable.Draw(page, new PointF(0, 20));

                PdfGraphics graphics = page.Graphics;

                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);

                graphics.DrawString("Za selektovani period pacijent Petar Ilić je imao prepisane terapije iz tabele ispod.", font, PdfBrushes.Black, new PointF(0, 0));

                doc.Save("../../Reports/TherapiesReport.pdf");
                doc.Close(true);
            }

            PatientNotification noti = new PatientNotification("Uspešno kreiran izveštaj o terapijama.");
            noti.ShowDialog();
        }
    }
}
