using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class Country
    {
        private String name;
        private String code;
        private List<City> cities;

        public Country()
        {
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public string Code
        {
            get { return code; }

            set { code = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public List<City> Cities
        {
            get { return cities; }

            set { cities = value; }
        }
    }
}