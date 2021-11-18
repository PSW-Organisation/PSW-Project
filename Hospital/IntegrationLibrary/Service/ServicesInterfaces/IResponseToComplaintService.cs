using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IResponseToComplaintService
    {
        public List<ResponseToComplaint> GetAll();

        public ResponseToComplaint Get(int id);

        public void Save(ResponseToComplaint response);
        public void Delete(ResponseToComplaint response);
    }
}
