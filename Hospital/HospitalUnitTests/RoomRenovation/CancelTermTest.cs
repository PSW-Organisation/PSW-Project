using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Shouldly;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Service;

namespace HospitalUnitTests.RoomRenovation
{
    public class CancelTermTest
    {
        [Fact]
        public void CancelTermOfRelocationAllowed()
        {
            TermOfRelocationEquipment roomRelocationTerm = 
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 1,
                        IdDestinationRoom = 3,
                        NameOfEquipment = "sugar",
                        QuantityOfEquipment = 2,
                        StartTime = DateTime.Now.AddHours(30),
                        EndTime = DateTime.Now.AddHours(90),
                        DurationInMinutes = 150
                        //FinishedRelocation = false   
                };
                
            var stubTermOfRelocationRepository = new Mock<ITermOfRelocationEquipmentRepository>();
            var stubTermOfRenovationRepository = new Mock<ITermOfRenovationRepository>();
            stubTermOfRelocationRepository.Setup(par => par.Get(roomRelocationTerm.Id)).Returns(roomRelocationTerm);

            TermOfRelocationEquipmentService termOfRelocationService = new TermOfRelocationEquipmentService(stubTermOfRelocationRepository.Object, stubTermOfRenovationRepository.Object);

            
            bool isTermCancellationExecuted = termOfRelocationService.CancelRelocationTerm(roomRelocationTerm.IdSourceRoom);

            isTermCancellationExecuted.ShouldBeTrue();

        }

        [Fact]
        public void CancelTermOfRelocationForbidden()
        {
            TermOfRelocationEquipment roomRelocationTerm =
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 1,
                        IdDestinationRoom = 3,
                        NameOfEquipment = "sugar",
                        QuantityOfEquipment = 2,
                        StartTime = DateTime.Now.AddHours(20),
                        EndTime = DateTime.Now.AddHours(90),
                        DurationInMinutes = 150
                        //FinishedRelocation = false   
                    };

            var stubTermOfRelocationRepository = new Mock<ITermOfRelocationEquipmentRepository>();
            var stubTermOfRenovationRepository = new Mock<ITermOfRenovationRepository>();
            stubTermOfRelocationRepository.Setup(par => par.Get(roomRelocationTerm.Id)).Returns(roomRelocationTerm);

            TermOfRelocationEquipmentService termOfRelocationService = new TermOfRelocationEquipmentService(stubTermOfRelocationRepository.Object, stubTermOfRenovationRepository.Object);

            bool isTermCancellationExecuted = termOfRelocationService.CancelRelocationTerm(roomRelocationTerm.IdSourceRoom);

            isTermCancellationExecuted.ShouldBeFalse();

        }


    }
}
