using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.RoomsAndEquipment.Service;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace HospitalUnitTests.RoomRenovation
{
    public class SplitRoomsTest
    {
        [Theory]
        [MemberData(nameof(RoomData))]
        public void Split_room(TermOfRenovation term, Room room, List<Room> expectedSplitRooms)
        {
            var stubRoomRepository = new Mock<IRoomRepository>();
            stubRoomRepository.Setup(r => r.Get(term.IdRoomA)).Returns(room);
            stubRoomRepository.Setup(r => r.GetNewId()).Returns(room.Id + 1);
            RoomService roomService = new RoomService(stubRoomRepository.Object);

            List<Room> splitRooms = roomService.SplitRoom(term);

            splitRooms.ShouldBeEquivalentTo(expectedSplitRooms);
        }

        #region RoomData
        public static IEnumerable<object[]> RoomData =>
            new List<object[]>
            {
                new object[]
                {
                    new TermOfRenovation()
                    {
                        TypeOfRenovation = TypeOfRenovation.SPLIT,
                        IdRoomA = 1,
                        IdRoomB = -1,
                        NewNameForRoomA = "Operation room A",
                        NewRoomTypeForRoomA = RoomType.operation,
                        NewSectorForRoomA = "ORS",
                        NewNameForRoomB = "Examination room B",
                        NewRoomTypeForRoomB = RoomType.examination,
                        NewSectorForRoomB = "ERS"
                    },
                    new Room()
                    {
                        Id = 1,
                        Floor = 0,
                        Name = "Examination room 1",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    },
                    new List<Room>()
                    {
                        new Room()
                        {
                            Id = 2,
                            Floor = 0,
                            Name = "Operation room A",
                            RoomType = RoomType.operation,
                            Sector = "ORS"
                        },
                        new Room()
                        {
                            Id = 3,
                            Floor = 0,
                            Name = "Examination room B",
                            RoomType = RoomType.examination,
                            Sector = "ERS"
                        }
                    }
                },
                new object[]
                {
                    new TermOfRenovation()
                    {
                        TypeOfRenovation = TypeOfRenovation.MERGE,
                        IdRoomA = 1,
                        IdRoomB = -1,
                        NewNameForRoomA = "Operation room A",
                        NewRoomTypeForRoomA = RoomType.operation,
                        NewSectorForRoomA = "ORS",
                        NewNameForRoomB = "Examination room B",
                        NewRoomTypeForRoomB = RoomType.examination,
                        NewSectorForRoomB = "ERS"
                    },
                    new Room()
                    {
                        Id = 1,
                        Floor = 0,
                        Name = "Examination room 1",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    },
                    new List<Room>()
                }
            };
        #endregion

        [Theory]
        [MemberData(nameof(RoomGraphicData))]
        public void Split_room_graphic(Room room, List<Room> rooms, RoomGraphic roomGraphic, List<RoomGraphic> expectedRoomGraphics)
        {
            var stubRoomService = new Mock<IRoomService>();
            var stubFloorGraphicRepository = new Mock<IFloorGraphicRepository>();
            stubFloorGraphicRepository.Setup(r => r.GetRoomGraphicByRoomId(room.Id)).Returns(roomGraphic);
            var stubRoomGraphicRepository = new Mock<IRoomGraphicRepository>();
            RoomGraphicService roomGraphicService = new RoomGraphicService(stubRoomGraphicRepository.Object,
                stubFloorGraphicRepository.Object, stubRoomService.Object);

            List<RoomGraphic> splitRoomGraphic = roomGraphicService.SplitRoomGraphic(room, rooms);

            splitRoomGraphic.ShouldBeEquivalentTo(expectedRoomGraphics);
        }

        #region RoomGraphicData
        public static IEnumerable<object[]> RoomGraphicData =>
            new List<object[]>
            {
                new object[]
                {
                    GetRoom(0),
                    GetRooms(0),
                    new RoomGraphic()
                    {
                        Room = GetRoom(0),
                        DoorPosition = "right",
                        Height = 300,
                        Width = 100,
                        RoomId = 1,
                        X = 0,
                        Y = 0,
                    },
                    new List<RoomGraphic>()
                    {
                        new RoomGraphic
                        {
                            Id = 2,
                            Room = GetRooms(0)[0],
                            DoorPosition = "right",
                            Height = 150,
                            Width = 100,
                            RoomId = 2,
                            X = 0,
                            Y = 0
                        },
                        new RoomGraphic
                        {
                            Id = 3,
                            Room = GetRooms(0)[1],
                            DoorPosition = "right",
                            Height = 150,
                            Width = 100,
                            RoomId = 3,
                            X = 0,
                            Y = 150
                        }
                    }
                },
                new object[]
                {
                    GetRoom(0),
                    GetRooms(0),
                    new RoomGraphic()
                    {
                        Room = GetRoom(0),
                        DoorPosition = "left",
                        Height = 300,
                        Width = 100,
                        RoomId = 1,
                        X = 0,
                        Y = 0,
                    },
                    new List<RoomGraphic>()
                    {
                        new RoomGraphic
                        {
                            Id = 2,
                            Room = GetRooms(0)[0],
                            DoorPosition = "left",
                            Height = 150,
                            Width = 100,
                            RoomId = 2,
                            X = 0,
                            Y = 0
                        },
                        new RoomGraphic
                        {
                            Id = 3,
                            Room = GetRooms(0)[1],
                            DoorPosition = "left",
                            Height = 150,
                            Width = 100,
                            RoomId = 3,
                            X = 0,
                            Y = 150
                        }
                    }
                },
                new object[]
                {
                    GetRoom(0),
                    GetRooms(0),
                    new RoomGraphic()
                    {
                        Room = GetRoom(0),
                        DoorPosition = "top",
                        Height = 300,
                        Width = 100,
                        RoomId = 1,
                        X = 0,
                        Y = 0,
                    },
                    new List<RoomGraphic>()
                    {
                        new RoomGraphic
                        {
                            Id = 2,
                            Room = GetRooms(0)[0],
                            DoorPosition = "top",
                            Height = 300,
                            Width = 50,
                            RoomId = 2,
                            X = 0,
                            Y = 0
                        },
                        new RoomGraphic
                        {
                            Id = 3,
                            Room = GetRooms(0)[1],
                            DoorPosition = "top",
                            Height = 300,
                            Width = 50,
                            RoomId = 3,
                            X = 50,
                            Y = 0
                        }
                    },
                },
                new object[]
                {
                    GetRoom(0),
                    GetRooms(0),
                    new RoomGraphic()
                    {
                        Room = GetRoom(0),
                        DoorPosition = "bottom",
                        Height = 300,
                        Width = 100,
                        RoomId = 1,
                        X = 0,
                        Y = 0,
                    },
                    new List<RoomGraphic>()
                    {
                        new RoomGraphic
                        {
                            Id = 2,
                            Room = GetRooms(0)[0],
                            DoorPosition = "bottom",
                            Height = 300,
                            Width = 50,
                            RoomId = 2,
                            X = 0,
                            Y = 0
                        },
                        new RoomGraphic
                        {
                            Id = 3,
                            Room = GetRooms(0)[1],
                            DoorPosition = "bottom",
                            Height = 300,
                            Width = 50,
                            RoomId = 3,
                            X = 50,
                            Y = 0
                        }
                    }
                },
                new object[]
                {
                    GetRoom(0),
                    GetRooms(0),
                    new RoomGraphic()
                    {
                        Room = GetRoom(0),
                        DoorPosition = "right",
                        Height = 301,
                        Width = 100,
                        RoomId = 1,
                        X = 0,
                        Y = 0,
                    },
                    new List<RoomGraphic>()
                    {
                        new RoomGraphic
                        {
                            Id = 2,
                            Room = GetRooms(0)[0],
                            DoorPosition = "right",
                            Height = 150,
                            Width = 100,
                            RoomId = 2,
                            X = 0,
                            Y = 0
                        },
                        new RoomGraphic
                        {
                            Id = 3,
                            Room = GetRooms(0)[1],
                            DoorPosition = "right",
                            Height = 151,
                            Width = 100,
                            RoomId = 3,
                            X = 0,
                            Y = 150
                        }
                    }
                },
                new object[]
                {
                    GetRoom(0),
                    GetRooms(0),
                    new RoomGraphic()
                    {
                        Room = GetRoom(0),
                        DoorPosition = "bottom",
                        Height = 300,
                        Width = 101,
                        RoomId = 1,
                        X = 0,
                        Y = 0,
                    },
                    new List<RoomGraphic>()
                    {
                        new RoomGraphic
                        {
                            Id = 2,
                            Room = GetRooms(0)[0],
                            DoorPosition = "bottom",
                            Height = 300,
                            Width = 50,
                            RoomId = 2,
                            X = 0,
                            Y = 0
                        },
                        new RoomGraphic
                        {
                            Id = 3,
                            Room = GetRooms(0)[1],
                            DoorPosition = "bottom",
                            Height = 300,
                            Width = 51,
                            RoomId = 3,
                            X = 50,
                            Y = 0
                        }
                    }
                }
            };

        private static Room GetRoom(int i)
        {
            Room room = new Room();
            if (i == 0)
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
            return room;
        }

        private static List<Room> GetRooms(int i)
        {
            List<Room> rooms = new List<Room>();
            if (i == 0)
            {
                rooms = new List<Room>()
                {
                    new Room()
                    {
                        Id = 2,
                        Floor = 0,
                        Name = "Operation room A",
                        RoomType = RoomType.operation,
                        Sector = "ORS"
                    },
                    new Room()
                    {
                        Id = 3,
                        Floor = 0,
                        Name = "Examination room B",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    }
                };
            }
            return rooms;
        }

        #endregion

        [Theory]
        [MemberData(nameof(RoomEquipmentData))]
        public void Split_room_equipment(EquipmentLogic equipmentLogic, Room room, List<Room> rooms, List<RoomEquipment> roomEquipment, List<RoomEquipment> expectedRoomEquipment)
        {
            var stubRoomEquipmentRepository = new Mock<IRoomEquipmentRepository>();
            stubRoomEquipmentRepository.Setup(e => e.GetAllEquipmentInRoom(room.Id)).Returns(roomEquipment);
            RoomEquipmentService roomEquipmentService = new RoomEquipmentService(stubRoomEquipmentRepository.Object);

            List<RoomEquipment> splitRoomEquipment = roomEquipmentService.SplitRoomEquipment(equipmentLogic, room, rooms);

            splitRoomEquipment.ShouldBeEquivalentTo(expectedRoomEquipment);
        }

        #region RoomEquipmentData

        public static IEnumerable<object[]> RoomEquipmentData =>
            new List<object[]>
            {
                new object[]
                {
                    EquipmentLogic.HALF_IN_A_HALF_IN_B,
                    new Room()
                    {
                        Id = 1,
                        Floor = 0,
                        Name = "Examination room 1",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    },
                    new List<Room>()
                    {
                        new Room()
                        {
                            Id = 2,
                            Floor = 0,
                            Name = "Operation room A",
                            RoomType = RoomType.operation,
                            Sector = "ORS"
                        },
                        new Room()
                        {
                            Id = 3,
                            Floor = 0,
                            Name = "Examination room B",
                            RoomType = RoomType.examination,
                            Sector = "ERS"
                        }
                    },
                    new List<RoomEquipment>()
                    {
                        new RoomEquipment()
                        {
                            Name = "bed",
                            Quantity = 4,
                            Type = "Static",
                            RoomId = 1
                        },
                        new RoomEquipment()
                        {
                            Name = "needle",
                            Quantity = 33,
                            Type = "Dynamic",
                            RoomId = 1
                        },
                    },
                    new List<RoomEquipment>()
                    {
                        new RoomEquipment()
                        {
                            Id = 2,
                            Name = "bed",
                            Quantity = 2,
                            Type = "Static",
                            RoomId = 2
                        },
                        new RoomEquipment()
                        {
                            Id = 2,
                            Name = "needle",
                            Quantity = 16,
                            Type = "Dynamic",
                            RoomId = 2
                        },
                        new RoomEquipment()
                        {
                            Id = 3,
                            Name = "bed",
                            Quantity = 2,
                            Type = "Static",
                            RoomId = 3
                        },
                        new RoomEquipment()
                        {
                            Id = 3,
                            Name = "needle",
                            Quantity = 17,
                            Type = "Dynamic",
                            RoomId = 3
                        }
                    }
                },
                new object[]
                {
                    EquipmentLogic.ALL_EQUIPMENT_IN_A,
                    new Room()
                    {
                        Id = 1,
                        Floor = 0,
                        Name = "Examination room 1",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    },
                    new List<Room>()
                    {
                        new Room()
                        {
                            Id = 2,
                            Floor = 0,
                            Name = "Operation room A",
                            RoomType = RoomType.operation,
                            Sector = "ORS"
                        },
                        new Room()
                        {
                            Id = 3,
                            Floor = 0,
                            Name = "Examination room B",
                            RoomType = RoomType.examination,
                            Sector = "ERS"
                        }
                    },
                    new List<RoomEquipment>()
                    {
                        new RoomEquipment()
                        {

                            Name = "bed",
                            Quantity = 4,
                            Type = "Static",
                            RoomId = 1
                        },
                        new RoomEquipment()
                        {
                            Name = "needle",
                            Quantity = 33,
                            Type = "Dynamic",
                            RoomId = 1
                        },
                    },
                    new List<RoomEquipment>()
                    {
                        new RoomEquipment()
                        {
                            Id = 2,
                            Name = "bed",
                            Quantity = 4,
                            Type = "Static",
                            RoomId = 2
                        },
                        new RoomEquipment()
                        {
                            Id = 2,
                            Name = "needle",
                            Quantity = 33,
                            Type = "Dynamic",
                            RoomId = 2
                        }
                    }
                },
                new object[]
                {
                    EquipmentLogic.ALL_EQUIPMENT_IN_B,
                    new Room()
                    {
                        Id = 1,
                        Floor = 0,
                        Name = "Examination room 1",
                        RoomType = RoomType.examination,
                        Sector = "ERS"
                    },
                    new List<Room>()
                    {
                        new Room()
                        {
                            Id = 2,
                            Floor = 0,
                            Name = "Operation room A",
                            RoomType = RoomType.operation,
                            Sector = "ORS"
                        },
                        new Room()
                        {
                            Id = 3,
                            Floor = 0,
                            Name = "Examination room B",
                            RoomType = RoomType.examination,
                            Sector = "ERS"
                        }
                    },
                    new List<RoomEquipment>()
                    {
                        new RoomEquipment()
                        {
                            Name = "bed",
                            Quantity = 4,
                            Type = "Static",
                            RoomId = 1
                        },
                        new RoomEquipment()
                        {
                            Name = "needle",
                            Quantity = 33,
                            Type = "Dynamic",
                            RoomId = 1
                        },
                    },
                    new List<RoomEquipment>()
                    {
                        new RoomEquipment()
                        {
                            Id = 3,
                            Name = "bed",
                            Quantity = 4,
                            Type = "Static",
                            RoomId = 3
                        },
                        new RoomEquipment()
                        {
                            Id = 3,
                            Name = "needle",
                            Quantity = 33,
                            Type = "Dynamic",
                            RoomId = 3
                        }
                    }
                }
            };

        #endregion
    }
}
