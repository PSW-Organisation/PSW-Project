using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace HospitalUnitTests.MedicalRecord
{
    public class NameTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Validate_registration_email_input(string name, bool valid)
        {
            Assert.Equal(Validate(name), valid);
        }

        public static IEnumerable<object[]> Data =>
                                            new List<object[]>
                                            {
                                                new object[] { "firstnotupper", false },
                                                new object[] { " ", false },
                                                new object[] { "Firstupper!", false },
                                                new object[] { "Firstupper1", false },
                                                new object[] { "L", false },
                                                new object[] { "Longestnamethisworldhaseverseen", false },
                                                new object[] { "Lenka Isidora", true },
                                                new object[] { "Bé", true },
                                                new object[] { "Žika", true },
                                                new object[] { "Ивана", true },
                                            };
        private bool Validate(string value)
        {
            return string.IsNullOrWhiteSpace(value) || !IsValidFormat(value) ? false : true;
        }


        private bool IsValidFormat(string value)
        {
            Regex regex = new Regex("^\\p{Lu}[\\p{L}\\s]{1,29}$");
            return regex.IsMatch(value);
        }
    }
}
