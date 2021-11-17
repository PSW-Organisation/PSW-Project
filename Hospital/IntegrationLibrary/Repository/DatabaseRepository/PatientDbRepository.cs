using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class PatientDbRepository : GenericDatabaseRepository<Patient>, PatientRepository
    {
        public PatientDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }

        public Patient GetPatientByName(string fullName)
        {
            foreach (Patient patient in base.GetAll())
            {
                if (patient.FullName == fullName)
                {
                    return patient;
                }
            }
            return null;
        }
    }
}
