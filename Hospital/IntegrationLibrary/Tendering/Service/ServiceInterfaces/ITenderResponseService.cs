using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Service.ServiceInterfaces
{
    public interface ITenderResponseService
    {
        public List<TenderResponse> Get();

        public TenderResponse Get(int id);

        public Boolean Add(TenderResponse tenderResponse);

        public Boolean Delete(int id);

        public Boolean Update(TenderResponse tenderResponse);
    }
}
