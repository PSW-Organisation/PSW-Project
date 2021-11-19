using ehealthcare.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace HospitalUnitTests
{
    public class PersonalDoctorTest
    {

        [Fact]
        public void Find_available_personal_doctors()
        {

            var list = new[] {
                new Doctor(){
                    Specialization = Specialization.cardiologist,
                    UsedOffDays = 2,
                    Patients = new List<Patient>(){ 
                        new Patient() { }, 
                        new Patient() { } 
                    }
                },
                new Doctor(){
                    Specialization = Specialization.none,
                    UsedOffDays = 2,
                    Patients = new List<Patient>(){
                        new Patient() { },
                        new Patient() { },
                        new Patient() { },
                        new Patient() { }
                    }
                },
                new Doctor(){
                    Specialization = Specialization.none,
                    UsedOffDays = 2,
                    Patients = new List<Patient>(){
                        new Patient() { },
                        new Patient() { },
                        new Patient() { }
                    }
                },
            };

            int minNumberOfPatients = list.Where<Doctor>(d => d.Specialization.Equals(Specialization.none))
                                        .Select(d => d.Patients.Count).Min();
            Assert.Equal(3, minNumberOfPatients);
        }

        

    }
}
