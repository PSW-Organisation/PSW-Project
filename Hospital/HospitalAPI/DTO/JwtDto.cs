using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class JwtDto
    {
        public User User { get; set; }
        public object Token { get; set; }
    }
}
