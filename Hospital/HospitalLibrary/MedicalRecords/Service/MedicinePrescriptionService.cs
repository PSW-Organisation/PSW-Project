using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public class MedicinePrescriptionService : IMedicinePrescriptionService
    {
        private IMedicinePrescriptionRepository prescriptionRepository;

        public MedicinePrescriptionService(IMedicinePrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }
        public void Delete(MedicinePrescription prescription)
        {
            prescriptionRepository.Delete(prescription);
        }

        public MedicinePrescription Get(int id)
        {
            return prescriptionRepository.Get(id);
        }

        public List<MedicinePrescription> GetAll()
        {
            return prescriptionRepository.GetAll().ToList();
        }

        public void Save(MedicinePrescription prescription)
        {
            prescriptionRepository.Insert(prescription);
        }
    }
}
