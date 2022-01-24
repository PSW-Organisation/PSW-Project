using Grpc.Core;
using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationAPI.GlobalErrorHandling.Model;
using IntegrationAPI.Protos;
using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Service.ServiceInterfaces;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;
using IntegrationLibrary.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class MedicineOrderController : ControllerBase
    {
        private IMedicineOrderService medicineService;
        private IPharmacyService pharmacyService;

        public MedicineOrderController(IMedicineOrderService medicineService, IPharmacyService pharmacyService)
        {
            this.medicineService = medicineService;
            this.pharmacyService = pharmacyService;
          
        }

        [HttpPost]   
        public IActionResult Add(MedicineDTO dto)
        {
            if (dto.MedicineName.Length <= 0 || dto.MedicineAmount <= 0)
            {
                return BadRequest();
            }

            medicineService.AddMedicine(MedicineAdapter.MedicineDtoToMedicine(dto));
            return Ok();

        }

        [HttpPut("{order}")]
        public IActionResult Put(MedicineSearchDTO dto)

        {
            //throw new CustomMessageException("Zasto je ovo unhandled");
            if (medicineService.checkCommunicationType(dto.ApiKey) == PharmacyCommunicationType.HTTP)
            {
                return Ok(medicineService.orderMedicineHTTP(MedicineSearchAdapter.MedicineSearchDtoToMedicineSearch(dto)));
            }
            else
            {
                return Ok(orderMedicineGRPC(dto));
            }
        }


        [HttpGet("{medicineName}/{medicineAmount}")]
        public IActionResult SearchMedicine(string medicineName, int medicineAmount)
        {
            List<PharmacyDto> result = new List<PharmacyDto>();
            if (medicineName.Equals("") || medicineAmount <= 0)
            {
                return BadRequest();
            }
            medicineService.searchMedicine(medicineName, medicineAmount).ForEach(pharmacy => result.Add(PharmacyAdapter.PharmacyToPharmacyDto(pharmacy)));
            searchMedicineGRPC(medicineName, medicineAmount).ForEach(pharmacy => result.Add(PharmacyAdapter.PharmacyToPharmacyDto(pharmacy)));
            return Ok(result);
        }

        private List<Pharmacy> searchMedicineGRPC(string medicineName, int medicineAmount)
        {
            List<Pharmacy> ret = new List<Pharmacy>();
            foreach (Pharmacy pharmacy in pharmacyService.GetAll())
            {
                if (pharmacy.PharmacyCommunicationType == PharmacyCommunicationType.GRPC)
                {
                    checkIfPharmacyHasMedicine(medicineName, medicineAmount, ret, pharmacy);
                }
            }
            return ret;
        }

        [HttpPut]
        public IActionResult checkIfMedicineExists(MedicineSearchDTO dto)
        {
            if (medicineService.checkCommunicationType(dto.ApiKey) == PharmacyCommunicationType.HTTP)
            {
                return Ok(medicineService.checkIfMedicineExistsHTTP(MedicineSearchAdapter.MedicineSearchDtoToMedicineSearch(dto)));
            }
            else
            {
                return Ok(checkIfMedicineExistsGRPC(dto));
            }
        }

        private static void checkIfPharmacyHasMedicine(string medicineName, int medicineAmount, List<Pharmacy> ret, Pharmacy pharmacy)
        {
            MedicineOrderRequest input;
            OrderMedicineGRPCService.OrderMedicineGRPCServiceClient client;
            GRPCSendRequest(medicineName, medicineAmount, pharmacy, out input, out client);
            if (client.checkIfMedicineExists(input).Response)
            {
                ret.Add(pharmacy);
            }
        }

        private static void GRPCSendRequest(string medicineName, int medicineAmount, Pharmacy pharmacy, out MedicineOrderRequest input, out OrderMedicineGRPCService.OrderMedicineGRPCServiceClient client)
        {
            input = new MedicineOrderRequest { MedicineName = medicineName, MedicineAmount = medicineAmount, ApiKey = pharmacy.HospitalApiKey };
            var channel = new Grpc.Core.Channel(pharmacy.PharmacyUrl, ChannelCredentials.Insecure);
            client = new OrderMedicineGRPCService.OrderMedicineGRPCServiceClient(channel);
        }

        public bool checkIfMedicineExistsGRPC(MedicineSearchDTO dto)
        {
            MedicineOrderRequest input;
            OrderMedicineGRPCService.OrderMedicineGRPCServiceClient client;
            GRPCSendRequestCheckIfExists(dto, out input, out client);
            var reply = client.checkIfMedicineExists(input);
            return reply.Response;
        }

        private void GRPCSendRequestCheckIfExists(MedicineSearchDTO dto, out MedicineOrderRequest input, out OrderMedicineGRPCService.OrderMedicineGRPCServiceClient client)
        {
            Pharmacy pharmacy = pharmacyService.getPharmacyByApiKey(dto.ApiKey);
            input = new MedicineOrderRequest { MedicineName = dto.MedicineName, MedicineAmount = dto.MedicineAmount, ApiKey = dto.ApiKey };
            var channel = new Channel(pharmacy.PharmacyUrl, ChannelCredentials.Insecure);
            client = new OrderMedicineGRPCService.OrderMedicineGRPCServiceClient(channel);
        }

        private bool orderMedicineGRPC(MedicineSearchDTO dto)
        {
            MedicineOrderRequest input;
            OrderMedicineGRPCService.OrderMedicineGRPCServiceClient client;
            GRPCSendRequestOrder(dto, out input, out client);
            return client.orderMedicine(input).Response;
        }

        private void GRPCSendRequestOrder(MedicineSearchDTO dto, out MedicineOrderRequest input, out OrderMedicineGRPCService.OrderMedicineGRPCServiceClient client)
        {
            Pharmacy pharmacy = pharmacyService.getPharmacyByApiKey(dto.ApiKey);
            input = new MedicineOrderRequest { MedicineName = dto.MedicineName, MedicineAmount = dto.MedicineAmount, ApiKey = dto.ApiKey };
            var channel = new Channel(pharmacy.PharmacyUrl, ChannelCredentials.Insecure);
            client = new OrderMedicineGRPCService.OrderMedicineGRPCServiceClient(channel);
        }
    }
}
