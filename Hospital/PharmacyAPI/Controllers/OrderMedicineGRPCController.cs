using System;
using System.Collections.Generic;
using System.Linq;
using Grpc.Core;
using System.Threading.Tasks;
using PharmacyAPI.Protos;
using PharmacyLibrary.Service;
using PharmacyLibrary.Repository.MedicineRepository;
using PharmacyAPI.Model;
using PharmacyLibrary.Repository.HospitalRepository;

namespace PharmacyAPI.Service
{
    public class OrderMedicineGRPCController : OrderMedicineGRPCService.OrderMedicineGRPCServiceBase
    {
        public override Task<MedicineOrderResponse> checkIfMedicineExists(MedicineOrderRequest request, ServerCallContext context)
        {
            MedicineService medicineService = new MedicineService(new MedicineRepository(new PharmacyDbContext()));
            HospitalService hospitalService = new HospitalService(new HospitalRepository(new PharmacyDbContext()));
            MedicineOrderResponse response = new MedicineOrderResponse();
          
            foreach (Hospital hospital in hospitalService.Get())
            {
                if (hospital.HospitalApiKey == request.ApiKey)
                {
                    response.Response = medicineService.CheckIfExists(request.MedicineName, (int)request.MedicineAmount);
                    return Task.FromResult(response);
                }
            }
            return null;
        }

        public override Task<MedicineOrderResponse> orderMedicine(MedicineOrderRequest request, ServerCallContext context)
        {
            MedicineService medicineService = new MedicineService(new MedicineRepository(new PharmacyDbContext()));
            HospitalService hospitalService = new HospitalService(new HospitalRepository(new PharmacyDbContext()));
            MedicineOrderResponse response = new MedicineOrderResponse();

            foreach (Hospital hospital in hospitalService.Get())
            {
                if (hospital.HospitalApiKey == request.ApiKey)
                {
                    response.Response = medicineService.reduceQuantityOfMedicine(request.MedicineName, (int)request.MedicineAmount);
                    return Task.FromResult(response);
                }
            }
            return null;
        }
    }
}
