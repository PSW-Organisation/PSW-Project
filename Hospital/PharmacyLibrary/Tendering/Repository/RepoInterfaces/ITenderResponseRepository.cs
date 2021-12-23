using PharmacyLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Repository.RepoInterfaces
{
    public interface ITenderResponseRepository
    {

        public List<TenderResponse> GetAll();

        public TenderResponse Get(int id);

        public bool Add(TenderResponse tender);

        public bool Delete(int id);

        public bool Update(TenderResponse tender);
    }
}
