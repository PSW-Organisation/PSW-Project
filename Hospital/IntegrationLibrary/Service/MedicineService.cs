using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace IntegrationLibrary.Service
{
    public class MedicineService : IMedicineService
    {
        private MedicineRepository medicineRepository;
        private IPharmacyService pharmacyService;
        private IMedicineTransactionService transactionService;
        
        public MedicineService(MedicineRepository medicineRepository, IPharmacyService pharmacyService, IMedicineTransactionService transactionService)
        {
            this.medicineRepository = medicineRepository;
            this.pharmacyService = pharmacyService;
            this.transactionService = transactionService;
        }

        public void SetMedicine(Medicine medicine)
        {
            medicineRepository.Update(medicine);
        }
      
        public Medicine AddMedicine(Medicine medicine)
        {
            Medicine existingMedicine = GetMedicineByName(medicine.Name);
            if (existingMedicine == null)
            {
               return  addIfMedicineNotExist(medicine);
               
            }
            else
            {
               return IfMedicineExist(medicine, existingMedicine);
            }
        }

        private Medicine IfMedicineExist(Medicine medicine, Medicine existing)
        {
            existing.MedicineAmmount = existing.MedicineAmmount + medicine.MedicineAmmount;
            this.SetMedicine(existing);
            MedicineTransaction transaction = new MedicineTransaction(0, existing.Id, medicine.MedicineAmmount, DateTime.Now);
            transactionService.Save(transaction);
            return null; 
        }

        private Medicine addIfMedicineNotExist(Medicine medicine)
        {
            medicine.Id = medicineRepository.GenerateId();
            medicineRepository.Save(medicine);
            MedicineTransaction transaction = new MedicineTransaction(0, medicine.Id, medicine.MedicineAmmount, DateTime.Now);
            transactionService.Save(transaction);
            return medicine;
        }

        public void SetMedicineIngredients(Medicine medicine, List<MedicineIngredient> medicineIngredients)
        {
            foreach (MedicineIngredient ingredient in medicineIngredients)
            {
                medicine.AddMedicineIngredient(ingredient.Name);
            }
            //medicine.MedicineIngredient = medicineIngredients;
            medicineRepository.Update(medicine);
        }

        public List<Medicine> GetAllMedicine()
        {
            return medicineRepository.GetAll();
        }

        
        public void AddMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient)
        {
            medicine.MedicineIngredient.Add(medicineIngredient.Name);
            medicineRepository.Update(medicine);
        }

        public void RemoveMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient)
        {
            foreach(string mi in medicine.MedicineIngredient)
            {
                if (mi.Equals(medicineIngredient.Name))
                {
                    medicine.MedicineIngredient.Remove(mi);
                    break;
                }
            }
            medicineRepository.Update(medicine);
        }

        public void DeleteMedicine(Medicine medicine)
        {
            medicineRepository.Delete(medicine);
        }

        public Medicine GetMedicine(int id)
        {
            return medicineRepository.Get(id);
        }

        public List<Pharmacy> searchMedicine(string medicineName, int medicineAmount)
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();
          
            foreach(Pharmacy pharmacy in pharmacyService.GetAll())
            {
                if (pharmacy.CommunicationType == PharmacyCommunicationType.HTTP)
                {
                    var client = new RestSharp.RestClient(pharmacy.PharmacyUrl);
                    var request = new RestRequest("/api3/medicine/" + pharmacy.HospitalApiKey);
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

        public Medicine GetMedicineByName(string name)
        {
            return this.medicineRepository.GetMedicineByName(name);
        }

        public PharmacyCommunicationType checkCommunicationType(string apiKey)
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            PharmacyCommunicationType ret = PharmacyCommunicationType.UNDECLARED;
            foreach (Pharmacy pharmacy in pharmacyService.GetAll())
            {
                if (pharmacy.HospitalApiKey.Equals(apiKey))
                   ret = pharmacy.CommunicationType;
            }
            return ret;
        }

        public bool checkIfMedicineExistsHTTP(MedicineSearch medicineSearch)
        {
            Pharmacy pharmacy = getPharmacyByApi(medicineSearch.ApiKey);
            var client = new RestSharp.RestClient(pharmacy.PharmacyUrl);
            var request = new RestRequest("/api3/medicine/" + pharmacy.HospitalApiKey);
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
                if (pharmacy.HospitalApiKey.Equals(apiKey))
                    return pharmacy;
            }
            return null;
        }

        public bool orderMedicineHTTP(MedicineSearch medicineSearch)
        {
            Pharmacy pharmacy = getPharmacyByApi(medicineSearch.ApiKey);
            var client = new RestSharp.RestClient(pharmacy.PharmacyUrl);
            var request = new RestRequest("/api3/medicine/" + pharmacy.HospitalApiKey);
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
    }
}
