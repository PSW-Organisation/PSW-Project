using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Service.ServiceInterfaces
{
    public interface ITenderPublishingService
    {
        public bool initConnection(string connectionName, string exchangeName);
        public bool AnnounceTender(Tender tender, string exchangeName);
    }
}
