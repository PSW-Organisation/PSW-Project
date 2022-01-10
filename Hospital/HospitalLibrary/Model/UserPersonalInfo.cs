using HospitalLibrary.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HospitalLibrary.Model
{
    public class UserPersonalInfo : ValueObject
    {
        public string UserId { get; }
        public string Name { get; }
        public string Surname { get; }
        public string FullName { get { return Name + " " + Surname; } }
        public string ParentName { get; }
        public string Gender { get; }
        public DateTime DateOfBirth { get; }

        public UserPersonalInfo() { }
        public UserPersonalInfo(string userId, string name, string surname, string parentName, string gender, DateTime dateOfBirth)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            ParentName = parentName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Validate();
        }
        private void Validate()
        {
            if (DateOfBirth.Subtract(DateTime.Now) == new TimeSpan(0, 0, 0))
                throw new ArgumentException();
        }
        public UserPersonalInfo Create(string userId, string name, string surname, string parentName, string gender, DateTime dateOfBirth)
        {
            return new UserPersonalInfo(userId, name, surname, parentName, gender, dateOfBirth);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Surname;
            yield return FullName;
            yield return ParentName;
            yield return Gender;
            yield return DateOfBirth;
        }
    }
}
