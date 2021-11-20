using HospitalLibrary.RoomsAndEquipment.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HospitalLibrary.RoomsAndEquipment.Repository;
using Shouldly;

namespace HospitalUnitTests
{
    public class TermOfRelocationEquipmentTests
    {

       

        [Theory]
        [MemberData(nameof(Data))]
        public void Get_free_possible_terms_of_Relocation(
            ParamsOfRelocationEquipment paramsOfRelocationEquipment,
            List<TermOfRelocationEquipment> sourceRoomTerms, int sourceRoomId,
            List<TermOfRelocationEquipment> destinationRoomTerms, int destinationRoomId,
            int numberOfFreeInterval)
        {
            
            var stubRepository = new Mock<IRelocationEquipmentRepository>();
            stubRepository.Setup(par => par.GetTermsOfRelocationByRoomId(It.Is<int>(id => id == sourceRoomId))).Returns(sourceRoomTerms);
            stubRepository.Setup(par => par.GetTermsOfRelocationByRoomId(It.Is<int>(id => id == destinationRoomId))).Returns(destinationRoomTerms);
            RelocationEquipmentService relocationEquipmentService = new RelocationEquipmentService(stubRepository.Object);
   
            List<TimeInterval> freeTimeInterval = relocationEquipmentService.GetFreePossibleTermsOfRelocation(paramsOfRelocationEquipment);

            freeTimeInterval.Count.ShouldBeEquivalentTo(numberOfFreeInterval);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { getParamsOfRelocation(1), getRelocationTerms(7), 7, getRelocationTerms(6), 6, 5},
            new object[] { getParamsOfRelocation(2), getRelocationTerms(7), 7, getRelocationTerms(6), 6, 14}
        };



        public static ParamsOfRelocationEquipment getParamsOfRelocation(int idParams)
        {
            ParamsOfRelocationEquipment paramsOfRelocationEquipment = new ParamsOfRelocationEquipment();
            if (idParams == 1)
            {
                paramsOfRelocationEquipment = new ParamsOfRelocationEquipment()
                {
                    IdSourceRoom = 7,
                    IdDestinationRoom = 6,
                    NameOfEquipment = "infusion",
                    QuantityOfEquipment = 3,
                    StartTime = new DateTime(2021, 11, 22, 15, 23, 0),
                    endTime = new DateTime(2021, 11, 22, 16, 20, 0),
                    durationInMinutes = 10
                };
            }
            else if (idParams == 2)
            {
                paramsOfRelocationEquipment = new ParamsOfRelocationEquipment()
                {
                    IdSourceRoom = 7,
                    IdDestinationRoom = 6,
                    NameOfEquipment = "bed",
                    QuantityOfEquipment = 3,
                    StartTime = new DateTime(2021, 11, 22, 2, 15, 0),
                    endTime = new DateTime(2021, 11, 22, 6, 30, 0),
                    durationInMinutes = 15
                };
            }
            return paramsOfRelocationEquipment;
        }

        public static List<TermOfRelocationEquipment> getRelocationTerms(int idRoom)
        {
            List<TermOfRelocationEquipment> roomTerms = new List<TermOfRelocationEquipment>();
            if (idRoom == 7)
            {
                roomTerms = new List<TermOfRelocationEquipment>()
                {
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 7,
                        IdDestinationRoom = 8,
                        NameOfEquipment = "bed",
                        QuantityOfEquipment = 2,
                        StartTime = new DateTime(2021, 11, 22, 1, 0, 0),
                        EndTime = new DateTime(2021, 11, 22, 1, 10, 0),
                        durationInMinutes = 10,
                        FinishedRelocation = false
                    },
                    new TermOfRelocationEquipment()
                    {
                        Id = 2,
                        IdSourceRoom = 7,
                        IdDestinationRoom = 9,
                        NameOfEquipment = "needle",
                        QuantityOfEquipment = 14,
                        StartTime = new DateTime(2021, 11, 22, 3, 30, 0),
                        EndTime = new DateTime(2021, 11, 22, 4, 10, 0),
                        durationInMinutes = 40,
                        FinishedRelocation = false
                    },
                    new TermOfRelocationEquipment()
                    {
                        Id = 5,
                        IdSourceRoom = 10,
                        IdDestinationRoom = 7,
                        NameOfEquipment = "xrayMachine",
                        QuantityOfEquipment = 1,
                        StartTime = new DateTime(2021, 11, 23, 10, 45, 0),
                        EndTime = new DateTime(2021, 11, 23, 11, 15, 0),
                        durationInMinutes = 30,
                        FinishedRelocation = false
                    }
                };
            }
            else if(idRoom == 6)
            {
                roomTerms = new List<TermOfRelocationEquipment>();
            }
            

            return roomTerms;
        }


    }
}
