using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class TenderResponseDTO
    {
        public int Id { get; set; }
        public PharmacyDto Pharmacy { get; set; }
        public List<TenderItem> TenderItems { get; set; }
        public DateTime ResponseReceivedTime { get; set; }
        public double TotalPrice { get; set; }
        public bool IsWinner { get; set; }
        public int TenderId { get; set; }
    }
}
