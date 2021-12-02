using System;
using System.Threading;
using System.Threading.Tasks;
using ehealthcare.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.RoomsAndEquipment.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class ScheduleBackgroundService : BackgroundService
    {
        private readonly RoomEquipmentRelocator _roomEquipmentRelocator;

        public ScheduleBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _roomEquipmentRelocator = new RoomEquipmentRelocator(scopeFactory);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _roomEquipmentRelocator.RelocateEquipment(stoppingToken);
        }
    }
}
