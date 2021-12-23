using PharmacyLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Repository.RepoInterfaces
{
    public interface ITenderRepository
    {
        public List<Tender> GetAll();

        public Tender Get(int id);

        public bool Add(Tender tender);

        public bool Delete(int id);

        public bool Update(Tender tender);
    }
}
