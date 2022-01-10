using ehealthcare.Model;
using HospitalLibrary.Schedule.Repository;
using HospitalLibrary.Schedule.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.Schedule.Model;

namespace HospitalUnitTests.Schedule
{
    public class AppointmentTests
    {
        [Theory]
        [MemberData(nameof(System.Data))]
        public void Find_appointments_by_username(string username, int visitCount)
        {
            HospitalDbContext context = MockDbContext.InitMockContext();
            if(context.Visits.Count() == 0) SeedData(context);
            var visitRepository = new VisitDbRepository(context);
            var doctorRepository = new DoctorDbRepository(context);
            var service = new VisitService(visitRepository, doctorRepository);

            List<Visit> visits = service.GetVisitsByUsername(username);
            int usersVisits = visits.Count; 

            Assert.Equal(visitCount, usersVisits);
        }

        [Theory]
        [MemberData(nameof(Data_cancel))]
        public void Cancel_appointmets(string username, int id)
        {
            HospitalDbContext context = MockDbContext.InitMockContext();
            if (context.Visits.Count() == 0) SeedData(context);
            var visitRepository = new VisitDbRepository(context);
            var doctorRepository = new DoctorDbRepository(context);
            var service = new VisitService(visitRepository, doctorRepository);

            List<Visit> visits = service.GetVisitsByUsername(username);
            Visit visit = visits.Find(v=> v.Id == id);
            service.CancelVisit(visit);

            Assert.True(visit.Status.IsCanceled);
        }

        [Theory]
        [MemberData(nameof(Data_by_date_and_doctor))]
        public void Find_forthcoming_appointmets_by_date_and_doctor(DateTime begining, DateTime ending, string doctorId, int expectedNumber)
        {
            HospitalDbContext context = MockDbContext.InitMockContext();
            if (context.Visits.Count() == 0) SeedData(context);
            var visitRepository = new VisitDbRepository(context);
            var doctorRepository = new DoctorDbRepository(context);
            var service = new VisitService(visitRepository, doctorRepository);

            List<Visit> visits = service.GetForthcomingVisitsByDateAndDoctor(begining, ending, doctorId);
            int usersVisitsByDateAndDoctor = visits.Count;

            Assert.Equal(expectedNumber, usersVisitsByDateAndDoctor);
        }

        [Theory]
        [MemberData(nameof(System.Data))]
        public void Review_appointment(string username, int id)
        {
            HospitalDbContext context = MockDbContext.InitMockContext();
            if (context.Visits.Count() == 0) SeedData(context);
            var visitRepository = new VisitDbRepository(context);
            var doctorRepository = new DoctorDbRepository(context);
            var service = new VisitService(visitRepository, doctorRepository);

            List<Visit> visits = service.GetVisitsByUsername(username);
            Visit visit = visits.Find(v => v.Id == id);
            service.ReviewVisit(visit);

            Assert.True(visit.Status.IsReviewed);
        }


        public static IEnumerable<object[]> Data =>
                                            new List<object[]>
                                            {
                                                new object[] { "luka", 1 },
                                                new object[] { "imbiamba", 2}
                                            };


        public static IEnumerable<object[]> Data_cancel =>
                                            new List<object[]>
                                            {
                                                new object[] { "luka", 1 },
                                                new object[] { "imbiamba", 2}
                                            };

        public static IEnumerable<object[]> Data_by_date_and_doctor =>
                                            new List<object[]>
                                            {
                                                new object[] { new DateTime(2021, 11, 29, 19, 00, 00), new DateTime(2021, 12, 01, 19, 00, 00), "mihajlo", 0},
                                                new object[] { new DateTime(2021, 11, 29, 19, 00, 00), new DateTime(2021, 12, 01, 19, 00, 00), "nelex", 0}
                                            };

        private static void SeedData(HospitalDbContext context)
        {
            context.Visits.Add(new Visit()
            {   
                
                DoctorId = "nelex",
                PatientId = "luka",
                Interval = VisitTimeInterval(new DateTime(2021, 11, 30, 19, 00, 00), new DateTime(2021, 11, 30, 19, 30, 00)),
                VisitType = VisitType.examination,
                Status = new VisitStatus(false, false)

            });
            context.Visits.Add(new Visit()
            {

                DoctorId = "mihajlo",
                PatientId = "imbiamba",
                Interval = VisitTimeInterval(new DateTime(2021, 11, 30, 19, 00, 00), new DateTime(2021, 11, 30, 19, 30, 00)),
                VisitType = VisitType.examination,
                Status = new VisitStatus(false, false)
            });
            context.SaveChanges();
        }

        private static VisitTimeInterval VisitTimeInterval(DateTime dateTime1, DateTime dateTime2)
        {
            throw new NotImplementedException();
        }
    }
}
