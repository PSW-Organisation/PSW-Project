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
        
        public MedicineService(MedicineRepository medicineRepository, IPharmacyService pharmacyService)
        {
            this.medicineRepository = medicineRepository;
            this.pharmacyService = pharmacyService;
        }

        public void SetMedicine(Medicine medicine)
        {
            medicineRepository.Update(medicine);
        }

        public void AddMedicine(Medicine medicine)
        {
            medicine.Id = medicineRepository.GenerateId();
            medicineRepository.Save(medicine);
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

            return pharmacies;
        }

        public Medicine GetMedicineByName(string name)
        {
            return this.medicineRepository.GetMedicineByName(name);
        }
    }
}
