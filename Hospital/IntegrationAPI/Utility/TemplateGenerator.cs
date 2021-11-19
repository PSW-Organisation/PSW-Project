using IntegrationLibrary.Model;
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
    }
}
