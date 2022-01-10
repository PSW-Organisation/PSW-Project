using HospitalLibrary.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;

namespace HospitalLibrary.DoctorSchedule.Model
{
    public class Shift : EntityDb
    {
        public string Name { get; set; }
        public virtual TimeInterval TimeInterval { get; set; }
        public int ShiftOrder { get; set; }
    }
}
