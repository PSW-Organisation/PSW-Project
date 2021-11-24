using IntegrationAPI.Utility;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Service
{
    public class SftpService
    {
        private SftpConfig config;
        public SftpService(SftpConfig config)
        {
            this.config = config;
        }

        public bool UploadFile(byte[] file, String serverFile)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(config.Host, config.UserName, config.Password)))
            {
                try
                {
                    client.Connect();

                    using (Stream stream = new MemoryStream(file))
                    {
                        client.UploadFile(stream, serverFile, x => { Console.WriteLine(x); });
                    }
                    return true;
                }
                catch(Exception exception)
                {
                    return false;
                }
                finally
                {
                    client.Disconnect();
                }
            }
        }

        public bool DownloadFile(String serverFile, String localFile)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(config.Host, config.UserName, config.Password)))
            {
                try
                {
                    client.Connect();
                    using (Stream stream = System.IO.File.OpenWrite(localFile))
                    {
                        client.DownloadFile(serverFile, stream, x => Console.WriteLine(x));
                    }
                    return true;
                }
                catch(Exception exception)
                {
                    return false;
                }
                finally
                {
                    client.Disconnect();
                }
            }
        }

    }
}
