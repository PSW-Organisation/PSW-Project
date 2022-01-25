using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.DoctorSchedule.Repository;
using HospitalLibrary.DoctorSchedule.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.RoomsAndEquipment.Service;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using Moq;
using Shouldly;
using Xunit;

namespace HospitalUnitTests.DoctorManagment
{
    public class DoctorVacationTest
    {
        [Theory]
        [MemberData(nameof(ConflictingCreateVacationData))]
        public void Create_Conflicting_Vacations(DoctorVacation doctorVacation, List<DoctorVacation> doctorVacations, DoctorsSchedule doctorsSchedule)
        {
            var stubDoctorVacationRepository = new Mock<IDoctorVacationRepository>();
            var stubDoctorScheduleRepository = new Mock<IDoctorScheduleRepository>();
            stubDoctorVacationRepository.Setup(r => r.GetDoctorVacations(It.Is<string>(doctorId => doctorId == doctorVacation.DoctorId))).Returns(doctorVacations);
            stubDoctorScheduleRepository.Setup(r => r.GetDoctorsSchedule(It.Is<string>(doctorId => doctorId == doctorsSchedule.DoctorId))).Returns(doctorsSchedule);
            DoctorVacationService doctorVacationService =
                new DoctorVacationService(stubDoctorVacationRepository.Object, stubDoctorScheduleRepository.Object);
            DoctorVacation invalidDoctorVacation = doctorVacationService.CreateDoctorVacation(doctorVacation);

            invalidDoctorVacation.ShouldBeEquivalentTo(null);
        }


        [Theory]
        [MemberData(nameof(ConflictingUpdateVacationData))]
        public void Update_Conflicting_Vacations(DoctorVacation doctorVacation, List<DoctorVacation> doctorVacations, DoctorsSchedule doctorsSchedule)
        {
            var stubDoctorVacationRepository = new Mock<IDoctorVacationRepository>();
            var stubDoctorScheduleRepository = new Mock<IDoctorScheduleRepository>();
            stubDoctorVacationRepository.Setup(r => r.GetDoctorVacations(It.Is<string>(doctorId => doctorId == doctorVacation.DoctorId))).Returns(doctorVacations);
            stubDoctorScheduleRepository.Setup(r => r.GetDoctorsSchedule(It.Is<string>(doctorId => doctorId == doctorsSchedule.DoctorId))).Returns(doctorsSchedule);
            DoctorVacationService doctorVacationService =
                new DoctorVacationService(stubDoctorVacationRepository.Object, stubDoctorScheduleRepository.Object);
            DoctorVacation invalidDoctorVacation = doctorVacationService.UpdateDoctorVacation(doctorVacation);

            invalidDoctorVacation.ShouldBeEquivalentTo(null);
        }

        #region ConflictingVacationData
        public static IEnumerable<object[]> ConflictingUpdateVacationData =>
            new List<object[]>
            {
                new object[]
                {
                    new DoctorVacation()
                    {
                        Id = 2,
                        DateSpecification = new TimeInterval(new DateTime(2022, 1, 16), new DateTime(2022, 1, 20)),
                        DoctorId = "mkisic",
                        Description = "Zimovanje"
                    },
                    new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022, 1, 15), new DateTime(2022, 1, 17)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje"
                        },
                        new DoctorVacation()
                        {
                            Id = 2,
                            DateSpecification = new TimeInterval(new DateTime(2022, 1, 12), new DateTime(2022, 1, 13)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje"
                        },
                    },
                    new DoctorsSchedule( new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022, 1, 15), new DateTime(2022, 1, 17)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje"
                        },
                        new DoctorVacation()
                        {
                            Id = 2,
                            DateSpecification = new TimeInterval(new DateTime(2022, 1, 12), new DateTime(2022, 1, 13)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje"
                        },
                    }, new List<OnCallShift>(), "mkisic")
                    {
                        Id = 1
                    },
                }
            };
       
        public static IEnumerable<object[]> ConflictingCreateVacationData =>
            new List<object[]>
            {
                new object[]
                {
                    new DoctorVacation()
                    {
                        Id = 2,
                        DateSpecification = new TimeInterval(new DateTime(2022,1,16),new DateTime(2022,1,20)),
                        DoctorId = "mkisic",
                        Description = "Zimovanje"
                    },
                    new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022,1,15),new DateTime(2022,1,17)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje"
                        },
                       
                    },
                    new DoctorsSchedule( new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022,1,15),new DateTime(2022,1,17)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje"
                        },

                    }, new List<OnCallShift>(), "mkisic")
                    {
                        Id = 1
                    },
                },
                new object[]
                {
                    new DoctorVacation()
                    {
                        Id = 2,
                        DateSpecification = new TimeInterval(new DateTime(2022,1,27),new DateTime(2022,2,2)),
                        DoctorId = "nelex",
                        Description = "Bolovanje"
                    },
                    new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022,1,30),new DateTime(2022,1,31)),
                            DoctorId = "nelex",
                            Description = "Zimovanje"
                        },

                    },
                    new DoctorsSchedule(new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022,1,30),new DateTime(2022,1,31)),
                            DoctorId = "nelex",
                            Description = "Zimovanje"
                        },

                    }, new List<OnCallShift>(), "nelex")
                    {
                        Id = 2
                    },
                }
            };
        #endregion


        [Theory]
        [MemberData(nameof(CreateVacationData))]
        public void Create_Vacation(DoctorVacation doctorVacation, List<DoctorVacation> doctorVacations, DoctorsSchedule doctorsSchedule)
        {
            var stubDoctorVacationRepository = new Mock<IDoctorVacationRepository>();
            var stubDoctorScheduleRepository = new Mock<IDoctorScheduleRepository>();
            stubDoctorVacationRepository.Setup(r => r.GetDoctorVacations(It.Is<string>(doctorId => doctorId == doctorVacation.DoctorId))).Returns(doctorVacations);
            stubDoctorScheduleRepository.Setup(r => r.GetDoctorsSchedule(It.Is<string>(doctorId => doctorId == doctorsSchedule.DoctorId))).Returns(doctorsSchedule);
            DoctorVacationService doctorVacationService =
                new DoctorVacationService(stubDoctorVacationRepository.Object, stubDoctorScheduleRepository.Object);
            DoctorVacation validDoctorVacation = doctorVacationService.CreateDoctorVacation(doctorVacation);

            validDoctorVacation.ShouldBeEquivalentTo(doctorVacation);
        }

        [Theory]
        [MemberData(nameof(UpdateVacationData))]
        public void Update_Vacation(DoctorVacation doctorVacation, List<DoctorVacation> doctorVacations, DoctorsSchedule doctorsSchedule)
        {
            var stubDoctorVacationRepository = new Mock<IDoctorVacationRepository>();
            var stubDoctorScheduleRepository = new Mock<IDoctorScheduleRepository>();
            stubDoctorVacationRepository.Setup(r => r.GetDoctorVacations(It.Is<string>(doctorId => doctorId == doctorVacation.DoctorId))).Returns(doctorVacations);
            stubDoctorScheduleRepository.Setup(r => r.GetDoctorsSchedule(It.Is<string>(doctorId => doctorId == doctorsSchedule.DoctorId))).Returns(doctorsSchedule);
            DoctorVacationService doctorVacationService =
                new DoctorVacationService(stubDoctorVacationRepository.Object, stubDoctorScheduleRepository.Object);
            DoctorVacation validDoctorVacation = doctorVacationService.UpdateDoctorVacation(doctorVacation);

            validDoctorVacation.ShouldBeEquivalentTo(doctorVacation);
        }

        #region VacationData
        public static IEnumerable<object[]> UpdateVacationData =>
            new List<object[]>
            {
                new object[]
                {
                    new DoctorVacation()
                    {
                        Id = 2,
                        DateSpecification = new TimeInterval(new DateTime(2022, 1, 9), new DateTime(2022, 1, 11)),
                        DoctorId = "mkisic",
                        Description = "Zimovanje",
                        DoctorsScheduleId = 1
                    },
                    new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022, 1, 15), new DateTime(2022, 1, 17)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje",
                            DoctorsScheduleId = 1
                        },
                        new DoctorVacation()
                        {
                            Id = 2,
                            DateSpecification = new TimeInterval(new DateTime(2022, 1, 12), new DateTime(2022, 1, 13)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje",
                            DoctorsScheduleId = 1
                        },
                    },
                    new DoctorsSchedule( new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022, 1, 15), new DateTime(2022, 1, 17)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje",
                            DoctorsScheduleId = 1
                        },
                        new DoctorVacation()
                        {
                            Id = 2,
                            DateSpecification = new TimeInterval(new DateTime(2022, 1, 12), new DateTime(2022, 1, 13)),
                            DoctorId = "mkisic",
                            Description = "Zimovanje",
                            DoctorsScheduleId = 1
                        },
                    }, new List<OnCallShift>(), "mkisic")
                    {
                        Id = 1
                    },
                }
            };
        public static IEnumerable<object[]> CreateVacationData =>
            new List<object[]>
            {
                new object[]
                {
                    new DoctorVacation()
                    {
                        Id = 2,
                        DateSpecification = new TimeInterval(new DateTime(2022,1,16),new DateTime(2022,1,20)),
                        DoctorId = "mkisic",
                        Description = "Zimovanje",
                        DoctorsScheduleId = 1
                    },
                    new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022,1,23),new DateTime(2022,1,24)),
                            DoctorId = "mkisic",
                            Description = "Bolovanje",
                            DoctorsScheduleId = 1
                        },

                    },
                    new DoctorsSchedule( new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022,1,23),new DateTime(2022,1,24)),
                            DoctorId = "mkisic",
                            Description = "Bolovanje",
                            DoctorsScheduleId = 1
                        },

                    }, new List<OnCallShift>(), "mkisic")
                    {
                        Id = 1
                    },
                },
                new object[]
                {
                    new DoctorVacation()
                    {
                        Id = 2,
                        DateSpecification = new TimeInterval(new DateTime(2022,3,27),new DateTime(2022,4,2)),
                        DoctorId = "nelex",
                        Description = "Slava",
                        DoctorsScheduleId = 2
                    },
                    new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022,3,15),new DateTime(2022,3,17)),
                            DoctorId = "nelex",
                            Description = "Letovanje",
                            DoctorsScheduleId = 2
                        },

                    },
                    new DoctorsSchedule( new List<DoctorVacation>
                    {
                        new DoctorVacation()
                        {
                            Id = 1,
                            DateSpecification = new TimeInterval(new DateTime(2022,3,15),new DateTime(2022,3,17)),
                            DoctorId = "nelex",
                            Description = "Letovanje",
                            DoctorsScheduleId = 2
                        },

                    }, new List<OnCallShift>(), "nelex")
                    {
                        Id = 2
                    },
                }
            };
        #endregion
    }
}
