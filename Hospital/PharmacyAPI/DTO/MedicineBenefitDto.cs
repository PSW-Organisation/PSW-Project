﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.DTO
{
    public class MedicineBenefitDto
    {
        public int MedicineBenefitId { get; set; }
        public string MedicineBenefitTitle { get; set; }
        public string MedicineBenefitContent { get; set; }
        public DateTime MedicineBenefitDueDate { get; set; }
        public int MedicineId { get; set; }



    }
}