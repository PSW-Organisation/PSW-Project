using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace HospitalTests
{
    public class EmailTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Validate_registration_email_input(string email, bool valid)
        {
           Assert.Equal(Validate(email), valid);
        }

     
        public static IEnumerable<object[]> Data =>
                                            new List<object[]>
                                            {
                                                new object[] { null, false },
                                                new object[] { " ", false },
                                                new object[] { "\n\t", false },
                                                new object[] { "name", false },
                                                new object[] { "name@gmail.com", true }
                                            };
        private bool Validate(string value)
        {
            return string.IsNullOrWhiteSpace(value) || !IsValidFormat(value) ? false : true;
        }


        private bool IsValidFormat(string value)
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return regex.IsMatch(value);
        }
    }
}
