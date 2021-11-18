using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace HospitalUnitTests.FeedbackAndSurvey
{
    public class QuestionTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Validate_question_value_input(int value, bool valid)
        {
            Assert.Equal(Validate(value), valid);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1, true },
                new object[] { -1, false },
                new object[] { 7, false },
            };
        private bool Validate(int value)
        {
            return value > 0 && value < 6;
        }
    }
}