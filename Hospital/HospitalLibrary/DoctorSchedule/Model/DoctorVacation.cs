using HospitalLibrary.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;

namespace HospitalLibrary.DoctorSchedule.Model
{
    public class DoctorVacation : EntityDb
    {
        public virtual TimeInterval DateSpecification { get; set; }
   
        public string Description { get; set; }

        public string DoctorId { get; set; }

        public int DoctorsScheduleId { get; set; }

        public DoctorVacation()
        {
        }
        public DoctorVacation(TimeInterval dateSpecification, string description)
        {
            DateSpecification = dateSpecification;
            Description = description;
        }

        public DoctorVacation(int id, TimeInterval dateSpecification, string description)
        {
            Id = id;
            DateSpecification = dateSpecification;
            Description = description;
        }

    }
}
