using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository.MedicineBenefitRepository
{
    public interface IMedicineBenefitRepository
    {
        List<MedicineBenefit> Get();

        MedicineBenefit Get(int id);

        Boolean Add(MedicineBenefit newMedicine);

        Boolean Delete(int id);

        Boolean Update(MedicineBenefit m);
    }
}
