using IntegrationLibrary.Repository;
using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Repository.RepoInterfaces
{
    public interface TenderRepository : GenericRepository<Tender>
    {

        List<Tender> GetTenders();
    }
}
