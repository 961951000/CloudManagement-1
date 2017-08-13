using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using CloudManagement.Models;

namespace CloudManagement.Filters
{
    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                // Implement logic suitable for your case           
                return await Task.Run(() => new ClaimsPrincipal(new UserManage(new User { Name = userName, PasswordKey = password })), cancellationToken);
                // req.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetByte));
            }
            return null;
        }
    }
}