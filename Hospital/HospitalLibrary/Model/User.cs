using HospitalLibrary.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ehealthcare.Model
{
    [XmlInclude(typeof(Patient))]
    [XmlInclude(typeof(Doctor))]
    public class User : Entity
    {
        public LoginType LoginType { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsActivated { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }


        public string FullName
        {
            get { return Name + " " + Surname; }
        }

        public string ParentName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string HomeAddress { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int AddressId { get; set; }

        public User() : base("undefinedKey") { }

    }
}
