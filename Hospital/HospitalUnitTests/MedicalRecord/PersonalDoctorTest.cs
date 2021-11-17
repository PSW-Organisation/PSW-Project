using ehealthcare.Model;
using HospitalLibrary.MedicalRecord.Repository;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace HospitalUnitTests
{
    public class PersonalDoctorTest
    {
        [Fact]
        public void Find_min_patients_number()
        {
            HospitalDbContext context = MockDbContext.InitMockContext();
            SeedData(context);
            var repository = new DoctorDbRepository(context);
            var service = new DoctorService(repository);

            int minNumberOfPatients = service.FindLeastNumberOfPatient();
            
            Assert.Equal(2, minNumberOfPatients);
        }

        [Fact]
        public void Find_least_occupied_doctors()
        {
            HospitalDbContext context = MockDbContext.InitMockContext();
           
            var repository = new DoctorDbRepository(context);
            var service = new DoctorService(repository);

            List<Doctor> doctors = service.GetLeastOccupiedDoctors(2);
            
            Assert.All(doctors, d => Assert.InRange(d.Patients.Count, 2, 4));
        }


        private static void SeedData(HospitalDbContext context)
        {
            context.Doctors.Add(new Doctor("nemanja")
            {
                Specialization = Specialization.none,
                UsedOffDays = 2,
                Patients = new List<Patient>(){
                        new Patient("luka") { },
                         new Patient("lukaaa") { }
                    }
            });
            context.Doctors.Add(new Doctor("maja")
            {
                Specialization = Specialization.none,
                UsedOffDays = 2,
                Patients = new List<Patient>(){
                        new Patient("milica") { },
                        new Patient("zora") { },
                        new Patient("milan") { },

                    }
            });
            context.Doctors.Add(new Doctor("mirko")
            {
                Specialization = Specialization.none,
                UsedOffDays = 2,
                Patients = new List<Patient>(){
                        new Patient("milicaaa") { },
                        new Patient("zoraaa") { },
                        new Patient("milanaa") { },
                        new Patient("milana") { },
                        new Patient("milanaaaa") { },
                    }
            });
            context.Doctors.Add(new Doctor("mihajlo")
            {
                Specialization = Specialization.cardiologist,
                UsedOffDays = 2,
                Patients = new List<Patient>(){
                        new Patient("jovana") { },

                    }
            });

            context.SaveChanges();
        }

       
    }
}
