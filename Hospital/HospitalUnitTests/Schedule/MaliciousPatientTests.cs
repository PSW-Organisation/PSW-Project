using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using HospitalLibrary.Schedule.Model;
using HospitalLibrary.Model;

namespace HospitalUnitTests.Schedule
{
    public class MaliciousPatientTests
    {
        [Fact]
        public void Get_malicious_patients()
        {
            HospitalDbContext context = MockDbContext.InitMockContext();
            if (context.Visits.Count() == 0) SeedData(context);
            var repository = new PatientDbRepository(context);
            var service = new PatientService(repository);

            List<Patient> maliciousPatients = service.GetMaliciousPatients();

            Assert.Single(maliciousPatients);
            Assert.Equal("kristina", maliciousPatients[0].Username);
        }

        [Fact]
        public void Cancel_appointment()
        {
            HospitalDbContext context = MockDbContext.InitMockContext();
            if (context.Visits.Count() == 0) SeedData(context);
            var repository = new PatientDbRepository(context);
            var service = new PatientService(repository);

            Patient maliciousPatient = context.Patients.Find("kristina");
            service.BlockPatient(maliciousPatient);

            Assert.True(maliciousPatient.IsBlocked);
        }

        private static void SeedData(HospitalDbContext context)
        {
            context.Patients.Add(new Patient("kristina")
            {
                Id = "kristina",
                Username = "kristina",
                Password = "kristinica",
                LoginType = LoginType.patient,
                Info = new UserPersonalInfo("kristina", "Kristina", "Tamindzija", "Zoran", "female", new DateTime(1999, 11, 9)),
                IsBlocked = false,
                IsActivated = true,
                Token = new Guid("601ccaa8-3a07-4a7c-89b9-9923e6bac8a7"),
                Address =  new UserAddress("kristina", "019919195191", "sdjfsj@gmail.com", "Sime Milutinovica, 2", "Novi Sad", "Serbia")
            });

            context.Visits.Add(new Visit()
            {
                Id = -1,
                DoctorId = "nelex",
                PatientId = "imbiamba",
                Interval = new VisitTimeInterval(4, new DateTime(2021, 11, 30, 19, 00, 00), new DateTime(2021, 11, 30, 19, 30, 00)),
                VisitType = VisitType.examination,
                Status = new VisitStatus(-1, false, true)
            });
            context.Visits.Add(new Visit()
            {
                Id = 1,
                DoctorId = "nelex",
                PatientId = "imbiamba",
                Interval = new VisitTimeInterval(4, new DateTime(2021, 12, 30, 19, 00, 00), new DateTime(2021, 12, 30, 19, 30, 00)),
                VisitType = VisitType.examination,
                Status = new VisitStatus(1, false, true)
            });
            context.Visits.Add(new Visit()
            {
                Id = 2,
                DoctorId = "nelex",
                PatientId = "imbiamba",
                Interval = new VisitTimeInterval(4, new DateTime(2021, 12, 1, 19, 00, 00), new DateTime(2021, 12, 1, 19, 30, 00)),
                VisitType = VisitType.examination,
                Status = new VisitStatus(2, false, true)
            });
            context.Visits.Add(new Visit()
            {
                Id = 3,
                DoctorId = "nelex",
                PatientId = "kristina",
                Interval = new VisitTimeInterval(4, new DateTime(2021, 12, 7, 19, 00, 00), new DateTime(2021, 12, 7, 19, 30, 00)),
                VisitType = VisitType.examination,
                Status = new VisitStatus(3, false, true)
            });
            context.Visits.Add(new Visit()
            {
                Id = 4,
                DoctorId = "nelex",
                PatientId = "kristina",
                Interval = new VisitTimeInterval(4, new DateTime(2021, 12, 5, 19, 00, 00), new DateTime(2021, 12, 5, 19, 30, 00)),
                VisitType = VisitType.examination,
                Status = new VisitStatus(4, false, true)
            });
            context.Visits.Add(new Visit()
            {
                Id = 5,
                DoctorId = "nelex",
                PatientId = "kristina",
                Interval = new VisitTimeInterval(5, new DateTime(2021, 12, 8, 19, 00, 00), new DateTime(2021, 12, 8, 19, 30, 00)),
                VisitType = VisitType.examination,
                Status = new VisitStatus(5, false, true)
            });

           context.SaveChanges();
        }
    }
}
