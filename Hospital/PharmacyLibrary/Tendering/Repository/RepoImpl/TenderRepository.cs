using PharmacyAPI;
using PharmacyLibrary.Tendering.Model;
using PharmacyLibrary.Tendering.Repository.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyLibrary.Tendering.Repository.RepoImpl
{
    public class TenderRepository : ITenderRepository
    {
        private readonly PharmacyDbContext pharmacyDbContext;
        public TenderRepository(PharmacyDbContext pharmacyDbContext)
        {
            this.pharmacyDbContext = pharmacyDbContext;
        }
        public bool Add(Tender tender)
        {
            int itemId = pharmacyDbContext.TenderItems.ToList().Count > 0 ? pharmacyDbContext.TenderItems.Max(item => item.Id) + 1 : 1;
            for (int i = 0; i < tender.TenderItems.Count; i++) {
                tender.TenderItems[i].Id = itemId + i;
            }
            tender.Id = pharmacyDbContext.Tenders.ToList().Count > 0 ? pharmacyDbContext.Tenders.Max(tender => tender.Id) + 1 : 1;
            pharmacyDbContext.Tenders.Add(tender);
            pharmacyDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tender> GetAll()
        {
            List<Tender> result = new List<Tender>();
            List<TenderItem> items = new List<TenderItem>();
            pharmacyDbContext.Tenders.ToList().ForEach(tender => result.Add(tender));
            pharmacyDbContext.TenderItems.ToList().ForEach(item => items.Add(item));
            return result;
        }

        public Tender Get(int id)
        {
            Tender tender = pharmacyDbContext.Tenders.FirstOrDefault(tender => tender.Id == id);
            if (tender == null)
            {
                return null;
            }
            else
            {
                return tender;
            }
        }

        public bool Update(Tender tender)
        {
            Tender tenderForEdit = this.Get(tender.Id);
            if (tenderForEdit == null)
            {
                return false;
            }
            else
            {
                pharmacyDbContext.Entry(tenderForEdit).CurrentValues.SetValues(tender);
                pharmacyDbContext.SaveChanges();
                return true;
            }
        }
    }
}
