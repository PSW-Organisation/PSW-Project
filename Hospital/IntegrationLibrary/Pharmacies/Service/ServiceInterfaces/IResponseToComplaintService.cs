using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Service.ServiceInterfaces
{
    public interface IResponseToComplaintService
    {
        public List<ResponseToComplaint> GetAll();

        public ResponseToComplaint Get(int id);

        public void Save(ResponseToComplaint response);
        public void Delete(ResponseToComplaint response);
    }
}
