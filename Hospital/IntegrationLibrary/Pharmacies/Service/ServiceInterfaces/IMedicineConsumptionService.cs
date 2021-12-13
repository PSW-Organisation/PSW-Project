using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Service.ServiceInterfaces
{
    public interface IMedicineConsumptionService
    {
        public List<MedicineConsumption> GetMedicineConsumptionForDates(DateTime startTime, DateTime endTime);
    }
}
