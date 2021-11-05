﻿using IntegrationAPI.DTO;
using IntegrationLibrary.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class ComplaintAdapter
    {
        public static Complaint ComplaintDtoToComplaint(ComplaintDTO dto)
        {
            Complaint complaint = new Complaint();
            complaint.ComplaintId = dto.ComplaintId;
            complaint.Date = dto.Date;
            complaint.Title = dto.Title;
            complaint.Content = dto.Content;
            complaint.PharmacyId = dto.PharmacyId;
            return complaint;
        }

        public static ComplaintDTO ComplaintToComplaintDto(Complaint complaint)
        {
            ComplaintDTO dto = new ComplaintDTO();
            dto.ComplaintId = complaint.ComplaintId;
      
            dto.Date = complaint.Date;
            dto.Title = complaint.Title;
            dto.Content = complaint.Content;
            dto.PharmacyId = complaint.PharmacyId;
            return dto;
        }
    }
}