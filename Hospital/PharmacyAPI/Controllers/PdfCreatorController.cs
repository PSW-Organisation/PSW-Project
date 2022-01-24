using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Model;
using PharmacyAPI.Service;
using PharmacyAPI.Utility;
using PharmacyLibrary.Service;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api3/[controller]")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private readonly IConverter _converter;
        private IMedicineService medicineService;

        public PdfCreatorController(IConverter converter, IMedicineService medicineService)
        {
            _converter = converter;
            this.medicineService = medicineService;
        }

        [HttpGet("{name?}")]
        public IActionResult Upload(string name)
        {
            Medicine medicine = null;
            foreach (var med in medicineService.Get())
            {
                if (med.Name.Equals(name))
                {
                    medicine = med;
                }
            }
            if (medicine == null)
            {
                return BadRequest();
            }

            byte[] file = CreateMedicinePDF(medicine);
            var fileName = name + ".pdf";
            var serverFile = @"\hospital\" + fileName;
            // SftpService sftpService = new SftpService(new SftpConfig("192.168.1.5", "tester", "password"));   //kod Nevene
            SftpService sftpService = new SftpService(new SftpConfig("192.168.56.1", "tester", "password"));
            if (sftpService.UploadFile(file, serverFile))
                return Ok(fileName);
            return BadRequest();
        }

        private byte[] CreateMedicinePDF(Medicine medicine)
        {
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
                HtmlContent = TemplateGenerator.GetHTMLString(medicine),
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
            return file;
        }
    }
}
