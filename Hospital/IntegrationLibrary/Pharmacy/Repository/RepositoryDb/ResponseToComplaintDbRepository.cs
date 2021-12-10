using IntegrationLibrary.Model;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class ResponseToComplaintDbRepository : GenericDatabaseRepository<ResponseToComplaint>, ResponseToComplaintRepository
    {
        public ResponseToComplaintDbRepository(IntegrationDbContext dbContex) : base(dbContex) { }

      
    }
}
