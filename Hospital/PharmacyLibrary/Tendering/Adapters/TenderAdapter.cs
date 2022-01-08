using PharmacyLibrary.Tendering.DTO;
using PharmacyLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Adapters
{
    public class TenderAdapter
    {
        public static Tender TenderDtoToTender(TenderDTO dto)
        {
            Tender tender = new Tender();
            tender.Id = dto.Id;
            tender.TenderOpenDate = dto.TenderOpenDate;
            tender.TenderCloseDate = dto.TenderCloseDate;
            tender.Open = dto.Open;
            tender.ApiKeyPharmacy = dto.ApiKeyPharmacy;
            tender.TenderItems = dto.TenderItems;
            return tender;
        }
    }
}
