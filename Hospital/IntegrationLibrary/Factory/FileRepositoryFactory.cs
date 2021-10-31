using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezba.Repository;

namespace vezba.Factory
{
    class FileRepositoryFactory : IRepositoryFactory
    {
        public IAnnouncementRepository CreateAnnouncementRepository()
        {
            return new AnnouncementFileRepository();
        }

        public IAppointmentRepository CreateAppointmentRepository()
        {
            return new AppointmentFileRepository();
        }

        public IDeclinedMedicineRepository CreateDeclinedMedicineRepository()
        {
            return new DeclinedMedicineFileRepository();
        }

        public IDoctorEvaluationRepository CreateDoctorEvaluationRepository()
        {
            return new DoctorEvaluationFileRepository();
        }

        public IDoctorRepository CreateDoctorRepository()
        {
            return new DoctorFileRepository();
        }

        public IEquipmentRepository CreateEquipmentRepository()
        {
            return new EquipmentFileRepository();
        }

        public IEventsLogRepository CreateEventsLogRepository()
        {
            return new EventsLogFileRepository();
        }

        public IHospitalEvaluationRepository CreateHospitalEvaluationRepository()
        {
            return new HospitalEvaluationFileRepository();
        }

        public IMedicineRepository CreateMedicineRepository()
        {
            return new MedicineFileRepository();
        }

        public IPatientRepository CreatePatientRepository()
        {
            return new PatientFileRepository();
        }

        public IRoomInventoryRepository CreateRoomInventoryRepository()
        {
            return new RoomInventoryFileRepository();
        }

        public IRoomRepository CreateRoomRepository()
        {
            return new RoomFileRepository();
        }

        public IUserFeedbackRepository CreateUserFeebackRepository()
        {
            return new UserFeedbackFileRepository();
        }
    }
}
