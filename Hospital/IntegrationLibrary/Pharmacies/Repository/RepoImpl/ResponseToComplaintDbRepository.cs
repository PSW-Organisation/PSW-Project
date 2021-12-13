using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Repository.RepoInterfaces;
using IntegrationLibrary.Repository.DatabaseRepository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Repository.RepoImpl
{
    public class ResponseToComplaintDbRepository : GenericDatabaseRepository<ResponseToComplaint>, ResponseToComplaintRepository
    {
        public ResponseToComplaintDbRepository(IntegrationDbContext dbContex) : base(dbContex) { }

      
    }
}
