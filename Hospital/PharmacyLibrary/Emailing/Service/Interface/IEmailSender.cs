using PharmacyLibrary.Emailing.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLibrary.Emailing.Service.Interface
{
    public interface IEmailSender
    {
        Task SendEmail(Message message);
    }
}
