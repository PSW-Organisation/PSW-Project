using ehealthcare.Proxies;
using ehealthcare.Service;
using System;
using System.Drawing.Design;

namespace ehealthcare.Model
{
    [Serializable]
    public class Account : Entity
    {
        private IUser lazyUser;
        private User user;
        private string userId;
        private String password;
        private LoginType loginType;
        private bool isBlocked;

        public Account() : base("undefinedKey") 
        {
            lazyUser = new UserProxyImpl();
        }

        [System.Xml.Serialization.XmlIgnore]
        public User User
        {
            get
            {
                if (user == null)
                {
                    user = lazyUser.GetUser(UserId, LoginType);
                }
                return user;
            }
            set
            {
                user = value;
                UserId = value.Id;
            }
        }

        public string UserId { get; set; }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public LoginType LoginType
        {
            get { return loginType; }
            set { loginType = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public String LoginTypeString
        {
            get { return loginType == LoginType.guestPatient ? "Guest nalog" : "Punopravni nalog"; }
        }

        public bool IsBlocked
        {
            get { return isBlocked; }
            set { isBlocked = value; }
        }
    }
}