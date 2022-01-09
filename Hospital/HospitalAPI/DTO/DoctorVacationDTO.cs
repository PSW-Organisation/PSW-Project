using ehealthcare.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class DoctorVacationDTO
    {
        public int Id { get; set;}

        public TimeInterval DateSpecification { get; set; }

        public string Description { get; set; }

        public string DoctorId { get; set; }
    }
}
