using HospitalLibrary.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ehealthcare.Model
{
    public class User : Entity
    {
        public LoginType LoginType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid Token { get; set; }
        public bool IsActivated { get; set; }
        public bool IsBlocked { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return Name + " " + Surname; } }
        public string ParentName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public User(string id) : base(id) { }

    }
}
