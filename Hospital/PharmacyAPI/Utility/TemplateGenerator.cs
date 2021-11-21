using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyAPI.Utility
{
    public class TemplateGenerator
    {
        public static string GetHTMLString(Medicine medicine)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"
                <html>
                    <head></head>
                    <body>
                        <div class='header'><h1>Medicine details</h1></div>
                        <table align='center'>
                            <tr>
                                <td>Medicine name: </td>
                                <td>{0}</td>
                            </tr>
                            <tr>
                                <td>Use for: </td>
                                <td>", medicine.Name);

            string prefix = @"";
            foreach (var use in medicine.UseFor)
            {
                sb.Append(prefix);
                prefix = @",";
                sb.Append(@"" + use);
            }

            sb.Append(@"        </td>
                            </tr>
                            <tr>
                                <td>Side effects: </td>
                                <td>");

            prefix = @"";
            foreach (var sideEffect in medicine.SideEffects)
            {
                sb.Append(prefix);
                prefix = @",";
                sb.Append(@"" + sideEffect);
            }

            sb.Append(@"        </td>
                            </tr>
                            <tr>
                                <td>Ingredients: </td>
                                <td>");

            prefix = @"";
            foreach (var ingredient in medicine.Ingredients)
            {
                sb.Append(prefix);
                prefix = @",";
                sb.Append(@"" + ingredient);
            }

            sb.Append(@"        </td>
                            </tr>
                         </table>
                   </body>
                </html>");

            return sb.ToString();
        }
    }
}
