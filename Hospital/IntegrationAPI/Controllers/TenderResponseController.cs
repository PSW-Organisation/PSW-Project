using IntegrationLibrary.Emailing.Service;
using IntegrationLibrary.Emailing.Service.Interface;
using IntegrationLibrary.Emailing.Utility;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class TenderResponseController : ControllerBase
    {
        private ITenderResponseService tenderResponseService;
        private IEmailSender emailSender;

        public TenderResponseController(ITenderResponseService tenderResponseService, IEmailSender emailSender)
        {
            this.tenderResponseService = tenderResponseService;
            this.emailSender = emailSender;
        }

        [HttpGet("accept/{id?}")]
        public IActionResult AcceptOffer(int id)
        {
            TenderResponse tenderResponse = tenderResponseService.Get(id);
            if (tenderResponse == null)
            {
                return NotFound();
            }
            tenderResponse.IsWinner = true;
            Tender tender = tenderResponse.Tender;
            Pharmacy pharmacy = tenderResponse.Pharmacy;
            tender.ApiKeyPharmacy = pharmacy.PharmacyApiKey;
            tenderResponseService.Update(tenderResponse);
            var client = new RestClient(pharmacy.PharmacyUrl);
            var request = new RestRequest("/tender/accept/" + tender.Id, Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();
            client.ExecuteAsync(request, cancellationTokenSource.Token);
            var message = new Message(new string[] { pharmacy.Email }, "Tender", "Your tender offer was accepted.");
            emailSender.SendEmail(message);
            foreach (TenderResponse response in tender.TenderResponses) {
                Pharmacy pharm = response.Pharmacy;
                if (pharm.Id != pharmacy.Id) {
                    var declinedMessage = new Message(new string[] { pharm.Email }, "Tender", "Your tender offer was declined.");
                    emailSender.SendEmail(declinedMessage);
                }
            }
            return Ok();
        }
    }
}
