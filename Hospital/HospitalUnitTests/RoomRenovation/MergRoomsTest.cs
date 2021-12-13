using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Service;
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
            RoomGraphic rg = new RoomGraphic() { Id = 1, X = 0, Y = 0, Height = 100, Width = 100, RoomId = 1 };

            List<RoomGraphic> roomGraphicsOnSameFloor = new List<RoomGraphic>()
            {
                new RoomGraphic() { Id = 1, X = 0, Y = 0, Height = 100, Width = 100, RoomId = 1 },
                new RoomGraphic() { Id = 2, X = 100, Y = 0, Height = 100, Width = 100, RoomId = 3 },
                new RoomGraphic() { Id = 3, X = 0, Y = 100, Height = 100, Width = 100, RoomId = 6 },
                new RoomGraphic() { Id = 4, X = 100, Y = 100, Height = 100, Width = 100, RoomId = 8 }
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


        // 

    }
}
