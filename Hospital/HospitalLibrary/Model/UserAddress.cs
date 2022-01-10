using HospitalLibrary.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HospitalLibrary.Model
{
    public class UserAddress : ValueObject
    {
        public string UserId { get; }
        public string Phone { get; }
        public string Email { get; }
        public string Address { get; }
        public string City { get; }
        public string Country { get; }

        public UserAddress() { }
        public UserAddress(string userId, string phone, string email, string address, string city, string country)
        {
            UserId = userId;
            Phone = phone;
            Email = email;
            Address = address;
            City = city;
            Country = country;
        }
        public UserAddress Create(string userId, string phone, string email, string address, string city, string country)
        {
            return new UserAddress(userId, phone, email, address, city, country);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Phone;
            yield return Email;
            yield return Address;
            yield return City;
            yield return Country;
        }
    }
}
