using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class ResponseToComplaintDTO
    {
        public int ResponseId { get; set; }
        public DateTime Date { get; set; }
        public String Content { get; set; }
        public int ComplaintId { get; set; }
    }
}
