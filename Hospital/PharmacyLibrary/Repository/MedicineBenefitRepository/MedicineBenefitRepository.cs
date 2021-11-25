using PharmacyAPI;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyLibrary.Repository.MedicineBenefitRepository
{
    public class MedicineBenefitRepository : IMedicineBenefitRepository
    {
        private readonly PharmacyDbContext pharmacyDbContext;
        public MedicineBenefitRepository(PharmacyDbContext pharmacyDbContext)
        {
            this.pharmacyDbContext = pharmacyDbContext;
        }
        public bool Add(MedicineBenefit newMedicineBenefit)
        {
            if (newMedicineBenefit.MedicineId < 0 || newMedicineBenefit.MedicineBenefitDueDate < DateTime.Now || newMedicineBenefit.MedicineBenefitTitle.Length <= 0)
            {
                return false;
            }
            int id = pharmacyDbContext.MedicineBenefits.ToList().Count > 0 ? pharmacyDbContext.MedicineBenefits.Max(medicineBenefit => medicineBenefit.Id) + 1 : 1;

            newMedicineBenefit.Id = id;
            

          

            pharmacyDbContext.MedicineBenefits.Add(newMedicineBenefit);
            pharmacyDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            MedicineBenefit medicineBenefit = pharmacyDbContext.MedicineBenefits.SingleOrDefault(medicineBenefit => medicineBenefit.Id == id);
            if(medicineBenefit == null)
            {
                return false;
            }
            else
            {
                pharmacyDbContext.Remove(medicineBenefit);
                pharmacyDbContext.SaveChanges();
                return true;
            }
        }

        public List<MedicineBenefit> Get()
        {
            List<MedicineBenefit> medicineBenefits = new List<MedicineBenefit>();
            pharmacyDbContext.MedicineBenefits.ToList().ForEach(medicineBenefit => medicineBenefits.Add(medicineBenefit));
            return medicineBenefits;
        }

        public MedicineBenefit Get(int id)
        {
            MedicineBenefit medicineBenefit = pharmacyDbContext.MedicineBenefits.FirstOrDefault(medicineBenefit => medicineBenefit.Id == id);
            if(medicineBenefit == null)
            {
                return null;
            }
            else
            {
                return medicineBenefit;
            }
        }

        public bool Update(MedicineBenefit m)
        {
            MedicineBenefit oldEntitiy = Get(m.Id);
            pharmacyDbContext.Entry(oldEntitiy).CurrentValues.SetValues(m);
            pharmacyDbContext.SaveChanges();
            return true;
        }
    }
}
