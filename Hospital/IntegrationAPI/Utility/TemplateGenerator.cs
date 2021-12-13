using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.Utility
{
    public class TemplateGenerator
    {
        public static string GetHTMLString(DateTime startTime, DateTime endTime, List<MedicineConsumption> consumption)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"
                <html>
                    <head></head>
                    <body>
                        <div class='header1'><h1>Medicine consumption</h1></div>
                        <div class='header2'><h2>{0} - {1}</h2></div>
                        <table align='center'>
                            <tr>
                                <th>Medicine</th>
                                <th>Ammount</th>
                            </tr>", startTime.ToString("dd/MM/yyyy"), endTime.ToString("dd/MM/yyyy"));

            foreach (var c in consumption)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                  </tr>", c.MedicineName, c.MedicineAmmount);
            }

            sb.Append(@"
                        </table>
                    </body>
                </html>");

            return sb.ToString();
        }

        public static string GetHTMLString(PrescriptionDTO prescription)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"
                <html>
                    <head></head>
                    <body>
                        <div class='header1'><h1>Medicine Prescription</h1></div>
                        <table align='center'>
                            <tr>
                                <td>Patient: </td>
                                <td>{0}</td>
                            </tr>
                            <tr>
                                <td>Doctor: </td>
                                <td>{1}</td>
                            </tr>
                            <tr>
                                <td>Medicine: </td>
                                <td>{2}</td>
                            </tr>
                            <tr>
                                <td>Prescription date: </td>
                                <td>{3}</td>
                            </tr>
                            <tr>
                                <td>Diagnosis: </td>
                                <td>{4}</td>
                            </tr>
                         </table>
                   </body>
                </html>", prescription.PatientId, prescription.DoctorId, prescription.MedicineId, prescription.PrescriptionDate.ToString("dd/MM/yyyy"), prescription.Diagnosis);

            return sb.ToString();
        }

        public static string GetHTMLString(PrescriptionDTO prescription, string base64Image)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"
                <html>
                    <head></head>
                    <body>
                        <div class='header1'><h1>Medicine Prescription</h1></div>
                        <img src='data:image/bmp;base64,{5}' class='center' />
                        <table align='center'>
                            <tr>
                                <td>Patient: </td>
                                <td>{0}</td>
                            </tr>
                            <tr>
                                <td>Doctor: </td>
                                <td>{1}</td>
                            </tr>
                            <tr>
                                <td>Medicine: </td>
                                <td>{2}</td>
                            </tr>
                            <tr>
                                <td>Prescription date: </td>
                                <td>{3}</td>
                            </tr>
                            <tr>
                                <td>Diagnosis: </td>
                                <td>{4}</td>
                            </tr>
                         </table>
                   </body>
                </html>", prescription.PatientId, prescription.DoctorId, prescription.MedicineId, prescription.PrescriptionDate.ToString("dd/MM/yyyy"), prescription.Diagnosis, base64Image);

            return sb.ToString();
        }
    }
}
