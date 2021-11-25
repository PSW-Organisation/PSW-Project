using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service
{
    public class MedicineBenefitService : IMedicineBenefitService
    {
        private MedicineBenefitRepository medicineBenefitRepository;

        public MedicineBenefitService(MedicineBenefitRepository medicineBenefitRepository)
        {
            this.medicineBenefitRepository = medicineBenefitRepository;
        }
        public void ChangeBenefitStatus(MedicineBenefit medicineBenefit, bool published)
        {
            medicineBenefit.Published = published;
            this.Update(medicineBenefit);
        }

        public void Delete(MedicineBenefit medicineBenefit)
        {
            this.medicineBenefitRepository.Delete(medicineBenefit);
        }

        public MedicineBenefit Get(int id)
        {
            return this.medicineBenefitRepository.Get(id);
        }

        public List<MedicineBenefit> GetAll()
        {
            return this.medicineBenefitRepository.GetAll();

        }

        public void Save(MedicineBenefit medicineBenefit)
        {
            medicineBenefit.Id = this.medicineBenefitRepository.GenerateId();
            this.medicineBenefitRepository.Save(medicineBenefit);
        }

        public void Update(MedicineBenefit medicineBenefit)
        {
            this.medicineBenefitRepository.Update(medicineBenefit);
        }
    }
}
