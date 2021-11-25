using PharmacyLibrary.Model;
using PharmacyLibrary.Repository.MedicineBenefitRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public class MedicineBenefitService : IMedicineBenefitService
    {
        private readonly IMedicineBenefitRepository medicineBenefitRepository;
        public MedicineBenefitService(IMedicineBenefitRepository medicineBenefitRepository) {
            this.medicineBenefitRepository = medicineBenefitRepository;
        }
        public bool Add(MedicineBenefit newMedicineBenefit)
        {
            return medicineBenefitRepository.Add(newMedicineBenefit);
        }

        public bool Delete(int id)
        {
            return medicineBenefitRepository.Delete(id);
        }

        public List<MedicineBenefit> Get()
        {
            return medicineBenefitRepository.Get();
        }

        public MedicineBenefit Get(int id)
        {
            return medicineBenefitRepository.Get(id);
        }

        public bool Update(MedicineBenefit m)
        {
            return medicineBenefitRepository.Update(m);
        }
    }
}
