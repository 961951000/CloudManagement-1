using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using System.Web.SessionState;
using CloudManagement.Results;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;

namespace CloudManagement.Filters
{
    public abstract class BasicAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        protected abstract Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken);
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            #region Allow anonymous
            HttpActionDescriptor actionDescriptor = context.ActionContext.ActionDescriptor;
            bool isAnonymousAllowed = actionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any() || actionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any();
            if (isAnonymousAllowed)
            {
                return;
            }
            #endregion

            #region Identity authentication
            context.Principal = null;

            // Look for credentials in the request.
            AuthenticationHeaderValue authenticationHeader = context.Request.Headers.Authorization;

            // If there are no credentials, do nothing.
            // If there are credentials but the filter does not recognize the authentication scheme, do nothing.
            if (authenticationHeader != null && authenticationHeader.Scheme == "Basic")
            {
                // If there are credentials that the filter understands, try to validate them.
                // If the credentials are bad, set the error result.
                if (!string.IsNullOrEmpty(authenticationHeader.Parameter))
                {
                    Tuple<string, string> data = ExtractUserNameAndPassword(authenticationHeader.Parameter);

                    // If the credentials are valid, set principal.
                    context.Principal = await AuthenticateAsync(data?.Item1, data?.Item2, cancellationToken);
                }
            }

            if (context.Principal == null)
            {
                context.ErrorResult = new UnauthorizedResult(new[] { new AuthenticationHeaderValue("Basic") }, context.Request);
            }
            #endregion

            #region Verify that Session is out of date
            HttpSessionState session = HttpContext.Current.Session;
            // If the browser session has expired...
            if (context.Principal != null && session["token"] == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Session expired", context.Request);
            }
            #endregion
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
        public bool AllowMultiple => false;

        private Tuple<string, string> ExtractUserNameAndPassword(string authenticationParameter)
        {
            if (!string.IsNullOrEmpty(authenticationParameter))
            {
                var data = Encoding.ASCII.GetString(Convert.FromBase64String(authenticationParameter)).Split(':');
                if (data.Length > 1)
                {
                    return new Tuple<string, string>(data[0], data[1]);
                }
            }
            return null;
        }
    }
}