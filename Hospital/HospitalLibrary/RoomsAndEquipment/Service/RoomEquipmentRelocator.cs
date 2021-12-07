using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class RoomEquipmentRelocator : IRoomEquipmentRelocator
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RoomEquipmentRelocator(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task RelocateEquipment(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                DoRelocation();
                await Task.Delay(1 * 60 * 1000);
            }
        }

        private void DoRelocation()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _relocationRepo = scope.ServiceProvider.GetRequiredService<ITermOfRelocationEquipmentRepository>();
                var _roomEquipmentRepo = scope.ServiceProvider.GetRequiredService<IRoomEquipmentRepository>();

                List<TermOfRelocationEquipment> termOfRelocation = _relocationRepo.CheckTermOfRelocationByDate();
                if (termOfRelocation.Count != 0)
                {
                    foreach (TermOfRelocationEquipment activeTermOfRelocation in termOfRelocation)
                    {
                        activeTermOfRelocation.FinishedRelocation = true;
                        _relocationRepo.Update(activeTermOfRelocation);
                        RoomEquipment sourceRoomEquipment = _roomEquipmentRepo.GetEquipmentInRoom(activeTermOfRelocation.IdSourceRoom, activeTermOfRelocation.NameOfEquipment);
                        RoomEquipment destinationRoomEquipment = _roomEquipmentRepo.GetEquipmentInRoom(activeTermOfRelocation.IdDestinationRoom, activeTermOfRelocation.NameOfEquipment);

                        if (sourceRoomEquipment == null) continue;
                        sourceRoomEquipment.Quantity -= activeTermOfRelocation.QuantityOfEquipment;
                        if (sourceRoomEquipment.Quantity < 0) continue;
                        else if (sourceRoomEquipment.Quantity == 0) _roomEquipmentRepo.Delete(sourceRoomEquipment);
                        else _roomEquipmentRepo.Update(sourceRoomEquipment);

                        if (destinationRoomEquipment != null)
                        {
                            destinationRoomEquipment.Quantity += activeTermOfRelocation.QuantityOfEquipment;
                            _roomEquipmentRepo.Update(destinationRoomEquipment);
                        }
                        else
                        {
                            destinationRoomEquipment = new RoomEquipment(sourceRoomEquipment);
                            destinationRoomEquipment.RoomId = activeTermOfRelocation.IdDestinationRoom;
                            destinationRoomEquipment.Quantity = activeTermOfRelocation.QuantityOfEquipment;
                            destinationRoomEquipment.Id = _roomEquipmentRepo.GetNewID();
                            _roomEquipmentRepo.Insert(destinationRoomEquipment);
                        }

                    }
                }
            }
        }

    }
}
