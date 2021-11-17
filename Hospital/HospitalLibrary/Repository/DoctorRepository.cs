using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository
{
	public interface DoctorRepository : GenericRepository<Doctor>
	{
        //public void ChangeDoctorRoom(Room roomForTransfer, Room oldRoom);
        public Doctor GetDoctorByName(string fullName);
        public List<Doctor> GetDoctors(Specialization specialization);
        public void UseOffDays(Doctor doctor, int days);
    }
}
