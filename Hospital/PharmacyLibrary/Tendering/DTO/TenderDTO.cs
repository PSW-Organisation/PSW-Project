using PharmacyLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.DTO
{
    public class TenderDTO
    {
        public int Id { get; set; }
        public DateTime TenderOpenDate { get; set; }

        public DateTime TenderCloseDate { get; set; }

        public bool Open { get; set; }

        public string ApiKeyPharmacy { get; set; }

        public List<TenderItem> TenderItems { get; set; }
    }
}
