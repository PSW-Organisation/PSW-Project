using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface ILoginService
    {
        public bool AttemptLogin(string usernameAttempt, string passwordAttempt);
        public void SetLoggedInAccount(Account acc);
    }
}
