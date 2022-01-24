using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.GlobalErrorHandling.Model
{
    public class CustomMessageException : Exception
    {
        public CustomMessageException(string message) :base(message)
        {

        }
    }
}
