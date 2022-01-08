using IntegrationAPI.DTO;
using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class TenderResponseAdapter
    {
        public static TenderResponseDTO TenderResponseToTenderResponseDTO(TenderResponse tenderResponse)
        {
            TenderResponseDTO dto = new TenderResponseDTO();
            dto.Pharmacy = PharmacyAdapter.PharmacyToPharmacyDto(tenderResponse.Pharmacy);
            dto.TenderItems = tenderResponse.TenderItems;
            dto.ResponseReceivedTime = tenderResponse.ResponseReceivedTime;
            dto.TotalPrice = tenderResponse.TotalPrice;
            dto.IsWinner = tenderResponse.IsWinner;
            dto.TenderId = tenderResponse.TenderId;
            return dto;
        }
    }
}
