﻿using ehealthcare.Model;
using FluentValidation;
using HospitalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI
{
	public class PatientFeedbackValidator : AbstractValidator<PatientFeedbackDto>
	{
		public PatientFeedbackValidator()
		{
			RuleFor(x => x.PatientUsername).MinimumLength(1);
			RuleFor(x => x.Text).Length(4, 120);
			RuleFor(x => x.Anonymous).Must(x => x == true || x == false);
			RuleFor(x => x.PublishAllowed).Must(x => x == true || x == false);
		}
	}
}