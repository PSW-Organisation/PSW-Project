using PharmacyAPI.DTO;
using PharmacyLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Adapter
{
    public class TenderAdapter
    {
        public static TenderDTO TenderToTenderDto(Tender tender)
        {
            TenderDTO dto = new TenderDTO();
            dto.Id = tender.Id;
            dto.TenderOpenDate = tender.TenderOpenDate;
            dto.TenderCloseDate = tender.TenderCloseDate;
            dto.Open = tender.Open;
            dto.ApiKeyPharmacy = tender.ApiKeyPharmacy;
            dto.TenderItems = tender.TenderItems;
            return dto;
        }

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
