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
        /*public static Tender ComplaintDtoToComplaint(TenderDTO dto)
        {
            Tender complaint = new Complaint();
            complaint.Id = dto.ComplaintId;
            complaint.Date = dto.Date;
            complaint.Title = dto.Title;
            complaint.Content = dto.Content;
            complaint.PharmacyId = dto.PharmacyId;
            return complaint;
        }

        public static ComplaintDTO ComplaintToComplaintDto(Complaint complaint)
        {
            ComplaintDTO dto = new ComplaintDTO();
            dto.ComplaintId = complaint.Id;

            dto.Date = complaint.Date;
            dto.Title = complaint.Title;
            dto.Content = complaint.Content;
            dto.PharmacyId = complaint.PharmacyId;
            return dto;
        }*/
        public static TenderDTO TenderToTenderDto(Tender tender)
        {
            TenderDTO dto = new TenderDTO();
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
            tender.TenderOpenDate = dto.TenderOpenDate;
            tender.TenderCloseDate = dto.TenderCloseDate;
            tender.Open = dto.Open;
            tender.ApiKeyPharmacy = dto.ApiKeyPharmacy;
            tender.TenderItems = dto.TenderItems;
            return tender;
        }
    }
}
