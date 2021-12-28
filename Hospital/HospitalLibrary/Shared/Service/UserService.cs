using ehealthcare.Model;
using HospitalLibrary.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Shared.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(string username)
        {
            return _userRepository.Get(username);
        }

        public User GetUsingCredentials(string username, string password)
        {
            return _userRepository.GetUsingCredentials(username, password);
        }
    }
}
