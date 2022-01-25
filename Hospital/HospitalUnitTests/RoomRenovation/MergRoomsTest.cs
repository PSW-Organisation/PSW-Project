using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.RoomsAndEquipment.Service;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace HospitalUnitTests.RoomRenovation
{
    public class MergRoomsTest
    {

        private readonly ITestOutputHelper _output;
        private bool printAllowed = true;
        public MergRoomsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void two_room_can_be_merged()
        {
            var stubRoomGraphicRepository = new Mock<IRoomGraphicRepository>();
            var stubFloorGraphicRepository = new Mock<IFloorGraphicRepository>();
            var stubRoomRepository = new Mock<IRoomService>();

            Room room = new Room() { Floor = 2, Id = 1, Name = "Soba 1" };
            RoomGraphic rg = new RoomGraphic() { Id = 1, Position = new Position(0, 0), Dimension = new Dimension(100, 100), RoomId = 1 };

            List<RoomGraphic> roomGraphicsOnSameFloor = new List<RoomGraphic>()
            {
                new RoomGraphic() { Id = 1, Position = new Position(0, 0), Dimension = new Dimension(100, 100), RoomId = 1 },
                new RoomGraphic() { Id = 2, Position = new Position(100,0), Dimension = new Dimension(100, 100), RoomId = 3 },
                new RoomGraphic() { Id = 3, Position = new Position(0,100), Dimension = new Dimension(100, 100), RoomId = 6 },
                new RoomGraphic() { Id = 4, Position = new Position(100,100), Dimension = new Dimension(100, 100), RoomId = 8 }
            };

            stubFloorGraphicRepository.Setup(par => par.GetAllRoomGraphicOnSameFloor(It.Is<Room>(r => r.Id == room.Id))).Returns(roomGraphicsOnSameFloor);


            RoomGraphicService roomGraphicService = new RoomGraphicService(stubRoomGraphicRepository.Object, stubFloorGraphicRepository.Object, stubRoomRepository.Object);
            List<RoomGraphic> allPossibleRoomsForMerg = roomGraphicService.GetAllPossibleRoomsForMerg(rg, room);

            foreach(RoomGraphic roomG in allPossibleRoomsForMerg)
            {
                _output.WriteLine("ID " + roomG.Id);
            }

            allPossibleRoomsForMerg.Count.ShouldBeEquivalentTo(2);
        }

        [Theory]
        [MemberData(nameof(RoomData))]
        public void Merge_room(TermOfRenovation term, Room roomA, Room roomB, Room expectedNewRoom)
        {
            var stubRoomRepository = new Mock<IRoomRepository>();
            stubRoomRepository.Setup(r => r.Get(It.Is<int>(id => id == roomA.Id))).Returns(roomA);
            stubRoomRepository.Setup(r => r.Get(It.Is<int>(id => id == roomB.Id))).Returns(roomB);
            RoomService roomService = new RoomService(stubRoomRepository.Object);

            Room newRoom = roomService.MergeRoom(term);

            newRoom.ShouldBeEquivalentTo(expectedNewRoom);
        }

        #region RoomData
        public static IEnumerable<object[]> RoomData =>
            new List<object[]>
            {
                new object[]
                {
                    new TermOfRenovation()
                    {
                        TypeOfRenovation = TypeOfRenovation.MERGE,
                        IdRoomA = 1,
                        IdRoomB = 2,
                        NewNameForRoomA = "Operation room C",
                        NewRoomTypeForRoomA = RoomType.operation,
                        NewSectorForRoomA = "ORS",
                        NewNameForRoomB = "",
                        NewRoomTypeForRoomB = RoomType.examination,
                        NewSectorForRoomB = ""
                    },
                    new Room()
                    {
                        Id = 1,
                        Floor = 0,
                        Name = "Examination room 1",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    },
                    new Room()
                    {
                        Id = 2,
                        Floor = 0,
                        Name = "Examination room 1",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    },
                    new Room()
                    {
                        Id = 0,
                        Floor = 0,
                        Name = "Operation room C",
                        RoomType = RoomType.operation,
                        Sector = "ORS"
                    }
                },
                new object[]
                {
                    new TermOfRenovation()
                    {
                        TypeOfRenovation = TypeOfRenovation.MERGE,
                        IdRoomA = 4,
                        IdRoomB = 5,
                        NewNameForRoomA = "Operation room D",
                        NewRoomTypeForRoomA = RoomType.operation,
                        NewSectorForRoomA = "ORS",
                        NewNameForRoomB = "",
                        NewRoomTypeForRoomB = RoomType.examination,
                        NewSectorForRoomB = ""
                    },
                    new Room()
                    {
                        Id = 4,
                        Floor = 2,
                        Name = "Examination room 3",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    },
                    new Room()
                    {
                        Id = 5,
                        Floor = 2,
                        Name = "Examination room 4",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    },
                    new Room()
                    {
                        Id = 0,
                        Floor = 2,
                        Name = "Operation room D",
                        RoomType = RoomType.operation,
                        Sector = "ORS"
                    }
                }
            };
        #endregion


        [Theory]
        [MemberData(nameof(RoomGraphicData))]
        public void Merge_room_graphic(Room roomA, RoomGraphic roomGraphicA,
                                       Room roomB, RoomGraphic roomGraphicB,
                                       Room newRoom, RoomGraphic newRoomGraphic)
        {
            var stubRoomService = new Mock<IRoomService>();
            var stubFloorGraphicRepository = new Mock<IFloorGraphicRepository>();
            stubFloorGraphicRepository.Setup(r => r.GetRoomGraphicByRoomId(It.Is<int>(id => id == roomA.Id))).Returns(roomGraphicA);
            stubFloorGraphicRepository.Setup(r => r.GetRoomGraphicByRoomId(It.Is<int>(id => id == roomB.Id))).Returns(roomGraphicB);
            var stubRoomGraphicRepository = new Mock<IRoomGraphicRepository>();
            RoomGraphicService roomGraphicService = new RoomGraphicService(stubRoomGraphicRepository.Object, stubFloorGraphicRepository.Object, stubRoomService.Object);
            
            RoomGraphic mergerRoomGraphic = roomGraphicService.MergeRoomGraphic(roomA, roomB, newRoom);
            _output.WriteLine(mergerRoomGraphic.ToString());

            mergerRoomGraphic.ShouldBeEquivalentTo(newRoomGraphic);
        }

        #region RoomGraphicData
        public static IEnumerable<object[]> RoomGraphicData =>
            new List<object[]>
            {
                new object[]
                { 
                    GetRoom(1),
                    GetRoomGraphic(1),
                    GetRoom(2),
                    GetRoomGraphic(2),
                    GetRoom(3),
                    new RoomGraphic() { Id = 3, Position = new Position(0,0), Dimension = new Dimension(200, 100), RoomId = 3, Room = GetRoom(3)}
                },
                new object[]
                {
                    GetRoom(1),
                    GetRoomGraphic(4),
                    GetRoom(2),
                    GetRoomGraphic(5),
                    GetRoom(3),
                    new RoomGraphic() { Id = 3, Position = new Position(130, 270), Dimension = new Dimension(58, 200), RoomId = 3, Room = GetRoom(3)}
                }
            };

        private static Room GetRoom(int i)
        {
            Room room = new Room();
            if (i == 1)
            {
                room = new Room()
                {
                    Id = 1,
                    Floor = 0,
                    Name = "Examination room 1",
                    RoomType = RoomType.examination,
                    Sector = "ERS"
                };
            }
            else if (i == 2)
            {
                room = new Room()
                {
                    Id = 2,
                    Floor = 0,
                    Name = "Examination room 2",
                    RoomType = RoomType.examination,
                    Sector = "ERS"
                };
            }
            else if(i == 3)
            {
                room = new Room()
                {
                    Id = 3,
                    Floor = 0,
                    Name = "Examination room 3",
                    RoomType = RoomType.examination,
                    Sector = "ERS"
                };
            }
            else if (i == 4)
            {
                room = new Room()
                {
                    Id = 4,
                    Floor = 0,
                    Name = "Examination room 4",
                    RoomType = RoomType.examination,
                    Sector = "ERS"
                };
            }
            else if (i == 5)
            {
                room = new Room()
                {
                    Id = 5,
                    Floor = 0,
                    Name = "Examination room 5",
                    RoomType = RoomType.examination,
                    Sector = "ERS"
                };
            }

            return room;
        }

        private static RoomGraphic GetRoomGraphic(int i)
        {
            RoomGraphic roomGraphic = new RoomGraphic();
            if(i == 1)
            {
                roomGraphic = new RoomGraphic() { Id = 1, Position = new Position(0,0), Dimension =  new Dimension(100, 100), RoomId = 1 };
            }
            else if(i == 2)
            {
                roomGraphic = new RoomGraphic() { Id = 2, Position = new Position(100,0), Dimension = new Dimension(100,100), RoomId = 1 };
            }
            else if(i == 3)
            {
                roomGraphic = new RoomGraphic() { Id = 3, Position = new Position(0,0), Dimension = new Dimension(200, 100), RoomId = 1 };
            }
            else if(i == 4)
            {
                roomGraphic = new RoomGraphic() { Id = 4, Position = new Position(130,270), Dimension = new Dimension(58, 80), RoomId = 1 };
            }
            else if (i == 5)
            {
                roomGraphic = new RoomGraphic() { Id = 5, Position = new Position(130,350), Dimension = new Dimension(58, 120), RoomId = 1 };
            }

            return roomGraphic;
        }



        #endregion


        [Theory]
        [MemberData(nameof(RoomEquipmentData))]
        public void Merge_room_equipment(Room roomA, RoomEquipment roomEquipmentA,
                                         Room roomB, RoomEquipment roomEquipmentB,
                                         Room newRoom, RoomEquipment newRoomEquipment)
        {
            var stubRoomEquipmentRepository = new Mock<IRoomEquipmentRepository>();
            stubRoomEquipmentRepository.Setup(e => e.GetRoomEquipmentInRoom(It.Is<int>(id => id == roomA.Id))).Returns(roomEquipmentA);
            stubRoomEquipmentRepository.Setup(e => e.GetRoomEquipmentInRoom(It.Is<int>(id => id == roomB.Id))).Returns(roomEquipmentB);
            RoomEquipmentService roomEquipmentService = new RoomEquipmentService(stubRoomEquipmentRepository.Object);

            RoomEquipment mergeRoomEquipment = roomEquipmentService.MergeRoomEquipment(roomA, roomB, newRoom);

            mergeRoomEquipment.ShouldBeEquivalentTo(newRoomEquipment);
        }

        #region RoomEquipmentData

        public static IEnumerable<object[]> RoomEquipmentData =>
            new List<object[]>
            {
                new object[]
                {
                   GetRoom(1),
                   GetRoomEquipment(1),
                   GetRoom(2),
                   GetRoomEquipment(2),
                   GetRoom(3),
                   GetRoomEquipment(3)
                },
                new object[]
                {
                   GetRoom(3),
                   GetRoomEquipment(3),
                   GetRoom(4),
                   GetRoomEquipment(4),
                   GetRoom(5),
                   GetRoomEquipment(5)
                }
            };

        public static RoomEquipment GetRoomEquipment(int i)
        {
            RoomEquipment roomEquipment = new RoomEquipment();
            if(i == 1)
            {
                roomEquipment = new RoomEquipment(1, new List<Equipment>()
                {
                    new Equipment(7, "Makaze", "oprema", 1),
                    new Equipment(5, "Stolica", "oprema", 1),
                    new Equipment(1, "XRay", "aparat", 1),
                    new Equipment(2, "TV", "oprema", 1)
                });
            }
            else if(i == 2)
            {
                roomEquipment = new RoomEquipment(2, new List<Equipment>()
                {
                    new Equipment(4, "Makaze", "oprema", 2),
                    new Equipment(1, "Stolica", "oprema", 2),
                    new Equipment(25, "UV Lampa", "oprema", 2),
                    new Equipment(100, "Infuzija", "oprema", 2)
                });
            }
            else if(i == 3)
            {
                roomEquipment = new RoomEquipment(3, new List<Equipment>()
                {
                    new Equipment(11, "Makaze", "oprema", 3),
                    new Equipment(6, "Stolica", "oprema", 3),
                    new Equipment(1, "XRay", "aparat", 3),
                    new Equipment(2, "TV", "oprema", 3),
                    new Equipment(25, "UV Lampa", "oprema", 3),
                    new Equipment(100, "Infuzija", "oprema", 3)
                });
            }
            else if(i == 4)
            {
                roomEquipment = new RoomEquipment(4, new List<Equipment>()
                {
                    new Equipment(2, "Nos", "oprema", 4),
                    new Equipment(4, "Igla", "oprema", 4),
                    new Equipment(5, "Zavoj", "oprema", 4)
                });
            }
            else if (i == 5)
            {
                roomEquipment = new RoomEquipment(5, new List<Equipment>()
                {
                    new Equipment(11, "Makaze", "oprema", 5),
                    new Equipment(6, "Stolica", "oprema", 5),
                    new Equipment(1, "XRay", "aparat", 5),
                    new Equipment(2, "TV", "oprema", 5),
                    new Equipment(25, "UV Lampa", "oprema", 5),
                    new Equipment(100, "Infuzija", "oprema", 5),
                    new Equipment(2, "Nos", "oprema", 5),
                    new Equipment(4, "Igla", "oprema", 5),
                    new Equipment(5, "Zavoj", "oprema", 5)
                });
            }

            return roomEquipment;
        }


            

        #endregion



    }
}
