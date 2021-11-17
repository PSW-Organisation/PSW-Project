using AutoMapper;
using ehealthcare.Model;
using HospitalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;

namespace HospitalAPI.Mapper
{
    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<RoomGraphic, RoomGraphicDTO>();

            CreateMap<Room, RoomDTO>();

            CreateMap<ExteriorGraphic, ExteriorGraphicDTO>();

            CreateMap<PatientFeedback, PatientFeedbackDTO>();
            CreateMap<PatientFeedbackDTO, PatientFeedback>();

            CreateMap<FloorGraphic, FloorGraphicDTO>();
            CreateMap<RoomEquipment, RoomEquipmentDTO>();

            CreateMap<PatientDto, Patient>().ConstructUsing(x => new Patient(x.Username)).ReverseMap();
                /*.ForMember(dest => dest.Medical,
                opt => opt.Ignore()).ForMember(dest => dest.MedicalPermits, opt => opt.Ignore()
                */
                /*.MapFrom(x => new MedicalRecord()
                {
                    PersonalId = x.PersonalId,
                    BloodType = x.BloodType,
                    Height = x.Height,
                    Weight = x.Weight,
                    Profession = x.Profession,
                    Doctor = null,
                    DoctorId = x.DoctorId,
                    Allergens = x.Allergens
                }));*/
               
            
        }
    }
}
