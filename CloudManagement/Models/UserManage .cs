using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace CloudManagement.Models
{
    public class UserManage : IIdentity
    {
        public User User { get; }
        public UserManage(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
        public string Name => User.Name;

        public string AuthenticationType => "Basic";

        public bool IsAuthenticated => true;
    }
}