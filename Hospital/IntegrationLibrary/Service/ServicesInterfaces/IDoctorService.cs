using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IDoctorService
    {
        public Doctor GetDoctorById(int id);
        public void ChangeDoctorRoom(Room roomForTransfer, Room oldRoom);
        public List<Doctor> FindAvailableDoctors(Specialization specialization);
        public List<Doctor> GetDoctors(Specialization specialization);
        public List<Doctor> GetAllDoctors();
        public Doctor GetDoctorByName(string fullName);
        public List<Doctor> FindAvailableDoctors(DateTime date);
    }
}
