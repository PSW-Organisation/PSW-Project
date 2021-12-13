using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
	public class DoctorService : IDoctorService
    {
		private DoctorRepository doctorRepository;
        private IWorkdayService workdayService;

        public DoctorService(DoctorRepository doctorRepository, IWorkdayService workdayService)
		{
            this.doctorRepository = doctorRepository;
            this.workdayService = workdayService;
        }

        public DoctorService()
        {
        }

        public Doctor GetDoctorById(int id)
		{
			return doctorRepository.Get(id);
		}

        public void ChangeDoctorRoom(Room roomForTransfer, Room oldRoom)
        {
            doctorRepository.ChangeDoctorRoom(roomForTransfer, oldRoom);
        }
        public List<Doctor> FindAvailableDoctors(Specialization specialization)
        {
            List<Doctor> availableDoctors = new List<Doctor>();
            List<Doctor> specializedDoctors = GetDoctors(specialization);
            foreach (Doctor doctor in specializedDoctors)
            {
                if (workdayService.IsWorkday(doctor.Id, DateTime.Today))
                {
                    availableDoctors.Add(doctor);
                }
            }
            return availableDoctors;
        }

        public List<Doctor> GetDoctors(Specialization specialization)
        {
            return doctorRepository.GetDoctors(specialization);
        }

	    public List<Doctor> GetAllDoctors()
	    {
	        return doctorRepository.GetAll();
	    }

        public Doctor GetDoctorByName(string fullName)
        {
            return doctorRepository.GetDoctorByName(fullName);
        }

        public List<Doctor> FindAvailableDoctors(DateTime date)
        {
            List<Doctor> allDoctors = doctorRepository.GetAll();
            List<Doctor> availableDoctors = new List<Doctor>();
            foreach (Doctor doctor in allDoctors)
            {
                if(workdayService.IsWorkday(doctor.Id, date))
                {
                    availableDoctors.Add(doctor);
                }
            }

            return availableDoctors;
        }
	}
}
