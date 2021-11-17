using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class DoctorController
	{
		private IDoctorService doctorService;

		public DoctorController(IDoctorService doctorService)
		{
            this.doctorService = doctorService;
		}

        public DoctorController()
        {
        }

        public Doctor GetDoctorById(int id)
		{
			return doctorService.GetDoctorById(id);
		}

        public List<Doctor> FindAvailableDoctors(Specialization specialization)
        {
            return doctorService.FindAvailableDoctors(specialization);
        }

        public List<Doctor> GetDoctors(Specialization specialization)
        {
            return doctorService.GetDoctors(specialization);
        }

        public void ChangeDoctorRoom(Room roomForTranser, Room oldRoom)
        {
             doctorService.ChangeDoctorRoom(roomForTranser, oldRoom);
        }
        public List<Doctor> GetAllDoctors()
        {
            return doctorService.GetAllDoctors();
        }

        public Doctor GetDoctorByName(string fullName)
        {
            return doctorService.GetDoctorByName(fullName);
        }

        public List<Doctor> FindAvailableDoctors(DateTime date)
        {
            return doctorService.FindAvailableDoctors(date);
        }
    }
}
