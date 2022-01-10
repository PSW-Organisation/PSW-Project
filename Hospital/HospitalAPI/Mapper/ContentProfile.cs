using AutoMapper;
using ehealthcare.Model;
using HospitalAPI.DTO;
using HospitalLibrary.DoctorSchedule.Model;
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

            CreateMap<FloorGraphic, FloorGraphicDTO>();

            CreateMap<RoomGraphic, RoomGraphicDTO>()
                .ForMember(
                    dest => dest.X,
                    act => act.MapFrom(src => src.Position.X)
                )
                .ForMember(
                    dest => dest.Y,
                    act => act.MapFrom(src => src.Position.Y)
                )
                .ForMember(
                    dest => dest.Width,
                    act => act.MapFrom(src => src.Dimension.Width)
                )
                .ForMember(
                    dest => dest.Height,
                    act => act.MapFrom(src => src.Dimension.Height)
                ).ReverseMap();


            CreateMap<ExteriorGraphic, ExteriorGraphicDTO>()
                .ForMember(
                    dest => dest.X,
                    act => act.MapFrom(src => src.Position.X)
                )
                .ForMember(
                    dest => dest.Y,
                    act => act.MapFrom(src => src.Position.Y)
                )
                .ForMember(
                    dest => dest.Width,
                    act => act.MapFrom(src => src.Dimension.Width)
                )
                .ForMember(
                    dest => dest.Height,
                    act => act.MapFrom(src => src.Dimension.Height)
                ).ReverseMap();
                
            CreateMap<PatientFeedback, PatientFeedbackDTO>();
            CreateMap<PatientFeedbackDTO, PatientFeedback>();

            CreateMap<RoomEquipment, RoomEquipmentDTO>();

            CreateMap<PatientDto, Patient>().ConstructUsing(x => new Patient(x.Username)).ReverseMap();
            CreateMap<SurveyQuestionDto, Survey>();

            CreateMap<ParamsOfRelocationEquipmentDTO, ParamsOfRelocationEquipment>();
            CreateMap<TermOfRelocationEquipment, ParamsOfRelocationEquipmentDTO>();

            //CreateMap<Room, RoomMinimalInfoDTO>().ConstructUsing(r => new RoomMinimalInfoDTO() { Id=r.Id, Name=r.Name });
            CreateMap<Room, RoomMinimalInfoDTO>();

            CreateMap<ParamsOfRenovation, ParamsOfRenovationDTO>();
            CreateMap<ParamsOfRenovationDTO, ParamsOfRenovation>();


            CreateMap<MedicineDTO, Medicine>();
            CreateMap<Medicine, MedicineDTO>();

            CreateMap<Visit, VisitDto>();
            CreateMap<VisitDto, Visit>();

            CreateMap<TermOfRenovation, ScheduleTermDTO>()
        .ForMember(dest =>
            dest.TermState,
            opt => opt.MapFrom(src => src.StateOfRenovation));
            CreateMap<ScheduleTermDTO, TermOfRenovation>()
        .ForMember(dest =>
            dest.StateOfRenovation,
            opt => opt.MapFrom(src => src.TermState));

            CreateMap<TermOfRelocationEquipment, ScheduleTermDTO>()
        .ForMember(dest =>
            dest.TermState,
            opt => opt.MapFrom(src => src.RelocationState));
            CreateMap<ScheduleTermDTO, TermOfRelocationEquipment>()
        .ForMember(dest =>
            dest.RelocationState,
            opt => opt.MapFrom(src => src.TermState));

            CreateMap<Visit, ScheduleTermDTO>()
                 .ForMember(d => d.TermState,
            m => m.MapFrom(d => d.Status.IsCanceled ? StateOfTerm.CANCELED : IsFinished(d)))
          .ForMember(d => d.DurationInMinutes,
           m => m.MapFrom(s => s.Interval.EndTime.Subtract(s.Interval.StartTime).TotalMinutes));


            CreateMap<Doctor, DoctorDTO>().ForMember(dest => dest.Specialization,
            opt => opt.MapFrom(src => src.Specialization.ToString()));

            CreateMap<DoctorVacation, DoctorVacationDTO>();
            CreateMap<DoctorVacationDTO, DoctorVacation>();

            CreateMap<OnCallShift, OnCallShiftDTO>();
            CreateMap<OnCallShiftDTO, OnCallShift>();
            
            CreateMap<Shift, ShiftDTO>()
                .ForMember(s => s.StartTime, m => m.MapFrom(s => s.TimeInterval.StartTime))
                .ForMember(s => s.EndTime, m => m.MapFrom(s => s.TimeInterval.EndTime))
                .ReverseMap();

            CreateMap<TermOfRelocationEquipment, ParamsOfRelocationEquipmentDTO>()
                .ForMember(
                    dest => dest.StartTime,
                    act => act.MapFrom(src => src.TimeInterval.StartTime)
                )
                .ForMember(
                    dest => dest.EndTime,
                    act => act.MapFrom(src => src.TimeInterval.EndTime)
                ).ReverseMap();

            CreateMap<TermOfRenovation, TermOfRenovationDTO>()
                .ForMember(
                    dest => dest.StartTime,
                    act => act.MapFrom(src => src.TimeInterval.StartTime)
                )
                .ForMember(
                    dest => dest.EndTime,
                    act => act.MapFrom(src => src.TimeInterval.EndTime)
                ).ReverseMap();

            CreateMap<TermOfRenovation, ScheduleTermDTO>()
                .ForMember(dest =>
                    dest.TermState,
                    opt => opt.MapFrom(src => src.StateOfRenovation))
                .ForMember(
                    dest => dest.StartTime,
                    act => act.MapFrom(src => src.TimeInterval.StartTime)
                )
                .ForMember(
                    dest => dest.EndTime,
                    act => act.MapFrom(src => src.TimeInterval.EndTime)
                );

            CreateMap<TermOfRelocationEquipment, ScheduleTermDTO>()
                .ForMember(
                dest => dest.TermState,
                opt => opt.MapFrom(src => src.RelocationState))
            .ForMember(
                dest => dest.StartTime,
                act => act.MapFrom(src => src.TimeInterval.StartTime)
            ).ForMember(
                dest => dest.EndTime,
                act => act.MapFrom(src => src.TimeInterval.EndTime)
            );


        }

        private static StateOfTerm IsFinished(Visit d)
        {
            return d.Interval.EndTime < System.DateTime.Now ? StateOfTerm.SUCCESSFULLY : StateOfTerm.PENDING;
        }
    }
}
