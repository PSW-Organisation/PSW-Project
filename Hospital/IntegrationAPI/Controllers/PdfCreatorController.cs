using DinkToPdf;
using DinkToPdf.Contracts;
using IntegrationAPI.DTO;
using IntegrationAPI.Utility;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{startTime}/{endTime}")]
        public IActionResult CreatePDF(DateTime startTime, DateTime endTime)
        {
            var consumption = getMedicineConsumption(startTime, endTime);

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
                HtmlContent = TemplateGenerator.GetHTMLString(startTime, endTime, consumption),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "style.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings}
            };

            var file = _converter.Convert(pdf);

            return File(file, "application/pdf", "MedicineReport.pdf");
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
