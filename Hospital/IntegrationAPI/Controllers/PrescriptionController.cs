using DinkToPdf;
using DinkToPdf.Contracts;
using IntegrationAPI.DTO;
using IntegrationAPI.Service;
using IntegrationAPI.Utility;
using IntegrationLibrary.Service.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IConverter _converter;
        private IMedicineService medicineService;

        public PrescriptionController(IConverter _converter, IMedicineService medicineService)
        {
            this._converter = _converter;
            this.medicineService = medicineService;
        }

        [HttpPost]
        public IActionResult Add(PrescriptionDTO prescription)
        {
            if (prescription.DoctorId.Length <= 0 || prescription.MedicineId.Length <= 0 || prescription.PatientId.Length <= 0)
                return BadRequest();
            //prescription.PrescriptionDate = DateTime.Now;


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
                HtmlContent = TemplateGenerator.GetHTMLString(prescription),
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
            var fileName = prescription.PatientId + "_" + prescription.PrescriptionDate.ToString("dd-M-yyyy") + ".pdf";
            var serverFile = @"\pharmacy\" + fileName;
            SftpService sftpService = new SftpService(new SftpConfig("192.168.56.1", "tester", "password"));
            if (sftpService.UploadFile(file, serverFile))
            {
                List<string> pharmacyUrls = new List<string>();
                medicineService.searchMedicine(prescription.MedicineId, 1).ForEach(pharmacy => pharmacyUrls.Add(pharmacy.PharmacyUrl));
                
                foreach(var url in pharmacyUrls)
                {
                    var client = new RestClient(url);
                    var request = new RestRequest("/report/" + fileName, Method.GET);
                    var cancellationTokenSource = new CancellationTokenSource();
                    client.ExecuteAsync(request, cancellationTokenSource.Token);
                }

                return Ok(fileName);
            }
            return BadRequest();
        }
    }
}
