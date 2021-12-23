using PharmacyLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.DTO
{
    public class TenderResponseDto
    {
        public List<TenderItem> tenderItems { get; set; }
        public int tenderId { get; set; }
        public Tender tender { get; set; }
    }
}
