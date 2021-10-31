using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezba.Repository;

namespace vezba.Factory
{
    interface IRepositoryFactory
    {
        IAnnouncementRepository CreateAnnouncementRepository();
        IAppointmentRepository CreateAppointmentRepository(); 
        IDeclinedMedicineRepository CreateDeclinedMedicineRepository();
        IDoctorEvaluationRepository CreateDoctorEvaluationRepository();
        IDoctorRepository CreateDoctorRepository();
        IEquipmentRepository CreateEquipmentRepository();
        IEventsLogRepository CreateEventsLogRepository();
        IHospitalEvaluationRepository CreateHospitalEvaluationRepository();
        IMedicineRepository CreateMedicineRepository();
        IPatientRepository CreatePatientRepository();
        IRoomInventoryRepository CreateRoomInventoryRepository();
        IRoomRepository CreateRoomRepository();
        IUserFeedbackRepository CreateUserFeebackRepository();
    }
}
