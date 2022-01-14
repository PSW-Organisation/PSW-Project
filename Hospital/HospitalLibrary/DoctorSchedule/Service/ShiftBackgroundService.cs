using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HospitalLibrary.DoctorSchedule.Repository;
using HospitalLibrary.DoctorSchedule.Service;
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
    public class ShiftBackgroundService : BackgroundService
    {
        private IServiceScopeFactory _scopeFactory;

        public ShiftBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                UpdateCurrentDoctorShift();
                await Task.Delay(1 * 1000, stoppingToken);
                //await Task.Delay(7 * 24 * 60 * 60 * 1000, stoppingToken);
            }
        }

        private void UpdateCurrentDoctorShift()
        {
            using var scope = _scopeFactory.CreateScope();
            var shiftService = scope.ServiceProvider.GetRequiredService<IShiftService>();
            shiftService.UpdateCurrentDoctorShift();
        }
    }
}
