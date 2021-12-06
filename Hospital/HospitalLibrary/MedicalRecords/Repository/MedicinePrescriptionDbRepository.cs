using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Repository
{
    public class MedicinePrescriptionDbRepository : GenericDbRepository<MedicinePrescription>, IMedicinePrescriptionRepository
    {
        public MedicinePrescriptionDbRepository(HospitalDbContext dbContext) : base(dbContext) { }
    }
}
