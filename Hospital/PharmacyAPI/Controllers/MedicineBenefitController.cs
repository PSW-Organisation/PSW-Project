using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmacyAPI.Adapter;
using PharmacyAPI.DTO;
using PharmacyLibrary.Service;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("api3/[controller]")]
    public class MedicineBenefitController : ControllerBase
    {
        private readonly IMedicineBenefitService medicineBenefitService;
        private readonly IPharmacyService pharmacyService;

        public MedicineBenefitController(IMedicineBenefitService medicineBenefitService, IPharmacyService pharmacyService)
        {
            this.medicineBenefitService = medicineBenefitService;
            this.pharmacyService = pharmacyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<MedicineBenefitDto> medicineBenefitDtos = new List<MedicineBenefitDto>();
            medicineBenefitService.Get().ToList().ForEach(medicineBenefit => medicineBenefitDtos.Add(MedicineBenefitAdapter.MedicineBenefitToMedicineBenefitDto(medicineBenefit)));
            return Ok(medicineBenefitDtos);
        }

        [HttpPost]
        public IActionResult Add(MedicineBenefitDto dto)
        {
            Pharmacy pharmacy =  pharmacyService.Get(1);
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "medicineBenefitsQueue/" + "52dcaa9d-5f3a-411d-a79a-ff826d4fa0d9",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

                string message = "Id: " + dto.MedicineBenefitId +
                                 ", MedicineBenefitTitle: " + dto.MedicineBenefitTitle +
                                 ", MedicineBenefitContent: " + dto.MedicineBenefitContent +
                                 ", MedicineBenefitDueDate: " + dto.MedicineBenefitDueDate +
                                 ", MedicineId: " + dto.MedicineId;
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto));
                channel.BasicPublish(
                    exchange: "",
                    routingKey: "medicineBenefitsQueue/" + pharmacy.PharmacyApiKey,
                    basicProperties: null,
                    body: body

                    );
            }
            return Ok(medicineBenefitService.Add(MedicineBenefitAdapter.MedicineBenefitDtoToMedicineBenefit(dto)));
        }


    }
}
