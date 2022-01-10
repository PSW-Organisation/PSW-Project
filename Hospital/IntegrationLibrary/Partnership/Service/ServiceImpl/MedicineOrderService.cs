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
                if (pharmacy.PharmacyComunicationInfo.PharmacyCommunicationType == PharmacyCommunicationType.HTTP || pharmacy.PharmacyComunicationInfo.PharmacyCommunicationType == PharmacyCommunicationType.SFTP)
                {
                    var client = new RestClient(pharmacy.PharmacyComunicationInfo.PharmacyUrl);
                    var request = new RestRequest("/medicine/" + pharmacy.PharmacyComunicationInfo.HospitalApiKey);
                    var values = new Dictionary<string, object>
                    {
                        {"medicineName", medicineName}, {"medicineAmount", medicineAmount}
                    };
                    request.AddJsonBody(values);
                    IRestResponse response = client.Post(request);
                    if (response.Content.Equals("true"))
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
            PharmacyCommunicationType ret = PharmacyCommunicationType.UNDECLARED;
            foreach (Pharmacy pharmacy in pharmacyService.GetAll())
            {
                if (pharmacy.PharmacyComunicationInfo.HospitalApiKey.Equals(apiKey))
                   ret = pharmacy.PharmacyComunicationInfo.PharmacyCommunicationType;
            }
            return ret;
        }

        public bool checkIfMedicineExistsHTTP(MedicineSearch medicineSearch)
        {
            Pharmacy pharmacy = getPharmacyByApi(medicineSearch.ApiKey);
            var client = new RestSharp.RestClient(pharmacy.PharmacyComunicationInfo.PharmacyUrl);
            var request = new RestRequest("/medicine/" + pharmacy.PharmacyComunicationInfo.HospitalApiKey);
            var values = new Dictionary<string, object>
                {
                    {"medicineName", medicineSearch.MedicineName}, {"medicineAmount", medicineSearch.MedicineAmount}
                };
            request.AddJsonBody(values);
            IRestResponse response = client.Post(request);
            if (response.Content.Equals("true"))
                return true;
            else
                return false;
        }

        private Pharmacy getPharmacyByApi(object apiKey)
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();

            foreach (Pharmacy pharmacy in pharmacyService.GetAll())
            {
                if (pharmacy.PharmacyComunicationInfo.HospitalApiKey.Equals(apiKey))
                    return pharmacy;
            }
            return null;
        }

        public bool orderMedicineHTTP(MedicineSearch medicineSearch)
        {
            Pharmacy pharmacy = getPharmacyByApi(medicineSearch.ApiKey);
            var client = new RestSharp.RestClient(pharmacy.PharmacyComunicationInfo.PharmacyUrl);
            var request = new RestRequest("/medicine/" + pharmacy.PharmacyComunicationInfo.HospitalApiKey);
            var values = new Dictionary<string, object>
                {
                    {"medicineName", medicineSearch.MedicineName}, {"medicineAmount", medicineSearch.MedicineAmount}
                };
            request.AddJsonBody(values);
            IRestResponse response = client.Put(request);
            if (response.Content != null)
                return true;
            else
                return false;
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
            Medicine content = response.Data;
            return content;
        }
    }
}
