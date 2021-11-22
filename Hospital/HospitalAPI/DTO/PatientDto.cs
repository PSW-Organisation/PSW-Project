﻿using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class PatientDto
    {
        public LoginType LoginType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string ParentName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int AddressId { get; set; }
        /*
        public string PatientId { get; set; }
        public string PersonalId { get; set; }
        public BloodType BloodType { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Profession { get; set; }
        public string DoctorId { get; set; }
      
      */
        public virtual ICollection<Allergen> Allergens { get; set; }
        public MedicalRecord Medical { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsActivated { get; set; }
        public  List<MedicalPermit> MedicalPermits { get; set; }
    }
}