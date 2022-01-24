using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Parnership.Model;
using IntegrationLibrary.Parnership.Service.ServiceInterfaces;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;

namespace IntegrationLibrary.Parnership.Service.ServiceImpl
{
    public class MedicineOrderService : IMedicineOrderService
    {
        private IPharmacyService pharmacyService;
        private IMedicineTransactionService transactionService;
        
        public MedicineOrderService(IPharmacyService pharmacyService, IMedicineTransactionService transactionService)
        {
            this.pharmacyService = pharmacyService;
            this.transactionService = transactionService;
        }

        public Medicine AddMedicine(Medicine medicine)
        {
            Medicine newMedicine = this.SaveMedicine(medicine);
            MedicineTransaction transaction = new MedicineTransaction(0, newMedicine.Id, medicine.MedicineAmount, DateTime.Now);
            transactionService.Save(transaction);
            return medicine;
        }
       
        public List<Pharmacy> searchMedicine(string medicineName, int medicineAmount)
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            foreach(Pharmacy pharmacy in pharmacyService.GetAll())
            {
                if (pharmacy.PharmacyCommunicationType == PharmacyCommunicationType.HTTP || pharmacy.PharmacyCommunicationType == PharmacyCommunicationType.SFTP)
                {
                    if (checkIfExistsHTTP(medicineName, medicineAmount, pharmacy).Content.Equals("true"))
                    {
                        pharmacies.Add(pharmacy);
                    }
                }
            }
            return pharmacies;
        }

        public PharmacyCommunicationType checkCommunicationType(string apiKey)
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            foreach (Pharmacy pharmacy in pharmacyService.GetAll())
            {
                if (pharmacy.HospitalApiKey.Equals(apiKey))
                   return pharmacy.PharmacyCommunicationType;
            }
            return PharmacyCommunicationType.UNDECLARED;
        }

        private static IRestResponse checkIfExistsHTTP(string medicineName, int medicineAmount, Pharmacy pharmacy)
        {
            var client = new RestClient(pharmacy.PharmacyUrl);
            var request = new RestRequest("/medicine/" + pharmacy.HospitalApiKey);
            var values = new Dictionary<string, object>
                    {
                        {"medicineName", medicineName}, {"medicineAmount", medicineAmount}
                    };
            request.AddJsonBody(values);
            IRestResponse response = client.Post(request);
            return response;
        }

        public bool checkIfMedicineExistsHTTP(MedicineSearch medicineSearch)
        {
            Pharmacy pharmacy = getPharmacyByApi(medicineSearch.ApiKey);
            if (checkIfExistsHTTP(medicineSearch.MedicineName, medicineSearch.MedicineAmount, pharmacy).Content.Equals("true"))
                return true;
            else
                return false;
        }

        private Pharmacy getPharmacyByApi(object apiKey)
        {
            foreach (Pharmacy pharmacy in pharmacyService.GetAll())
            {
                if (pharmacy.HospitalApiKey.Equals(apiKey))
                    return pharmacy;
            }
            return null;
        }

        public bool orderMedicineHTTP(MedicineSearch medicineSearch)
        {
            Pharmacy pharmacy = getPharmacyByApi(medicineSearch.ApiKey);
            if (orderMedicineHTTP(medicineSearch, pharmacy).Content != null)
                return true;
            else
                return false;
        }

        private static IRestResponse orderMedicineHTTP(MedicineSearch medicineSearch, Pharmacy pharmacy)
        {
            var client = new RestSharp.RestClient(pharmacy.PharmacyUrl);
            var request = new RestRequest("/medicine/" + pharmacy.HospitalApiKey);
            var values = new Dictionary<string, object>
                {
                    {"medicineName", medicineSearch.MedicineName}, {"medicineAmount", medicineSearch.MedicineAmount}
                };
            request.AddJsonBody(values);
            IRestResponse response = client.Put(request);
            return response;
        }

        public Medicine SaveMedicine(Medicine medicine)
        {
            var client = new RestSharp.RestClient("http://localhost:42789");
            var request = new RestRequest("/api/medicine/");
            var values = new Dictionary<string, object>
                    {
                      {"Id", medicine.Id},{"MedicineName", medicine.MedicineName}, {"MedicineStatus", medicine.MedicineStatus },
                      {"MedicineAmount", medicine.MedicineAmount},  {"MedicineIngredient", medicine.MedicineIngredient}
                    };
            request.AddJsonBody(values);
            var response = client.Post<Medicine>(request);
            return response.Data;
        }
    }
}
