using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace HospitalUnitTests.MedicalRecord
{
    public class PasswordTest
    {

        [Theory]
        [MemberData(nameof(Data))]
        public void Validate_registration_email_input(string password, bool valid)
        {
            Assert.Equal(Validate(password), valid);
        }

        public static IEnumerable<object[]> Data =>
                                            new List<object[]>
                                            {
                                                new object[] { "password", false },
                                                new object[] { " ", false },
                                                new object[] { "Password", false },
                                                new object[] { "Password123", false },
                                                new object[] { "Password!", false },
                                                new object[] { "short1!", false },
                                                new object[] { "MickeyMinniePlutoHueyLouieDeweyDonaldGoofySacramento1!", false },
                                                new object[] { "ValidPassword123!", true },
                                                new object[] { "Val!id123passw@rd", true },
                                            };
        private bool Validate(string value)
        {
            return string.IsNullOrWhiteSpace(value) || !IsValidFormat(value) ? false : true;
        }


        private bool IsValidFormat(string value)
        {
            Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,40}$");
            return regex.IsMatch(value);
        }
    }
}
