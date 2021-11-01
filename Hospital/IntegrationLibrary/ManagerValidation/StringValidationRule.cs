using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace vezba.ManagerValidation
{
    class StringValidationRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                string CleanedString = Regex.Replace(s, "\\s+", "");
                String pattern = @"^\w+$";
                Regex rg = new Regex(pattern);
                if (rg.IsMatch(CleanedString))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Naziv može da sadrži samo slova i cifre.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
