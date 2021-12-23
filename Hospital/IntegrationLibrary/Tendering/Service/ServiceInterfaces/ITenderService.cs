using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Service.ServiceInterfaces
{
    public interface ITenderService
    {
        public List<Tender> Get();

        public Tender Get(int id);

        public Boolean Add(Tender tender);

        public Boolean Delete(int id);

        public Boolean Update(Tender t);
    }
}
