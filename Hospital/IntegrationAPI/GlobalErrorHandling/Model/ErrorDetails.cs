using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace IntegrationAPI.Extensions
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
