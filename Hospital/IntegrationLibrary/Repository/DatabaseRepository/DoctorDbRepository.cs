using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class DoctorDbRepository : GenericDatabaseRepository<Doctor>, DoctorRepository
    {
        public DoctorDbRepository(IntegrationDbContext  dbContext) : base(dbContext) { }

        public void ChangeDoctorRoom(Room roomForTransfer, Room oldRoom)
        {
            foreach (Doctor doctor in base.GetAll())
            {
                if (doctor.DoctorRoomId.Equals(oldRoom.Id))
                {
                    doctor.DoctorRoom = roomForTransfer;

                    doctor.DoctorRoomId = roomForTransfer.Id;

                }
            }
            SaveAll();
        }

        public Doctor GetDoctorByName(string fullName)
        {
            foreach (Doctor doctor in base.GetAll())
            {
                if (doctor.FullName == fullName)
                {
                    return doctor;
                }
            }
            return null;
        }

        public List<Doctor> GetDoctors(Specialization specialization)
        {
            List<Doctor> specializedDoctors = new List<Doctor>();
            foreach (Doctor doctor in base.GetAll())
            {
                if (doctor.Specialization == specialization)
                {
                    specializedDoctors.Add(doctor);
                }
            }
            return specializedDoctors;
        }

        public void UseOffDays(Doctor doctor, int days)
        {
            foreach (Doctor doctorFromStorage in base.GetAll())
            {
                if (doctorFromStorage.Id == doctor.Id)
                {
                    doctorFromStorage.UsedOffDays = doctorFromStorage.UsedOffDays + days;
                    doctor.UsedOffDays = doctor.UsedOffDays + days;
                    break;
                }
            }
            base.SaveAll();
        }

    }
}
