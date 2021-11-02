using System;
using System.Collections.Generic;

namespace ehealthcare.Model
{
    [Serializable]
    public class PersonalizedNotification : Notification
    {
        public List<Account> Accounts { get; set; }
    }
}