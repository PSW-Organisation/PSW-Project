using ehealthcare.Model;
using ehealthcare.Service;
using HospitalLibrary.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace HospitalUnitTests.MedicalRecord
{
    public class UsernameTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Validate_registration_email_input(string username, bool valid)
        {
            Assert.Equal(Validate(username), valid);
        }

        public static IEnumerable<object[]> Data =>
                                            new List<object[]>
                                            {
                                                new object[] { "guy", false },
                                                new object[] { " ", false },
                                                new object[] { ".username", false },
                                                new object[] { "user_.name", false },
                                                new object[] { "username_", false },
                                                new object[] { "username.", false },
                                                new object[] { "bad!user", false },
                                                new object[] { "valid_Username", true },
                                                new object[] { "kristina99", true },
                                            };
        private bool Validate(string value)
        {
            return string.IsNullOrWhiteSpace(value) || !IsValidFormat(value) ? false : true;
        }


        private bool IsValidFormat(string value)
        {
            Regex regex = new Regex("^(?=[a-zA-Z0-9._]{4,20}$)(?!.*[_.]{2})[^_.].*[^_.]$");
            return regex.IsMatch(value);
        }
    }
}
