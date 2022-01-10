using Grpc.Core;
using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
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
            if (medicineService.checkCommunicationType(dto.ApiKey) == PharmacyCommunicationType.HTTP)
            {
                return Ok(medicineService.orderMedicineHTTP(MedicineSearchAdapter.MedicineSearchDtoToMedicineSearch(dto)));
            }
            else
            {
                return Ok(orderMedicineGRPC(dto));
            }
        }

        private bool orderMedicineGRPC(MedicineSearchDTO dto)
        {
            bool response = false;
            Pharmacy pharmacy = pharmacyService.getPharmacyByApiKey(dto.ApiKey);
            var input = new MedicineOrderRequest { MedicineName = dto.MedicineName, MedicineAmount = dto.MedicineAmount, ApiKey = dto.ApiKey };
            var channel = new Channel(pharmacy.PharmacyComunicationInfo.PharmacyUrl, ChannelCredentials.Insecure);
            var client = new OrderMedicineGRPCService.OrderMedicineGRPCServiceClient(channel);
            var reply = client.orderMedicine(input);
            response = reply.Response;
            return response;
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
                if (pharmacy.PharmacyComunicationInfo.PharmacyCommunicationType == PharmacyCommunicationType.GRPC)
                {
                    bool response = false;
                    var input = new MedicineOrderRequest { MedicineName = medicineName, MedicineAmount = medicineAmount, ApiKey = pharmacy.PharmacyComunicationInfo.HospitalApiKey };
                    var channel = new Grpc.Core.Channel(pharmacy.PharmacyComunicationInfo.PharmacyUrl, ChannelCredentials.Insecure);
                    var client = new OrderMedicineGRPCService.OrderMedicineGRPCServiceClient(channel);
                    var reply = client.checkIfMedicineExists(input);
                    response = reply.Response;
                    if (response)
                    {
                        ret.Add(pharmacy);
                    }
                }
            }
            return ret;
        }

        [HttpPut]
        public IActionResult checkIfMedicineExists(MedicineSearchDTO dto)
        {
            if(medicineService.checkCommunicationType(dto.ApiKey) == PharmacyCommunicationType.HTTP)
            {
               return Ok(medicineService.checkIfMedicineExistsHTTP(MedicineSearchAdapter.MedicineSearchDtoToMedicineSearch(dto)));
            } else {
                return Ok(checkIfMedicineExistsGRPC(dto));
            }
        }

        public bool checkIfMedicineExistsGRPC(MedicineSearchDTO dto)
        {
            bool response = false;
            Pharmacy pharmacy = pharmacyService.getPharmacyByApiKey(dto.ApiKey);
            var input = new MedicineOrderRequest { MedicineName = dto.MedicineName, MedicineAmount = dto.MedicineAmount, ApiKey = dto.ApiKey };
            var channel = new Channel(pharmacy.PharmacyComunicationInfo.PharmacyUrl, ChannelCredentials.Insecure);
            var client = new OrderMedicineGRPCService.OrderMedicineGRPCServiceClient(channel);
            var reply = client.checkIfMedicineExists(input);

            response = reply.Response;

            return response;
        }
    }
}
