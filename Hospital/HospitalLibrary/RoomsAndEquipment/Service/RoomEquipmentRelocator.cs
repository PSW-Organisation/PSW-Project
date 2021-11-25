using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class RoomEquipmentRelocator : IRoomEquipmentRelocator
    {
        IRelocationEquipmentRepository _relocationRepo;
        IRoomEquipmentRepository _roomEquipmentRepo;
        IServiceProvider _serviceScopeFactory;

        public RoomEquipmentRelocator(IRelocationEquipmentRepository iEquipmnet, IRoomEquipmentRepository a)
        {
            _relocationRepo = iEquipmnet;
            _roomEquipmentRepo =a;
        }
        public async Task RelocateEquipment(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                DoRelocation();
                await Task.Delay(1000);
            }
        }

        private void DoRelocation()
        {
            List<TermOfRelocationEquipment> termOfRelocation = _relocationRepo.CheckTermOfRelocationByDate();
            if (termOfRelocation.Count != 0)
            {

                foreach (TermOfRelocationEquipment activeTermOfRelocation in termOfRelocation)
                {
                    activeTermOfRelocation.FinishedRelocation = true;
                    _relocationRepo.Update(activeTermOfRelocation);
                    RoomEquipment sourceRoomEquipment = _roomEquipmentRepo.GetEquipmentInRoomByName(activeTermOfRelocation.IdSourceRoom, activeTermOfRelocation.NameOfEquipment);
                    RoomEquipment destinationRoomEquipment = _roomEquipmentRepo.GetEquipmentInRoomByName(activeTermOfRelocation.IdDestinationRoom, activeTermOfRelocation.NameOfEquipment);

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
                        _roomEquipmentRepo.Insert(destinationRoomEquipment);
                    }

                }
            }

        }
    }
}
