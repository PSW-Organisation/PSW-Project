using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class LoginController
	{
		private LoginService loginService;

		public LoginController()
		{
			loginService = new LoginService();
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
