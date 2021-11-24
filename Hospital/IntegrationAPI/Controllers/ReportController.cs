using IntegrationAPI.Service;
using IntegrationAPI.Utility;
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
            SftpService sftpService = new SftpService(new SftpConfig("192.168.56.1", "tester", "password"));
            var folderName = Path.Combine("Resources", "Reports");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var localFile = Path.Combine(pathToSave, fileName);
            string serverFile = @"\hospital\" + fileName;
            if (sftpService.DownloadFile(serverFile, localFile))
                return Ok();
            return BadRequest();
        }
    }
}
