using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace vezba.SecretaryGUI.Validation
{
    public class ValidationRuleJMBG : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexJMBG = new Regex(@"^[0-9]{13}$");
            var jmbg = value as string;
            if (regexJMBG.IsMatch(jmbg.Trim()))
            {
                return new ValidationResult(true, null);
            }
            if (jmbg.Trim().Length != 13)
                return new ValidationResult(false, "JMBG mora sadržati 13 cifara.");
            return new ValidationResult(false, "JMBG sme da sadrži samo cifre.");
        }
    }
    public class ValidationRuleIDNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexIDNum = new Regex(@"^[0-9]{9}$");
            var id = value as string;
            if (regexIDNum.IsMatch(id.Trim()))
            {
                return new ValidationResult(true, null);
            }
            if (id.Trim().Length != 9)
                return new ValidationResult(false, "Broj lične karte mora sadržati 9 cifara.");
            return new ValidationResult(false, "Broj lične karte sme da sadrži samo cifre.");
        }
    }
    public class ValidationRuleDate : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexDate = new Regex(@"^[0-3][0-9]\.[0-1][0-9]\.[1-2][0-9]{3}\.$");
            var date = value as string;
            if (regexDate.IsMatch(date.Trim()))
            {
                DateTime selectedDate = new DateTime(1900, 1, 1);
                try
                {
                    selectedDate = DateTime.ParseExact(date, "dd.MM.yyyy.", null);
                }
                catch
                {
                    return new ValidationResult(false, "Uneli ste nepostojeći datum.");
                }
                return new ValidationResult(true, null);

            }
            return new ValidationResult(false, "Datum mora biti u formatu: dd.mm.yyyy.");
        }
    }

    public class ValidationRuleRequired : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var name = value as string;
            if (!name.Trim().Equals(""))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Polje je obavezno.");
        }
    }

    public class ValidationRulePhoneNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexPhoneNum = new Regex(@"^\+?[0-9]{3,15}$");
            var phone = value as string;
            if (regexPhoneNum.IsMatch(phone.Trim()))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Broj telefona može da sadrži samo cifre.");
        }
    }
    public class ValidationRuleEmail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexEmail = new Regex(@"^[0-9a-z\.]+@[a-z\.]+\.[a-z]{1,5}$");
            var email = value as string;
            if (regexEmail.IsMatch(email.Trim()))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "email adresa je neparvilnog formata.");
        }
    }
}
