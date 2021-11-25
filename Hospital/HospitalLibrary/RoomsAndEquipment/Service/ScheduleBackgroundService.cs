using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using ehealthcare.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using HospitalLibrary.GraphicalEditor.Repository;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class ScheduleBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private RoomEquipmentRelocator _roomEquipmentRelocator;
        public ScheduleBackgroundService(IServiceScopeFactory scopeFactory)
        {
            this._serviceScopeFactory = scopeFactory;
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                //var dbContext = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
                //RelocationEquipmentRepository reloczationRepo = new RelocationEquipmentRepository(dbContext);
                //RoomEquipmentRepository roomEquipmentRepo = new RoomEquipmentRepository(dbContext);
                var relocationRepo = scope.ServiceProvider.GetRequiredService<IRelocationEquipmentRepository>();
                var roomEquipmentRepo = scope.ServiceProvider.GetRequiredService<IRoomEquipmentRepository>();
                _roomEquipmentRelocator = new RoomEquipmentRelocator(relocationRepo,roomEquipmentRepo);
            }

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _roomEquipmentRelocator.RelocateEquipment(stoppingToken);
        }
    }
}
