using ehealthcare.Model;
using HospitalLibrary.MedicalRecord.Repository;
using HospitalLibrary.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void SendEmail(string recipientEmail)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(recipientEmail, "Request for Verification"));
            mm.From = new MailAddress("leanonhospital@gmail.com");
            mm.Body = $"<a href=\"http://localhost:4200/verification?token={Guid.NewGuid()}\">Click here to verify</a>";
            mm.IsBodyHtml = true;
            mm.Subject = "Verification";
            SmtpClient smcl = new SmtpClient();
            smcl.Host = "smtp.gmail.com";
            smcl.Port = 587;
            smcl.Credentials = new NetworkCredential("leanonhospital@gmail.com", "pswfirma5");
            smcl.EnableSsl = true;
            smcl.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smcl.Send(mm);
            }
            catch (SmtpException e)
            {
                Console.WriteLine("Error: {0}", e.StatusCode);
            }
           
        }
    }
}
