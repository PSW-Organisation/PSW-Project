using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IUserService
    {
        public void SendEmail(string recipientEmail);

    }
}
