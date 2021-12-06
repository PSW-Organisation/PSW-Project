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
using HospitalLibrary.Model;
using HospitalLibrary.RoomsAndEquipment.Model;

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
            CreateMap<SurveyQuestionDto, Survey>();

            CreateMap<ParamsOfRelocationEquipmentDTO, ParamsOfRelocationEquipment>();
            CreateMap<TermOfRelocationEquipment, ParamsOfRelocationEquipmentDTO>();

            //CreateMap<Room, RoomMinimalInfoDTO>().ConstructUsing(r => new RoomMinimalInfoDTO() { Id=r.Id, Name=r.Name });
            CreateMap<Room, RoomMinimalInfoDTO>();
        }
    }
}
