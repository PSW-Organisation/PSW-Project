using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace IntegrationLibrary.Compression
{
    public class OnDemandPDFCompressorService : ICompressionService
    {
        
        public OnDemandPDFCompressorService()
        {
            Init();
        }
        public bool Compress()
        {
            throw new NotImplementedException();
        }

        public bool Init()
        {
            throw new NotImplementedException();
        }
    }
}
