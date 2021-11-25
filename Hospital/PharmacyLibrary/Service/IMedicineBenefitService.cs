using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public interface IMedicineBenefitService
    {
        public List<MedicineBenefit> Get();

        public MedicineBenefit Get(int id);

        public Boolean Add(MedicineBenefit newMedicineBenefit);

        public Boolean Delete(int id);

        public Boolean Update(MedicineBenefit m);
    }
}
