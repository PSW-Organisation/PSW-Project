using ehealthcare.Proxies;
using ehealthcare.Service;
using HospitalLibrary.Model;
using System;
using System.Drawing.Design;

namespace ehealthcare.Model
{
    [Serializable]
    public class Account : EntityDb
    {
        public User User { get; set; }
       
        public LoginType LoginType { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsBlocked { get; set; }
       
        public bool IsActivated { get; set; }

        public Account() 
        {
           
        }
    }
}