using ehealthcare.Model;
using HospitalLibrary.Repository;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Shared.Repository
{
    public interface IUserRepository : IGenericSTRINGIDRepository<User>
    {
        public User GetUsingCredentials(string username, string password);
    }
}
