using IntegrationAPI.Service;
using IntegrationAPI.Utility;
using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
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
        

        public ReportController()
        {
   
        }


        [HttpGet("{fileName?}")]
        public IActionResult Download(string fileName)
        {

            SftpService sftpService = new SftpService(new SftpConfig("192.168.1.5", "tester", "password")); //kod nevene
           // SftpService sftpService = new SftpService(new SftpConfig("192.168.56.1", "tester", "password"));
            var folderName = Path.Combine("Resources", "Reports");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var localFile = Path.Combine(pathToSave, fileName);
            string serverFile = @"\hospital\" + fileName;
        
            if (sftpService.DownloadFile(serverFile, localFile))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllFileNames()
        {
            var folderName = Path.Combine("Resources", "Reports");
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            DirectoryInfo d = new DirectoryInfo(fullPath);

            FileInfo[] Files = d.GetFiles("*.pdf"); //Getting Text files
            string str = "";

            var result = new List<string>();
            foreach (FileInfo file in Files)
            {
              
                result.Add(file.Name);
            }
          
            return Ok(result);
        }

        [HttpGet]
        [Route("pdf/{fileName?}")]
        public IActionResult GetReport(string fileName)
        {
            if (fileName == null)
                return BadRequest();
            var folderName = Path.Combine("Resources", "Reports");
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var localFile = Path.Combine(fullPath, fileName);
            Stream stream = System.IO.File.OpenRead(localFile);

            var binaryFile = ReadFully(stream);
            return File(binaryFile, "application/pdf");
        }

        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
