using System;

namespace ehealthcare.Model
{
    [Serializable]
    public class City
    {
        private String name;
        private String postalCode;
        private Country country;

        public City()
        {
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public string PostalCode
        {
            get { return postalCode; }

            set { postalCode = value; }
        }

        public Country Country
        {
            get { return country; }

            set { country = value; }
        }
    }
}