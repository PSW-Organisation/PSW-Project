using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IMedicineConsumptionService
    {
        public List<MedicineConsumption> GetMedicineConsumptionForDates(DateTime startTime, DateTime endTime);
    }
}
