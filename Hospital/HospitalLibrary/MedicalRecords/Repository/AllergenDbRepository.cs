using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Repository
{
    public class AllergenDbRepository: GenericDbRepository<Allergen>, IAllergenRepository
    {
        private readonly HospitalDbContext _dbContext;

        public AllergenDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
