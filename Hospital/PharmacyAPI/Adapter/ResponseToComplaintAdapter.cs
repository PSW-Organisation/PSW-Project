using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Adapters
{
    public class ResponseToComplaintAdapter
    {

        public static ResponseToComplaint ResponseDtoToResponse(ResponseToComplaintDTO dto)
        {
            ResponseToComplaint response = new ResponseToComplaint();
            response.ResponseToComplaintId = dto.ResponseId;
            response.Date = dto.Date;
            response.Content = dto.Content;
            return response;

        }
        public static ResponseToComplaintDTO ResponseToResponseDto(ResponseToComplaint response)
        {
            ResponseToComplaintDTO dto = new ResponseToComplaintDTO();
            dto.ResponseId = response.ResponseToComplaintId;
            dto.Date = response.Date;
            dto.Content = response.Content;
            return dto;

        }
    }
}
