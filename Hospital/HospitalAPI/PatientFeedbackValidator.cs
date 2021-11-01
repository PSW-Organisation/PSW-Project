using ehealthcare.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI
{
	public class PatientFeedbackValidator : AbstractValidator<PatientFeedback>
	{
		public PatientFeedbackValidator()
		{
			RuleFor(x => x.id).NotNull();
			RuleFor(x => x.patientId).NotNull();
			RuleFor(x => x.text).Length(4, 120);
			RuleFor(x => x.anonymous).Must(x => x == true || x == false);
			RuleFor(x => x.publishAllowed).Must(x => x == true || x == false);
		}
	}
}
