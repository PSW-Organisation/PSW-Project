using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginType LoginType { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(string username, string password, LoginType loginType)
        {
            Username = username;
            Password = password;
            LoginType = loginType;
        }
    }
}
