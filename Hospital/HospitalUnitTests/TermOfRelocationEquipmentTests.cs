using HospitalLibrary.RoomsAndEquipment.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HospitalLibrary.RoomsAndEquipment.Repository;
using Shouldly;
using Xunit.Abstractions;

namespace HospitalUnitTests
{
    public class TermOfRelocationEquipmentTests
    {
        private readonly ITestOutputHelper _output;
        private bool printAllowed = true;
        public TermOfRelocationEquipmentTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private void PrintInfo(ParamsOfRelocationEquipment paramsOfRelocationEquipment, List<TermOfRelocationEquipment> sourceRoomTerms, List<TermOfRelocationEquipment> destinationRoomTerms, List<TimeInterval> freeTimeInterval)
        {
            if (printAllowed)
            {
                _output.WriteLine("Time interval:" + paramsOfRelocationEquipment.StartTime + "  -  " + paramsOfRelocationEquipment.EndTime);
                _output.WriteLine("duration: " + paramsOfRelocationEquipment.DurationInMinutes.ToString());
                _output.WriteLine("sourceRoomTerms");
                foreach (TermOfRelocationEquipment tr in sourceRoomTerms)
                    _output.WriteLine(tr.StartTime + " - " + tr.EndTime);
                _output.WriteLine("destinationRoomTerms");
                foreach (TermOfRelocationEquipment tr in destinationRoomTerms)
                    _output.WriteLine(tr.StartTime + " - " + tr.EndTime);

                _output.WriteLine("Free time interval");
                foreach (TimeInterval t in freeTimeInterval)
                {
                    _output.WriteLine(t.StartTime.ToString() + "  -  " + t.EndTime.ToString());
                }
            }
        }


        [Theory]
        [MemberData(nameof(Data))]
        public void Get_free_possible_terms_of_Relocation(
            ParamsOfRelocationEquipment paramsOfRelocationEquipment,
            List<TermOfRelocationEquipment> sourceRoomTerms, int sourceRoomId,
            List<TermOfRelocationEquipment> destinationRoomTerms, int destinationRoomId,
            int numberOfFreeInterval)
        {

            var stubRepository = new Mock<ITermOfRelocationEquipmentRepository>();
            stubRepository.Setup(par => par.GetTermsOfRelocationByRoomId(It.Is<int>(id => id == sourceRoomId))).Returns(sourceRoomTerms);
            stubRepository.Setup(par => par.GetTermsOfRelocationByRoomId(It.Is<int>(id => id == destinationRoomId))).Returns(destinationRoomTerms);
            TermOfRelocationEquipmentService termOfRelocationEquipmentService = new TermOfRelocationEquipmentService(stubRepository.Object);

            List<TimeInterval> freeTimeInterval = termOfRelocationEquipmentService.GetFreePossibleTermsOfRelocation(paramsOfRelocationEquipment);

            PrintInfo(paramsOfRelocationEquipment, sourceRoomTerms, destinationRoomTerms, freeTimeInterval);

            freeTimeInterval.Count.ShouldBeEquivalentTo(numberOfFreeInterval);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {

            // Test1
            // Obe prostorije su potpuno slobodne u prosledjenom opsegu,
            // 11/22/2021 7:00:00 AM  -  11/22/2021 9:00:00 AM
            // duration: 10 minutes
            // number of terms: 12
            // room1: --|--------------------------|--
            // room2: --|--------------------------|--
            new object[] { getParamsOfRelocation(1), getRelocationTerms(0), 1, getRelocationTerms(0), 2, 12},

            // Test2
            // Obe prostorije su potpuno slobodne u prosledjenom opsegu, potpuno flexibilan izbor minuta
            // 11/22/2021 10:21:00 AM  -  11/22/2021 12:58:00 PM
            // duration: 49 minutes
            // number of terms: 3 
            // room1: --|--------------------------|--
            // room2: --|--------------------------|--
            new object[] { getParamsOfRelocation(2), getRelocationTerms(0), 1, getRelocationTerms(0), 2, 3},

            // Test3
            // Obe prostorije su potpuno slobodne u prosledjenom opsegu, duration je jednak zadatom opsegu
            // 11/22/2021 10:00:00 AM  -  11/22/2021 10:40:00 AM
            // duration: 40 minutes
            // number of terms: 1 
            // room1: --|--------------------------|--
            // room2: --|--------------------------|--
            new object[] { getParamsOfRelocation(3), getRelocationTerms(0), 1, getRelocationTerms(0), 2, 1},

            // Test4
            // Obe prostorije su potpuno slobodne u prosledjenom opsegu, duration je duzi od zadatog opsega
            // 11/22/2021 10:00:00 AM  -  11/22/2021 10:40:00 AM
            // duration: 45 minutes
            // number of terms: 0 
            // room1: --|--------------------------|--
            // room2: --|--------------------------|--
            new object[] { getParamsOfRelocation(4), getRelocationTerms(0), 1, getRelocationTerms(0), 2, 0},

            // Test5
            // Obe prostorije su potpuno slobodne u prosledjenom opsegu, visednevno premestanje
            // 11/22/2021 10:00:00 AM  -  11/29/2021 10:00:00 AM    (7 dana)
            // duration: 1920 minutes == 32h == 1dan i 8h
            // number of terms: 5 
            // room1: --|--------------------------|--
            // room2: --|--------------------------|--
            new object[] { getParamsOfRelocation(5), getRelocationTerms(0), 1, getRelocationTerms(0), 2, 5},

            // Test6
            // Prva prostorija ima neke termine, a druga prostorija nema ni jedan termin u prosledjenom opsegu
            // 11/22/2021 7:00:00 AM  -  11/22/2021 9:00:00 AM
            // duration: 10 minutes
            // number of terms: 9 
            // room1: --|-------------===-==---=---|--
            // room2: --|--------------------------|--
            new object[] { getParamsOfRelocation(1), getRelocationTerms(1), 1, getRelocationTerms(0), 2, 9},

            // Test7
            // Prva prostorija je u potpunosti zauzeta, druga prostorija je potpuno slobodna
            // 11/22/2021 7:00:00 AM  -  11/22/2021 9:00:00 AM
            // duration: 10 minutes
            // number of terms: 0
            // room1: -=|==========================|=-
            // room2: --|--------------------------|--
            new object[] { getParamsOfRelocation(1), getRelocationTerms(2), 1, getRelocationTerms(0), 2, 0},

            // Test8
            // I prva i druga prostorija su zauzete, tako da ne postoji slucaj da su obe slobodne
            // 11/22/2021 7:00:00 AM  -  11/22/2021 9:00:00 AM
            // duration: 10 minutes
            // number of terms: 0
            // room1: -=|=================---------|--
            // room2: --|-------------=============|=-
            new object[] { getParamsOfRelocation(1), getRelocationTerms(3), 1, getRelocationTerms(4), 2, 0},

            // Test9
            // Postoji period kad su obe prostorije slobodne al taj period je kraci od potrebnog za premestanje
            // 11/22/2021 7:00:00 AM  -  11/22/2021 9:00:00 AM
            // duration: 10 minutes
            // number of terms: 0
            // room1: -=|=================---------|--
            // room2: --|-------------------=======|=-
            new object[] { getParamsOfRelocation(1), getRelocationTerms(6), 1, getRelocationTerms(5), 2, 0},

            // Test10
            // Postoji tacno jedan slot tacne duzine kada su obe prostorije slobodne
            // 11/22/2021 7:00:00 AM  -  11/22/2021 9:00:00 AM
            // duration: 10 minutes
            // number of terms: 1
            // room1: -=|===============-----------|--
            // room2: --|-------------------=======|=-
            new object[] { getParamsOfRelocation(1), getRelocationTerms(3), 1, getRelocationTerms(5), 2, 1},
            
            // Test11
            // Obe prostorije imaju neke termine
            // 11/22/2021 7:00:00 AM  -  11/22/2021 9:00:00 AM
            // duration: 10 minutes
            // number of terms: 5 
            // room1: --|-------------===-==---=---|--
            // room2: --|---==---===-----=---------|--
            new object[] { getParamsOfRelocation(1), getRelocationTerms(1), 1, getRelocationTerms(7), 2, 5},


        };



        public static ParamsOfRelocationEquipment getParamsOfRelocation(int idParams)
        {
            ParamsOfRelocationEquipment paramsOfRelocationEquipment = new ParamsOfRelocationEquipment();
            if (idParams == 1)
            {
                paramsOfRelocationEquipment = new ParamsOfRelocationEquipment()
                {
                    IdSourceRoom = 1,
                    IdDestinationRoom = 2,
                    NameOfEquipment = "bed",
                    QuantityOfEquipment = 10,
                    StartTime = new DateTime(2021, 11, 22, 7, 0, 0),
                    EndTime = new DateTime(2021, 11, 22, 9, 0, 0),
                    DurationInMinutes = 10
                };
            }
            else if (idParams == 2)
            {
                paramsOfRelocationEquipment = new ParamsOfRelocationEquipment()
                {
                    IdSourceRoom = 1,
                    IdDestinationRoom = 2,
                    NameOfEquipment = "xray",
                    QuantityOfEquipment = 15,
                    StartTime = new DateTime(2021, 11, 22, 10, 21, 0),
                    EndTime = new DateTime(2021, 11, 22, 12, 58, 0),
                    DurationInMinutes = 49
                };
            }
            else if (idParams == 3)
            {
                paramsOfRelocationEquipment = new ParamsOfRelocationEquipment()
                {
                    IdSourceRoom = 1,
                    IdDestinationRoom = 2,
                    NameOfEquipment = "glovs",
                    QuantityOfEquipment = 20,
                    StartTime = new DateTime(2021, 11, 22, 10, 0, 0),
                    EndTime = new DateTime(2021, 11, 22, 10, 40, 0),
                    DurationInMinutes = 40
                };
            }
            else if (idParams == 4)
            {
                paramsOfRelocationEquipment = new ParamsOfRelocationEquipment()
                {
                    IdSourceRoom = 1,
                    IdDestinationRoom = 2,
                    NameOfEquipment = "glovs",
                    QuantityOfEquipment = 20,
                    StartTime = new DateTime(2021, 11, 22, 10, 0, 0),
                    EndTime = new DateTime(2021, 11, 22, 10, 40, 0),
                    DurationInMinutes = 45
                };
            }
            else if (idParams == 5)
            {
                paramsOfRelocationEquipment = new ParamsOfRelocationEquipment()
                {
                    IdSourceRoom = 1,
                    IdDestinationRoom = 2,
                    NameOfEquipment = "injection",
                    QuantityOfEquipment = 7,
                    StartTime = new DateTime(2021, 11, 22, 10, 0, 0),
                    EndTime = new DateTime(2021, 11, 29, 10, 0, 0),
                    DurationInMinutes = 1920
                };
            }

            return paramsOfRelocationEquipment;
        }

        public static List<TermOfRelocationEquipment> getRelocationTerms(int idParams)
        {
            List<TermOfRelocationEquipment> roomTerms = new List<TermOfRelocationEquipment>();
            if (idParams == 0)
            {
                roomTerms = new List<TermOfRelocationEquipment>();
            }
            else if (idParams == 1)
            {
                roomTerms = new List<TermOfRelocationEquipment>()
                {
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 1,
                        IdDestinationRoom = 3,
                        NameOfEquipment = "bed",
                        QuantityOfEquipment = 2,
                        StartTime = new DateTime(2021, 11, 22, 8, 10, 0),
                        EndTime = new DateTime(2021, 11, 22, 8, 20, 0),
                        DurationInMinutes = 10,
                        FinishedRelocation = false
                    },
                    new TermOfRelocationEquipment()
                    {
                        Id = 2,
                        IdSourceRoom = 1,
                        IdDestinationRoom = 4,
                        NameOfEquipment = "needle",
                        QuantityOfEquipment = 14,
                        StartTime = new DateTime(2021, 11, 22, 8, 25, 0),
                        EndTime = new DateTime(2021, 11, 22, 8, 30, 0),
                        DurationInMinutes = 5,
                        FinishedRelocation = false
                    },
                    new TermOfRelocationEquipment()
                    {
                        Id = 5,
                        IdSourceRoom = 1,
                        IdDestinationRoom = 5,
                        NameOfEquipment = "xrayMachine",
                        QuantityOfEquipment = 1,
                        StartTime = new DateTime(2021, 11, 22, 8, 45, 0),
                        EndTime = new DateTime(2021, 11, 22, 8, 48, 0),
                        DurationInMinutes = 3,
                        FinishedRelocation = false
                    }
                };
            }
            else if (idParams == 2)
            {
                roomTerms = new List<TermOfRelocationEquipment>()
                {
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 1,
                        IdDestinationRoom = 3,
                        NameOfEquipment = "bed",
                        QuantityOfEquipment = 2,
                        StartTime = new DateTime(2021, 11, 22, 6, 30, 0),
                        EndTime = new DateTime(2021, 11, 22, 11, 30, 0),
                        DurationInMinutes = 300,
                        FinishedRelocation = false
                    }
                };
            }
            else if (idParams == 3)
            {
                roomTerms = new List<TermOfRelocationEquipment>()
                {
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 1,
                        IdDestinationRoom = 3,
                        NameOfEquipment = "bed",
                        QuantityOfEquipment = 2,
                        StartTime = new DateTime(2021, 11, 22, 6, 0, 0),
                        EndTime = new DateTime(2021, 11, 22, 8, 30, 0),
                        DurationInMinutes = 150,
                        FinishedRelocation = false
                    }
                };
            }
            else if (idParams == 4)
            {
                roomTerms = new List<TermOfRelocationEquipment>()
                {
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 2,
                        IdDestinationRoom = 5,
                        NameOfEquipment = "chair",
                        QuantityOfEquipment = 2,
                        StartTime = new DateTime(2021, 11, 22, 8, 20, 0),
                        EndTime = new DateTime(2021, 11, 22, 10, 15, 0),
                        DurationInMinutes = 175,
                        FinishedRelocation = false
                    }
                };
            }
            else if (idParams == 5)
            {
                roomTerms = new List<TermOfRelocationEquipment>()
                {
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 2,
                        IdDestinationRoom = 5,
                        NameOfEquipment = "chair",
                        QuantityOfEquipment = 2,
                        StartTime = new DateTime(2021, 11, 22, 8, 40, 0),
                        EndTime = new DateTime(2021, 11, 22, 10, 15, 0),
                        DurationInMinutes = 155,
                        FinishedRelocation = false
                    }
                };
            }
            else if (idParams == 6)
            {
                roomTerms = new List<TermOfRelocationEquipment>()
                {
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 1,
                        IdDestinationRoom = 3,
                        NameOfEquipment = "sugar",
                        QuantityOfEquipment = 2,
                        StartTime = new DateTime(2021, 11, 22, 6, 0, 0),
                        EndTime = new DateTime(2021, 11, 22, 8, 35, 0),
                        DurationInMinutes = 150,
                        FinishedRelocation = false
                    }
                };
            }
            else if (idParams == 7)
            {
                roomTerms = new List<TermOfRelocationEquipment>()
                {
                    new TermOfRelocationEquipment()
                    {
                        Id = 1,
                        IdSourceRoom = 2,
                        IdDestinationRoom = 6,
                        NameOfEquipment = "scisors",
                        QuantityOfEquipment = 2,
                        StartTime = new DateTime(2021, 11, 22, 7, 20, 0),
                        EndTime = new DateTime(2021, 11, 22, 7, 25, 0),
                        DurationInMinutes = 5,
                        FinishedRelocation = false
                    },
                    new TermOfRelocationEquipment()
                    {
                        Id = 2,
                        IdSourceRoom = 2,
                        IdDestinationRoom = 7,
                        NameOfEquipment = "needle",
                        QuantityOfEquipment = 14,
                        StartTime = new DateTime(2021, 11, 22, 7, 30, 0),
                        EndTime = new DateTime(2021, 11, 22, 7, 45, 0),
                        DurationInMinutes = 15,
                        FinishedRelocation = false
                    },
                    new TermOfRelocationEquipment()
                    {
                        Id = 5,
                        IdSourceRoom = 2,
                        IdDestinationRoom = 7,
                        NameOfEquipment = "xrayMachine",
                        QuantityOfEquipment = 1,
                        StartTime = new DateTime(2021, 11, 22, 8, 30, 0),
                        EndTime = new DateTime(2021, 11, 22, 8, 45, 0),
                        DurationInMinutes = 15,
                        FinishedRelocation = false
                    }
                };
            }

            return roomTerms;
        }


    }
}