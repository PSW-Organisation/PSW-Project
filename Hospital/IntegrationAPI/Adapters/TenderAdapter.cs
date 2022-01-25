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

        public static TenderDTO TenderToTenderDto(Tender tender)
        {
            TenderDTO dto = new TenderDTO();
            dto.Id = tender.Id;
            dto.TenderOpenDate = tender.TenderOpenDate;
            dto.TenderCloseDate = tender.TenderCloseDate;
            dto.Open = tender.Open;
            dto.ApiKeyPharmacy = tender.ApiKeyPharmacy;
            foreach(TenderItem item in tender.TenderItems)
            {
                dto.TenderItems.Add(item);
            }

           // dto.TenderItems = tender.TenderItems;
            List<TenderResponseDTO> tenderResponses = new List<TenderResponseDTO>();
            foreach(TenderResponse tenderResponse in tender.TenderResponses)
            {
                tenderResponses.Add(TenderResponseAdapter.TenderResponseToTenderResponseDTO(tenderResponse));
            }
            dto.TenderResponses = tenderResponses;
            return dto;
        }

        public static Tender TenderDtoToTender(TenderDTO dto)
        {
            Tender tender = new Tender();
            tender.Id = dto.Id;
            tender.TenderOpenDate = dto.TenderOpenDate;
            tender.TenderCloseDate = dto.TenderCloseDate.GetValueOrDefault(new DateTime(2200, 12,12));
            tender.Open = dto.Open;
            tender.ApiKeyPharmacy = dto.ApiKeyPharmacy;
            foreach (TenderItem item in dto.TenderItems)
            {
                tender.AddItems(item);
            }
            //tender.TenderItems = dto.TenderItems;
            
            return tender;
        }
    }
}
