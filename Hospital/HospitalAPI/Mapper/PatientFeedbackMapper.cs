using ehealthcare.Model;
using HospitalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mapper
{
    public static class PatientFeedbackMapper
    {
        public static PatientFeedbackDto ToFeedbackDto(PatientFeedback feedback)
        {
            PatientFeedbackDto mapped = new PatientFeedbackDto()
            {
                PatientUsername = feedback.PatientUsername,
                SubmissionDate = feedback.SubmissionDate,
                Text = feedback.Text,
                Anonymous = feedback.Anonymous,
                PublishAllowed = feedback.PublishAllowed,
                IsPublished = feedback.IsPublished
            };
            
            return mapped;
        }

        public static PatientFeedback ToFeedback(PatientFeedbackDto feedbackDto)
        {
            PatientFeedback mapped = new PatientFeedback()
            {
                PatientUsername = feedbackDto.PatientUsername,
                SubmissionDate = feedbackDto.SubmissionDate,
                Text = feedbackDto.Text,
                Anonymous = feedbackDto.Anonymous,
                PublishAllowed = feedbackDto.PublishAllowed,
                IsPublished = feedbackDto.IsPublished
            };

            return mapped;
        }

    }
}
