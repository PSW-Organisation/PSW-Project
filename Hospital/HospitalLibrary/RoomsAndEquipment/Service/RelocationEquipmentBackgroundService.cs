using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ehealthcare.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class RelocationEquipmentBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RelocationEquipmentBackgroundService(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DoRelocation();
                await Task.Delay(1 * 60 * 1000);
            }
        }

        private void DoRelocation()
        {
            using var scope = _scopeFactory.CreateScope();
            var _relocationRepo = scope.ServiceProvider.GetRequiredService<ITermOfRelocationEquipmentRepository>();
            var _roomEquipmentRepo = scope.ServiceProvider.GetRequiredService<IRoomEquipmentRepository>();

            List<TermOfRelocationEquipment> termOfRelocation = _relocationRepo.CheckTermOfRelocationByDate();
            if (termOfRelocation.Count != 0)
            {
                foreach (TermOfRelocationEquipment activeTerm in termOfRelocation)
                {
                    activeTerm.RelocationState = StateOfTerm.SUCCESSFULLY;
                    _relocationRepo.Update(activeTerm);
                    Equipment sourceEquipment = _roomEquipmentRepo.GetEquipmentInRoom(activeTerm.IdSourceRoom, activeTerm.NameOfEquipment);
                    RoomEquipment sourceRoomEquipment = _roomEquipmentRepo.GetRoomEquipmentInRoom(activeTerm.IdSourceRoom);
                    Equipment destEquipment = _roomEquipmentRepo.GetEquipmentInRoom(activeTerm.IdDestinationRoom, activeTerm.NameOfEquipment);
                    RoomEquipment destRoomEquipment = _roomEquipmentRepo.GetRoomEquipmentInRoom(activeTerm.IdDestinationRoom);

                    if (sourceEquipment == null) continue;
                    sourceEquipment.Quantity -= activeTerm.QuantityOfEquipment;
                    if (sourceEquipment.Quantity < 0) continue;
                    else if (sourceEquipment.Quantity == 0)
                    {
                        sourceRoomEquipment.Equipments.Remove(sourceRoomEquipment.Equipments.Single(r => r.Id == sourceEquipment.Id));
                        _roomEquipmentRepo.Update(sourceRoomEquipment);
                    }
                    else
                    {
                        sourceRoomEquipment.Equipments.Single(r => r.Id == sourceEquipment.Id).Quantity = sourceEquipment.Quantity;
                        _roomEquipmentRepo.Update(sourceRoomEquipment);
                    }

                    if (destEquipment != null)
                    {
                        destEquipment.Quantity += activeTerm.QuantityOfEquipment;
                        destRoomEquipment.Equipments.Single(r => r.Id == destEquipment.Id).Quantity = destEquipment.Quantity;
                        _roomEquipmentRepo.Update(destRoomEquipment);
                    }
                    else
                    {
                        destEquipment = new Equipment(sourceEquipment);
                        destEquipment.RoomEquipmentId = activeTerm.IdDestinationRoom;
                        destEquipment.Quantity = activeTerm.QuantityOfEquipment;
                        destRoomEquipment.Equipments.Add(destEquipment);
                        _roomEquipmentRepo.Update(destRoomEquipment);
                    }

                }
            }
        }
    }
}
