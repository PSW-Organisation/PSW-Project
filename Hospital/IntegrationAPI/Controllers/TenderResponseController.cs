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
using System.Text;
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
            AlertWinningPharmacy(tender, pharmacy);
            SendEmailToWinningPharmacy(tenderResponse, pharmacy);
            SendEmailToDeclinedPharmacies(tender, pharmacy);
            return Ok();
        }

        private void SendEmailToWinningPharmacy(TenderResponse tenderResponse, Pharmacy pharmacy)
        {
            string body = CreateEmailBody(tenderResponse);
            var message = new Message(new string[] { pharmacy.Email }, "Tender", body);
            emailSender.SendEmail(message);
        }

        private void SendEmailToDeclinedPharmacies(Tender tender, Pharmacy pharmacy)
        {
            foreach (TenderResponse response in tender.TenderResponses)
            {
                Pharmacy pharm = response.Pharmacy;
                if (pharm.Id != pharmacy.Id)
                {
                    var declinedMessage = new Message(new string[] { pharm.Email }, "Tender", "Your tender offer was declined.");
                    emailSender.SendEmail(declinedMessage);
                }
            }
        }

        private static string CreateEmailBody(TenderResponse tenderResponse)
        {
            var sb = new StringBuilder();
            sb.Append(@"Your tender offer was accepted.");
            sb.AppendLine();
            sb.Append(@"Offer information:");
            sb.AppendLine();
            foreach (var item in tenderResponse.TenderItems)
            {
                sb.AppendFormat(@"{0} x {1} for {2}$", item.TenderItemName, item.TenderItemQuantity, item.TenderItemPrice);
                sb.AppendLine();
            }
            sb.AppendFormat(@"Offer total: {0}$", tenderResponse.TotalPrice);
            return sb.ToString();
        }

        private static void AlertWinningPharmacy(Tender tender, Pharmacy pharmacy)
        {
            var client = new RestClient(pharmacy.PharmacyUrl);
            var request = new RestRequest("/tender/accept/" + tender.Id, Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();
            client.ExecuteAsync(request, cancellationTokenSource.Token);
        }
    }
}
