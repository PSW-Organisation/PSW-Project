using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Shared.Service
{
    public interface IUserService
    {
        public User GetUser(string username);
        public User GetUsingCredentials(string username, string password);
    }
}
