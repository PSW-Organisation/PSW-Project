using System;

namespace ehealthcare.Model
{
    
    public class Address
    {
        private String homeAddress;
        private City city;

        public Address()
        {
        }

        public String HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }

        public City City
        {
            get { return city; }
            set { city = value; }
        }

        public override string ToString()
        {
            return homeAddress;
        }
    }
}