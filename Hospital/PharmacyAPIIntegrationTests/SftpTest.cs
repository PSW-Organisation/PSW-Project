using PharmacyAPI.Service;
using PharmacyAPI.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace PharmacyAPIIntegrationTests
{
    public class SftpTest
    {
        private bool skippable = Environment.GetEnvironmentVariable("SkippableTest") != null;

        [SkippableFact]
        public void Upload_file()
        {
            Skip.If(skippable);
            var fileName = "test.txt";
            var localDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("bin", "Data");
            var localFile = Path.Combine(localDir, fileName);
            string serverFile = @"\test\" + fileName;

            Stream stream = File.OpenRead(localFile);

            var binaryFile = ReadFully(stream);

            var sftpService = new SftpService(new SftpConfig("192.168.56.1", "tester", "password"));
            // var sftpService = new SftpService(new SftpConfig("192.168.1.5", "tester", "password"));
            bool success = sftpService.UploadFile(binaryFile, serverFile);
            Assert.True(success);
        }

        [SkippableFact]
        public void Dowload_file()
        {
            Skip.If(skippable);
            var fileName = "test.txt";
            var localDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("bin", "Data");
            var localFile = Path.Combine(localDir, fileName);

            string serverFile = @"\test\" + fileName;
            var sftpService = new SftpService(new SftpConfig("192.168.56.1", "tester", "password"));
            // var sftpService = new SftpService(new SftpConfig("192.168.1.5", "tester", "password"));
            bool success = sftpService.DownloadFile(serverFile, localFile);
            Assert.True(success);
        }

        public static byte[] ReadFully(Stream input)
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
