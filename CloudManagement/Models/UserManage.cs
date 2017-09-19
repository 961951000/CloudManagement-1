using System;
using System.Security.Principal;

namespace CloudManagement.Models
{
    public class UserManage : IIdentity
    {
        public User User { get; }
        public UserManage(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
        public string Name => User.UserDetail.UserPrincipalName;

        public string AuthenticationType => "Basic";

        public bool IsAuthenticated => true;
    }
}