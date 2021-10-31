using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace vezba.DoctorValidation
{
    class StringToIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                int r;
                if (int.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Molimo vas unesite ceo broj.");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do neočekivane greške.");
            }
        }
    }

    public class MinMaxValidationRule : ValidationRule
    {
        public double Min
        {
            get;
            set;
        }

        public double Max
        {
            get;
            set;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var s = value as string;
            int r;
            if (int.TryParse(s, out r))
            {
                int d = int.Parse(s);
                if (d < Min) return new ValidationResult(false, "Vrednost suviše mala.");
                if (d > Max) return new ValidationResult(false, "Vrednost suviše velika.");
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Došlo je do neočekivane greške.");
            }
        }
    }

    public class NonZeroValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var s = value as string;
            int r;
            if (int.TryParse(s, out r))
            {
                int d = int.Parse(s);
                if (d == 0)
                {
                    return new ValidationResult(false, "Vrednost ne sme biti nula.");
                }

                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Došlo je do neočekivane greške.");
            }
        }
    }
}
