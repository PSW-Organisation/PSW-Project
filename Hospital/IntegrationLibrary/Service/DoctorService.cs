using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
	public class DoctorService
	{
		private DoctorRepository doctorRepository;

		public DoctorService()
		{
			doctorRepository = new DoctorXMLRepository();
        }

		public Doctor GetDoctorById(String id)
		{
			return doctorRepository.Get(id);
		}

        public void ChangeDoctorRoom(Room roomForTransfer, Room oldRoom)
        {
            doctorRepository.ChangeDoctorRoom(roomForTransfer, oldRoom);
        }
        public List<Doctor> FindAvailableDoctors(Specialization specialization)
        {
            WorkdayService workdayService = new WorkdayService();
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
            WorkdayService workdayService = new WorkdayService();
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
