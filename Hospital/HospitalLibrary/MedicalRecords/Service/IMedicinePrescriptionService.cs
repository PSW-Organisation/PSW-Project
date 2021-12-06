using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IMedicinePrescriptionService
    {
        public List<MedicinePrescription> GetAll();
        public MedicinePrescription Get(int id);

        public void Save(MedicinePrescription prescription);

        public void Delete(MedicinePrescription prescription);
    }
}
