using System;
using System.Xml.Serialization;

namespace IntegrationLibrary.Model
{
    [XmlInclude(typeof(Patient))]
    [XmlInclude(typeof(Doctor))]
    public abstract class User : Entity
    {
        private String name;
        private String surname;
        private String parentName;
        private String gender;
        private DateTime dateOfBirth;
        private String phone;
        private String email;
        private Address address;

        public User() : base(-1) { }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public String FullName
        {
            get { return name + " " + surname; }
        }

        public String ParentName
        {
            get { return parentName; }
            set { parentName = value; }
        }

        public String Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public String AddressString
        {
            get
            {
                if (address != null)
                {
                    return address.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
