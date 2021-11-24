using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Utility
{
    public class SftpConfig
    {
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public SftpConfig(string host, string userName, string password)
        {
            Host = host;
            UserName = userName;
            Password = password;
        }
    }
}
