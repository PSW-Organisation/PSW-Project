using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalLibrary.Shared.Model
{
    public class JwtHelper
    {
        public static JwtSecurityToken GetJwtToken(
            string username,
            string signingKey,
            string issuer,
            string audience,
            DateTime expiration,
            Claim[] additionalClaims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: expiration,
                claims: additionalClaims,
                signingCredentials: creds
            );
        }
    }
}
