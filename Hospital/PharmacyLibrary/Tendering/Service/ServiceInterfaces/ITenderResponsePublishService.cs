using PharmacyLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Service
{
    public interface ITenderResponsePublishService
    {
        public bool initConnection(string connectionName);
        public bool AnnounceResponse(TenderResponse tender);
    }
}
