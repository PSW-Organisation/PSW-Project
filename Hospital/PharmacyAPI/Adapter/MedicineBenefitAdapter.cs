﻿using PharmacyAPI.DTO;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Adapter
{
    public class MedicineBenefitAdapter
    {
        public static MedicineBenefit MedicineBenefitDtoToMedicineBenefit(MedicineBenefitDto medicineBenefitDto)
        {
            MedicineBenefit medicineBenefit = new MedicineBenefit();
            medicineBenefit.Id = medicineBenefitDto.MedicineBenefitId;
            medicineBenefit.MedicineBenefitTitle = medicineBenefitDto.MedicineBenefitTitle;
            medicineBenefit.MedicineBenefitContent = medicineBenefitDto.MedicineBenefitContent;
            medicineBenefit.MedicineBenefitDueDate = medicineBenefitDto.MedicineBenefitDueDate;
            medicineBenefit.MedicineId = medicineBenefitDto.MedicineId;
            return medicineBenefit;
        }
        public static MedicineBenefitDto MedicineBenefitToMedicineBenefitDto(MedicineBenefit medicineBenefit)
        {
            MedicineBenefitDto medicineBenefitDto = new MedicineBenefitDto();
            medicineBenefitDto.MedicineBenefitId = medicineBenefit.Id;
            medicineBenefitDto.MedicineBenefitTitle = medicineBenefit.MedicineBenefitTitle;
            medicineBenefitDto.MedicineBenefitContent = medicineBenefit.MedicineBenefitContent;
            medicineBenefitDto.MedicineBenefitDueDate = medicineBenefit.MedicineBenefitDueDate;
            medicineBenefitDto.MedicineId = medicineBenefit.MedicineId;
            return medicineBenefitDto;
        }
    }
}
