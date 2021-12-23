using IntegrationAPI.DTO;
using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class TenderAdapter
    {
        public static Tender TenderDtoToTender(TenderDTO dto)
        {
            Tender tender = new Tender();
            tender.Id = dto.Id;
            tender.MedicineTransactions = dto.MedicineTransactions;
            tender.TenderOpenDate = dto.TenderOpenDate;
            tender.TenderCloseDate = dto.TenderCloseDate;
            tender.Open = dto.Open;
            tender.TenderResponses = dto.TenderResponses;
            return tender;
        }

        public static TenderDTO TenderToTenderDto(Tender tender)
        {
            TenderDTO dto = new TenderDTO();
            dto.Id = tender.Id;
            dto.MedicineTransactions = tender.MedicineTransactions;
            dto.TenderOpenDate = tender.TenderOpenDate;
            dto.TenderCloseDate = tender.TenderCloseDate;
            dto.Open = tender.Open;
            dto.TenderResponses = tender.TenderResponses;
            return dto;
        }
    }
}
