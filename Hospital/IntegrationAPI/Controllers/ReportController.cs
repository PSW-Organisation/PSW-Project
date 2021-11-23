using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("{fileName?}")]
        public IActionResult Download(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();

                var folderName = Path.Combine("Resources", "Reports");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var localFile = Path.Combine(pathToSave, fileName);

                string serverFile = @"\hospital\" + fileName;
                using (Stream stream = System.IO.File.OpenWrite(localFile))
                {
                    client.DownloadFile(serverFile, stream, x => Console.WriteLine(x));
                }

                client.Disconnect();
            }
            return Ok();
        }
    }
}
