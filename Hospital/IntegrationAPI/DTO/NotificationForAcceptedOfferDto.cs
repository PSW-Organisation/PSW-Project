using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class NotificationForAcceptedOfferDto
    {

        public String content { get; set; }
        public Pharmacy pharmacy { get; set; }
        public Tender tender { get; set; }

       public NotificationForAcceptedOfferDto(String s, Pharmacy p, Tender t)
        {
            this.content = s;
            this.pharmacy = p;
            this.tender = t;

        }

    }
}
