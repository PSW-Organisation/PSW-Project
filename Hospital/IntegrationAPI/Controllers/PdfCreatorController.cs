using DinkToPdf;
using DinkToPdf.Contracts;
using IntegrationAPI.DTO;
using IntegrationAPI.Utility;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private readonly IConverter _converter;
        private IMedicineTransactionService transactionService;
        private IMedicineService medicineService;

        public PdfCreatorController(IConverter converter, IMedicineTransactionService transactionService, IMedicineService medicineService)
        {
            _converter = converter;
            this.transactionService = transactionService;
            this.medicineService = medicineService;
        }

        [HttpPost]
        public IActionResult Upload(TimeRangeDTO dto)
        {
            var consumption = getMedicineConsumption(dto.StartTime, dto.EndTime);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
                //Out = @"D:\PDFCreator\Medicine_Report.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(dto.StartTime, dto.EndTime, consumption),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "style.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            var fileName = dto.StartTime.ToString("dd-M-yyyy") + "_" + dto.EndTime.ToString("dd-M-yyyy") + ".pdf";

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();

                using(Stream stream = new MemoryStream(file))
                {
                    client.UploadFile(stream, @"\pharmacy\" + fileName, x => { Console.WriteLine(x); });
                }

                    client.Disconnect();
            }

            return Ok(fileName);
        }

        public List<MedicineConsumption> getMedicineConsumption(DateTime startTime, DateTime endTime)
        {
            Dictionary<int, int> medicineCount = new Dictionary<int, int>();
            foreach (var transaction in transactionService.GetAll())
            {
                if (DateTime.Compare(transaction.TransactionTime, startTime) > 0 && DateTime.Compare(transaction.TransactionTime, endTime) < 0)
                {
                    if (medicineCount.ContainsKey(transaction.MedicineId))
                        medicineCount[transaction.MedicineId] += transaction.MedicineAmmount;
                    else
                        medicineCount[transaction.MedicineId] = transaction.MedicineAmmount;
                }
            }

            var consumption = new List<MedicineConsumption>();
            foreach (var temp in medicineCount)
            {
                var total = new MedicineConsumption(medicineService.GetMedicine(temp.Key).Name, temp.Value);
                consumption.Add(total);
            }
            return consumption;
        }
    }
}
