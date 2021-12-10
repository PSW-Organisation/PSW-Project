using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class MedicineController
	{
		private IMedicineOrderService medicineService;

		public MedicineController(IMedicineOrderService medicineService)
		{
            this.medicineService = medicineService;
		}


        public void AddMedicine(Medicine medicine)
        {
            medicineService.AddMedicine(medicine);
        }
    }
}
