using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HospitalLibrary.Model;
using HospitalLibrary.MedicalRecords.Model;

namespace HospitalLibrary.MedicalRecords.Repository
{
    public class PatientDbRepository : GenericSTRINGIDRepository<Patient>, IPatientRepository
    {

        private HospitalDbContext _dbContext;

        public PatientDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void MapPatientAllergens(Patient patient, List<Allergen> allergens)
        {
            _dbContext.PatientAllergens.AddRange(allergens.Select(pa =>
                new PatientAllergen()
                {
                    PatientId = patient.Username,
                    AllergenId = pa.Id
                }
            ));

            _dbContext.SaveChanges();
        }

        public int Activate(Guid guid)
        {
            Patient patient = _dbContext.Patients.SingleOrDefault(p => p.Token.Equals(guid));
            if (patient is null) return 404;
            if (patient.IsActivated) return 400;
            patient.IsActivated = true;
            _dbContext.SaveChanges();
            return 200;
        }
    }
}
