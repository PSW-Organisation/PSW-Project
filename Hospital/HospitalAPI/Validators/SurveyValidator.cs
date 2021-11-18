using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HospitalAPI.DTO;

namespace HospitalAPI.Validators
{
    public class SurveyValidator : AbstractValidator<SurveyQuestionDto>
    {
        public SurveyValidator()
        {
            RuleForEach(s => s.Questions)
                .Must(q => q.Value > 0 && q.Value < 6);
            RuleFor(s => s.Questions).Must(q => q.Count == 15);
        }
    }
}
