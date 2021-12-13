using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class ResponseToComplaintAdapter
    {

        public static ResponseToComplaint ResponseDtoToResponse(ResponseToComplaintDTO dto)
        {
            ResponseToComplaint response = new ResponseToComplaint();
            response.Id = dto.ResponseId;
            response.Date = dto.Date;
            response.Content = dto.Content;
            response.ComplaintId = dto.ComplaintId;
            return response;

        }
        public static ResponseToComplaintDTO ResponseToResponseDto(ResponseToComplaint response)
        {
            ResponseToComplaintDTO dto = new ResponseToComplaintDTO();
            dto.ResponseId = response.Id;
            dto.Date = response.Date;
            dto.Content = response.Content;
            dto.ComplaintId = response.Id;
            return dto;

        }
    }
}
