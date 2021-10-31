using System;

namespace Model
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Jmbg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public String PhoneNumber { get; set; }
        public String Adress { get; set; }
        public String Email { get; set; }
        public String IdCard { get; set; }
        public UserType Type { get; set; }
        public Boolean IsDeleted { get; set; }

    }
}