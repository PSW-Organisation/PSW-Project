using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using HospitalLibrary.MedicalRecords.Model;

namespace HospitalLibrary.MedicalRecords.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void Register(Patient patient, List<Allergen> allergens)
        {
            _patientRepository.Insert(patient);
            _patientRepository.MapPatientAllergens(patient, allergens);
        }

        public void SendEmail(string recipientEmail, Guid token)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(recipientEmail, "Request for Verification"));
            mm.From = new MailAddress("leanonhospital@gmail.com");
            mm.Body = $"<a href=\"http://localhost:4200/verification?token={token}\">Click here to verify</a>";
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

        public int Activate(Guid guid)
        {
            return _patientRepository.Activate(guid);
        }
    }
}

