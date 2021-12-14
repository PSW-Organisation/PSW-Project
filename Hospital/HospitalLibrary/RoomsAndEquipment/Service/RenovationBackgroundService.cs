using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class RenovationBackgroundService : BackgroundService
    {
        private IServiceScopeFactory _scopeFactory;

        public RenovationBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                RenovateRoom();
                await Task.Delay(1 * 60 * 1000, stoppingToken);
            }
        }

        private void RenovateRoom()
        {
            using var scope = _scopeFactory.CreateScope();
            var renovationRepository = scope.ServiceProvider.GetRequiredService<ITermOfRenovationRepository>();
            var roomRepository = scope.ServiceProvider.GetRequiredService<IRoomRepository>();
            var floorGraphicRepository = scope.ServiceProvider.GetRequiredService<IFloorGraphicRepository>();
            var roomGraphicRepository = scope.ServiceProvider.GetRequiredService<IRoomGraphicRepository>();
            var roomEquipmentRepository = scope.ServiceProvider.GetRequiredService<IRoomEquipmentRepository>();
            var roomService = scope.ServiceProvider.GetRequiredService<IRoomService>();
            var roomGraphicService = scope.ServiceProvider.GetRequiredService<IRoomGraphicService>();
            var roomEquipmentService = scope.ServiceProvider.GetRequiredService<IRoomEquipmentService>();

            List<TermOfRenovation> termOfRenovations = renovationRepository.GetPendingTerms();
            if (termOfRenovations.Count == 0) return;
            
            foreach (TermOfRenovation activeTerm in termOfRenovations)
            {
                activeTerm.StateOfRenovation = StateOfRenovation.SUCCESSFULLY;
                renovationRepository.Save(activeTerm);
                if (activeTerm.TypeOfRenovation == TypeOfRenovation.SPLIT)
                {
                    Room room = roomRepository.Get(activeTerm.IdRoomA);
                    List<Room> splitRooms = roomService.SplitRoom(activeTerm);
                    List<RoomGraphic> splitRoomGraphics = roomGraphicService.SplitRoomGraphic(room, splitRooms);
                    List<RoomEquipment> roomEquipments = roomEquipmentService.SplitRoomEquipment(activeTerm.EquipmentLogic, room, splitRooms);
                    
                    foreach (var splitRoom in splitRooms) roomRepository.Insert(splitRoom);

                    RoomGraphic roomGraphic = floorGraphicRepository.GetRoomGraphicByRoomId(room.Id);
                    FloorGraphic floorGraphic = floorGraphicRepository.GetFloorGraphicByRoomId(room.Id);
                    roomGraphicRepository.Delete(roomGraphic);
                    foreach (var splitRoomGraphic in splitRoomGraphics)
                    {
                        splitRoomGraphic.FloorGraphicId = floorGraphic.Id;
                        splitRoomGraphic.FloorGraphic = floorGraphic;
                        roomGraphicRepository.Insert(splitRoomGraphic);
                    }
                    
                    List<RoomEquipment> roomEquipmentInRoom = roomEquipmentRepository.GetAllEquipmentInRoom(room.Id);
                    foreach (var roomEquipment in roomEquipmentInRoom) roomEquipmentRepository.Delete(roomEquipment);
                    foreach(var roomEquipment in roomEquipments) roomEquipmentRepository.Insert(roomEquipment);
                    
                    roomRepository.Delete(room);
                }
                else if (activeTerm.TypeOfRenovation == TypeOfRenovation.MERGE)
                {
                    Room roomA = roomRepository.Get(activeTerm.IdRoomA);
                    Room roomB = roomRepository.Get(activeTerm.IdRoomB);
                    Room mergeRoom = roomService.MergeRoom(activeTerm);
                    RoomGraphic mergeRoomGraphic = roomGraphicService.MergeRoomGraphic(roomA, roomB, mergeRoom);
                    List<RoomEquipment> roomEquipments = roomEquipmentService.MergeRoomEquipment(roomA, roomB, mergeRoom);

                    roomRepository.Insert(mergeRoom);

                    RoomGraphic roomGraphicA = roomGraphicRepository.Get(roomA.Id);
                    RoomGraphic roomGraphicB = roomGraphicRepository.Get(roomB.Id);
                    FloorGraphic floorGraphic = floorGraphicRepository.GetFloorGraphicByRoomId(roomA.Id);
                    roomGraphicRepository.Delete(roomGraphicA);
                    roomGraphicRepository.Delete(roomGraphicB);
                    mergeRoomGraphic.FloorGraphicId = floorGraphic.Id;
                    mergeRoomGraphic.FloorGraphic = floorGraphic;
                    roomGraphicRepository.Insert(mergeRoomGraphic);

                    List<RoomEquipment> roomEquipmentInRoomA = roomEquipmentRepository.GetAllEquipmentInRoom(roomA.Id);
                    List<RoomEquipment> roomEquipmentInRoomB = roomEquipmentRepository.GetAllEquipmentInRoom(roomB.Id);
                    foreach (var roomEquipment in roomEquipmentInRoomA) roomEquipmentRepository.Delete(roomEquipment);
                    foreach (var roomEquipment in roomEquipmentInRoomB) roomEquipmentRepository.Delete(roomEquipment);
                    foreach (var roomEquipment in roomEquipments) roomEquipmentRepository.Insert(roomEquipment);
                    
                    roomRepository.Delete(roomA);
                    roomRepository.Delete(roomB);
                }
            }
        }
    }
}
