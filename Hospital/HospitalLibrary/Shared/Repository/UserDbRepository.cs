using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Shared.Repository
{
    public class UserDbRepository : GenericSTRINGIDRepository<User>, IUserRepository
    {
        private readonly HospitalDbContext _dbContext;

        public UserDbRepository(HospitalDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
