using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Repository
{
    public class UserDbRepository : GenericSTRINGIDRepository<User>, IUserRepository
    {

        private HospitalDbContext _dbContext;

        public UserDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
