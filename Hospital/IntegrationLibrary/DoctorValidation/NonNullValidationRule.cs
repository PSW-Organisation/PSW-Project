using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace vezba.DoctorValidation
{
    class NonNullValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var s = value as string;
            int r;
            if (s == null || s.Length == 0)
                return new ValidationResult(false, "Polje je obavezno!");
            return new ValidationResult(true, null);
        }
    }
}
