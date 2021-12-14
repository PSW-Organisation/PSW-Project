using DinkToPdf;
using DinkToPdf.Contracts;
using IntegrationAPI.DTO;
using IntegrationAPI.Service;
using IntegrationAPI.Utility;
using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service;
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
        private IMedicineConsumptionService consumptionService;
  

        public PdfCreatorController(IConverter converter, IMedicineConsumptionService consumptionService)
        {
            _converter = converter;
            this.consumptionService = consumptionService;
        }

        [HttpPost]
        public IActionResult Upload(TimeRangeDTO dto)
        {
            var consumption = consumptionService.GetMedicineConsumptionForDates(dto.StartTime, dto.EndTime);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
              //  Out = @"D:\PDFCreator\Medicine_Report.pdf"
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
            var serverFile = @"\pharmacy\" + fileName;
            // SftpService sftpService = new SftpService(new SftpConfig("192.168.1.5", "tester", "password")); //kod Nevene
            SftpService sftpService = new SftpService(new SftpConfig("192.168.56.1", "tester", "password"));
            if (sftpService.UploadFile(file, serverFile)) {
            
                return Ok(fileName); }
         
            return BadRequest();
        }
    }
}
