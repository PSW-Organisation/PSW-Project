using ehealthcare.Model;
using ehealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Repository.DbRepository
{
    public class PatientFeedbackDbRepository : GenericDbRepository<PatientFeedback>, IPatientFeedbackRepository
    {

        public PatientFeedbackDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
