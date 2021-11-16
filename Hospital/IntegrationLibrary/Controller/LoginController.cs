using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class LoginController
	{
		private ILoginService loginService;

		public LoginController(ILoginService loginService)
		{
            this.loginService = loginService;
		}

        /**
        * <summary>Method checks login credentials and sets global account for the given credentials. <br/>
        * Returns true if the username and password belond to a registered user in database, and false if otherwise.</summary>
        */
        public bool AttemptLogin(string usernameAttempt, string passwordAttempt)
        {
            return loginService.AttemptLogin(usernameAttempt, passwordAttempt);
        }
    }
}
