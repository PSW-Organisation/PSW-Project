using AutoMapper;
using ehealthcare.Model;
using HospitalAPI.DTO;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;

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
            CreateMap<TermOfRelocationEquipment, ParamsOfRelocationEquipmentDTO>()
                .ForMember(
                    dest => dest.StartTime, 
                    act => act.MapFrom(src => src.Time.StartTime )
                )
                .ForMember(
                    dest => dest.EndTime,
                    act => act.MapFrom(src => src.Time.EndTime)
                ); 
            
            //CreateMap<Room, RoomMinimalInfoDTO>().ConstructUsing(r => new RoomMinimalInfoDTO() { Id=r.Id, Name=r.Name });
            CreateMap<Room, RoomMinimalInfoDTO>();

            CreateMap<ParamsOfRenovation, ParamsOfRenovationDTO>();
            CreateMap<ParamsOfRenovationDTO, ParamsOfRenovation>();

            CreateMap<TermOfRenovation, TermOfRenovationDTO>()
                .ForMember(
                    dest => dest.StartTime,
                    act => act.MapFrom(src => src.Time.StartTime)
                )
                .ForMember(
                    dest => dest.EndTime,
                    act => act.MapFrom(src => src.Time.EndTime)
                );
            CreateMap<TermOfRenovationDTO, TermOfRenovation>();

            CreateMap<MedicineDTO, Medicine>();
            CreateMap<Medicine, MedicineDTO>();

            CreateMap<Visit, VisitDto>();
            CreateMap<VisitDto, Visit>();

            CreateMap<TermOfRenovation, ScheduleTermDTO>()
                .ForMember(dest =>
                    dest.TermState,
                    opt => opt.MapFrom(src => src.StateOfRenovation))
                .ForMember(
                    dest => dest.StartTime,
                    act => act.MapFrom(src => src.Time.StartTime)
                )
                .ForMember(
                    dest => dest.EndTime,
                    act => act.MapFrom(src => src.Time.EndTime)
                );
            CreateMap<ScheduleTermDTO, TermOfRenovation>()
        .ForMember(dest =>
            dest.StateOfRenovation,
            opt => opt.MapFrom(src => src.TermState));

            CreateMap<TermOfRelocationEquipment, ScheduleTermDTO>()
            .ForMember(
                dest =>dest.TermState,
                opt => opt.MapFrom(src => src.RelocationState))
            .ForMember(
                dest => dest.StartTime,
                act => act.MapFrom(src => src.Time.StartTime)
            ).ForMember(
                dest => dest.EndTime,
                act => act.MapFrom(src => src.Time.EndTime)
            );

            CreateMap<ScheduleTermDTO, TermOfRelocationEquipment>()
        .ForMember(dest =>
            dest.RelocationState,
            opt => opt.MapFrom(src => src.TermState));

            CreateMap<Visit, ScheduleTermDTO>()
                 .ForMember(d => d.TermState,
            m => m.MapFrom(d => d.IsCanceled ? StateOfTerm.CANCELED : IsFinished(d)))
          .ForMember(d => d.DurationInMinutes,
           m => m.MapFrom(s => s.EndTime.Subtract(s.StartTime).TotalMinutes));

        }

        private StateOfTerm IsFinished(Visit d)
        {
            return d.EndTime < System.DateTime.Now ? StateOfTerm.SUCCESSFULLY : StateOfTerm.PENDING;
        }
    }
}
