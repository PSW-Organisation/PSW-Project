using DinkToPdf;
using DinkToPdf.Contracts;
using IntegrationAPI.DTO;
using IntegrationAPI.Service;
using IntegrationAPI.Utility;
using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Service.ServiceInterfaces;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Service.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRCoder;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IConverter _converter;
        private IMedicineOrderService medicineService;

        public PrescriptionController(IConverter _converter, IMedicineOrderService medicineService)
        {
            this._converter = _converter;
            this.medicineService = medicineService;
        }

        [HttpPost]
        public IActionResult Add(PrescriptionDTO prescription)
        {
            if (prescription.DoctorId.Length <= 0 || prescription.MedicineId.Length <= 0 || prescription.PatientId.Length <= 0)
                return BadRequest();

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(JsonConvert.SerializeObject(prescription), QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            var bitmap = code.GetGraphic(5);
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage);

            var globalSettings = new GlobalSettings
            {
                ColorMode = DinkToPdf.ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
                //Out = @"D:\PDFCreator\Medicine_Report.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(prescription, SigBase64),
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
            var fileName = prescription.PatientId + " " + prescription.PrescriptionDate.ToString("dd-M-yyyy") + ".pdf";
            var serverFile = @"\pharmacy\" + fileName;
            SftpService sftpService = new SftpService(new SftpConfig("192.168.56.1", "tester", "password"));

            List<Pharmacy> pharmacies = new List<Pharmacy>();
            medicineService.searchMedicine(prescription.MedicineId, 1).ForEach(pharmacy => pharmacies.Add(pharmacy));

            sftpService.UploadFile(file, serverFile);

            foreach (var pharmacy in pharmacies)
            {
                if(pharmacy.PharmacyCommunicationType == PharmacyCommunicationType.SFTP)
                {
                    var client = new RestClient(pharmacy.PharmacyUrl);
                    var request = new RestRequest("/report/" + fileName, Method.GET);
                    var cancellationTokenSource = new CancellationTokenSource();
                    client.ExecuteAsync(request, cancellationTokenSource.Token);
                }
                else if(pharmacy.PharmacyCommunicationType == PharmacyCommunicationType.HTTP)
                {
                    var client = new RestClient(pharmacy.PharmacyUrl);
                    var request = new RestRequest("/report", Method.POST);
                    request.AddFile("file", file, fileName);
                    var cancellationTokenSource = new CancellationTokenSource();
                    client.ExecuteAsync(request, cancellationTokenSource.Token);
                }
            }
            return Ok();
        }
    }
}
