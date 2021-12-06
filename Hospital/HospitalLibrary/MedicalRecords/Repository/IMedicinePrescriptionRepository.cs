using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Repository
{
    public interface IMedicinePrescriptionRepository : IGenericRepository<MedicinePrescription>
    {
    }
}
