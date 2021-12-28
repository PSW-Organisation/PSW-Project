using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.JWT
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }
        public RoleRequirement(string role)
        {
            Role = role;
        }
    }
}
