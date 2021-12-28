using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Model
{

    public class Address : ValueObject
    {
        public String Street { get; set; }
        public String Number { get;  set; }
        public String City { get;  set; }

        public String Country { get; set; }
      

        public Address() { }

        public Address(string street, string city, string num, string country)
        {
            if (country.IsNullOrEmpty() || city.IsNullOrEmpty() || street.IsNullOrEmpty() || num.IsNullOrEmpty())
                throw new ArgumentException("Some of arguments of address in not set!");
            Street = street;
            City = city;
            Number = num;
            Country = country;
        
        }
        public Address ChangeCountry(string country)
        {
            if (country.IsNullOrEmpty())
                throw new ArgumentException("Country name can not be empty");
            return new Address(country, this.City, this.Number, this.Street);
        }
        public Address ChangeCity(string city)
        {
            if (city.IsNullOrEmpty())
                throw new ArgumentException("City name can not be empty");
            return new Address(this.Country, city, this.Number, this.Street);
        }

        public Address ChangeStreet(string street)
        {
            if (street.IsNullOrEmpty())
                throw new ArgumentException("Street name can not be empty");
            return new Address(this.Country, this.City, this.Number, street);
        }
        public Address ChangeNumber(string number)
        {
            if (number.IsNullOrEmpty())
                throw new ArgumentException("Street name can not be empty");
            return new Address(this.Country, this.City, number, this.Street);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return City;
            yield return Number;
            yield return Country;
         
        }
    }
}
