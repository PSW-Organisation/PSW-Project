using System;
using System.Collections.Generic;
using System.Linq;
using ehealthcare.Model;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.FeedbackAndSurvey.Repository;
using HospitalLibrary.FeedbackAndSurvey.Service;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Service;
using Xunit;

namespace HospitalUnitTests.FeedbackAndSurvey
{
    public class SurveyTest
    {
        [Fact]
        public void Find_survey_stats()
        {
            HospitalDbContext context = MockDbContext.InitMockContext();
            SeedData(context);
            var repository = new SurveyDbRepository(context);
            var service = new SurveyService(repository);

            List<SurveyStats> stats = service.GetSurveyStats().ToList();

            Assert.Equal(2.5, stats[0].Avg);
            Assert.Equal(1, stats[0].Three);
            Assert.NotEqual(1, stats[0].Five);
        }

        private static void SeedData(HospitalDbContext context)
        {
            context.Surveys.Add(new Survey()
            {
                Id = 1,
                PatientId = "imbiamba",
                SubmissionDate = new DateTime(2021, 11, 18),
                VisitId = 1
            });
            context.Surveys.Add(new Survey()
            {
                Id = 2,
                PatientId = "imbiamba",
                SubmissionDate = new DateTime(2021, 11, 18),
                VisitId = 1
            });
            context.Questions.Add(new Question()
            {
                SurveyId = 1,
                Id = 1,
                Value = 3,
                Category = QuestionCategory.hospital
            });
            context.Questions.Add(new Question()
            {
                SurveyId = 2,
                Id = 1,
                Value = 2,
                Category = QuestionCategory.hospital
            });
            context.SaveChanges();
        }

    }
}