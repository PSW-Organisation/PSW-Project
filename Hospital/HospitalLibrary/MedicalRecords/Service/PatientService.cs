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
            mm.Body = @"
                <!DOCTYPE html>
                        <html>
                        <head>
                        </head>
                        <style>
	                        h1 {
                          text-align: center;
                          font-family: Arial, Helvetica, sans-serif;
                        }
	                        p {
                          text-align: left;
                          font-family: Arial, Helvetica, sans-serif;
                        }
                        </style>
                        <body>
                            <div style=""display: -webkit-inline-box"">
                                <h1>Welcome to </h1>
                                <img style="" width: 50px; height: 50px; margin-top: 10px;"" src=""https://drive.google.com/uc?export=view&id=1DFaZu9VUArZUnnTFXkep77OIw4fhfyrb"" alt="""">
                                <h1><i>LeanOn Hospital</i>!</h1>
                            </div>
                            <p>Verify your account <a href=""http://localhost:4200/verification?token=" + token + @""">here</a> to use our services.</p>
                        </body>
                        </html> 
                ";
            mm.IsBodyHtml = true;
            mm.Subject = "LeanOn Hospital Account Verification";
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

        public Patient GetProfileData(string username)
        {
            return _patientRepository.Get(username);
        }

        public List<Patient> GetMaliciousPatients()
        {
            return _patientRepository.GetMaliciousPatients();
        }

        public void BlockPatient(Patient maliciousPatient)
        {
            maliciousPatient.IsBlocked = true;
            _patientRepository.Update(maliciousPatient);
        }

        public Patient GetUsingCredentials(string username, string password)
        {
           return _patientRepository.GetUsingCredentials(username, password);
        }
    }
}

