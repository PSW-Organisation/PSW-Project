using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Repository.RepoInterfaces;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Service.ServiceImpl
{
    public class ResponseToComplaintService : IResponseToComplaintService
    {

        private ResponseToComplaintRepository responseRepository;

        public ResponseToComplaintService(ResponseToComplaintRepository responseRepository)
        {
            this.responseRepository = responseRepository;
        }
        public void Delete(ResponseToComplaint response)
        {
            this.responseRepository.Delete(response);
        }

        public List<ResponseToComplaint> GetAll()
        {
            return this.responseRepository.GetAll();
        }

        public ResponseToComplaint Get(int id)
        {
            return this.responseRepository.Get(id);
        }

        public void Save(ResponseToComplaint response)
        {
            response.Id = this.responseRepository.GenerateId();
            this.responseRepository.Save(response);
        }

    }
}
