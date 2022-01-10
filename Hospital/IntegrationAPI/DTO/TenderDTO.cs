using IntegrationLibrary.Parnership.Model;
using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class TenderDTO
    {
        public int Id { get; set; }
        public DateTime TenderOpenDate { get; set; }

        public DateTime? TenderCloseDate { get; set; }

        public bool Open { get; set; }

        public string ApiKeyPharmacy { get; set; }

        public List<TenderItem> TenderItems { get; set; }

        public List<TenderResponseDTO> TenderResponses { get; set; }
    }
}
