using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IMedicineBenefitService
    {
        public List<MedicineBenefit> GetAll();
        public MedicineBenefit Get(int id);
        public void Save(MedicineBenefit medicineBenefit);
        public void Delete(MedicineBenefit medicineBenefit);
        public void Update(MedicineBenefit medicineBenefit);
        public void ChangeBenefitStatus(MedicineBenefit medicineBenefit, bool published);
    }
}
