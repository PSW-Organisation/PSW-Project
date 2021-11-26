using FluentValidation;
using HospitalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validators
{
    public class PatientValidator : AbstractValidator<PatientDto>
    {
        public PatientValidator()
        {
            RuleFor(x => x.Username).Matches("^(?=[a-zA-Z0-9._]{4,20}$)(?!.*[_.]{2})[^_.].*[^_.]$");
            RuleFor(x => x.Password).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,40}$");
            RuleFor(x => x.Name).Matches("^\\p{Lu}[\\p{Ll}]+$").MaximumLength(30);
            RuleFor(x => x.ParentName).Matches("^\\p{Lu}[\\p{Ll}]+$").MaximumLength(30);
            RuleFor(x => x.Surname).Matches("^\\p{Lu}[\\p{Ll}]+$").MaximumLength(30);
            RuleFor(x => x.DateOfBirth).LessThanOrEqualTo(DateTime.Now - new TimeSpan(18 * 365, 0, 0, 0));
            RuleFor(x => x.Gender).Must(x => x == "male" || x == "female");
            RuleFor(x => x.Phone).Matches("^(\\+\\d{3})?\\d{8,10}$");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Address).Matches("^[\\p{L}\\s,0-9\\/-]+$");
            RuleFor(x => x.Country).Must(x => x == "Serbia" || x == "Bosnia and Herzegovina" || x == "Montenegro");
            RuleFor(x => x.City).Matches("^[\\p{L}\\s]{2,}$");
            RuleFor(x => x.Medical).NotEmpty();
            RuleFor(x => x.Medical.PersonalId).Matches("\\d{13}");
            RuleFor(x => x.Medical.BloodType).IsInEnum();
            RuleFor(x => x.Medical.Profession).Matches("^[\\p{L}\\s,\\/-]+$").Length(3, 100);
            RuleFor(x => x.Medical.Height).InclusiveBetween(50, 280);
            RuleFor(x => x.Medical.Weight).InclusiveBetween(30, 650);
            RuleFor(x => x.Medical.DoctorId).Matches("^(?=[a-zA-Z0-9._]{4,20}$)(?!.*[_.]{2})[^_.].*[^_.]$");
        }
    }
}
