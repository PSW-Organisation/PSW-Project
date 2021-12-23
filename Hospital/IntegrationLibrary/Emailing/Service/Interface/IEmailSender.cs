using IntegrationLibrary.Emailing.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Emailing.Service.Interface
{
    public interface IEmailSender
    {
        Task SendEmail(Message message);
    }
}
