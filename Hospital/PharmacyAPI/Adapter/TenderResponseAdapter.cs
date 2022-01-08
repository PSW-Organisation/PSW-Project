using PharmacyAPI.DTO;
using PharmacyLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Adapter
{
    public class TenderResponseAdapter
    {
        public static TenderResponse TenderResponseDtoToTenderResponse(TenderResponseDto dto)
        {
            TenderResponse tenderResponse = new TenderResponse();
            tenderResponse.TenderItems = dto.tenderItems;
            tenderResponse.TenderId = dto.tenderId;
            tenderResponse.PharmacyApiKey = dto.tender.ApiKeyPharmacy;
            double price = 0;
            for(int i = 0; i < dto.tenderItems.Count; i++)
            {
                price += dto.tenderItems[i].TenderItemPrice;
            }
            tenderResponse.TotalPrice = price;
            tenderResponse.ResponseReceivedTime = DateTime.Now;
            return tenderResponse;
        }
    }
}
