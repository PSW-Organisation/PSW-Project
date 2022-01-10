using HospitalLibrary.Model;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;


namespace ehealthcare.Model
{
    public class User : Entity
    {
        public LoginType LoginType { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Guid Token { get; set; }
        public bool IsActivated { get; set; }
        public bool IsBlocked { get; set; }
        public virtual UserPersonalInfo Info { get; set; }
        public virtual UserAddress Address { get; set; }
        public User(string id) : base(id) {
            Username = Id;
         }

    }
}
