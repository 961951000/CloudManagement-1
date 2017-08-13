using System.Web.Http;

namespace CloudManagement.Controllers
{
    public class GeneralController : ApiController
    {
        [Route("api/General/User/{UserId}")]
        public new string User(int userId)
        {
            return "Get specified user info";
        }

        [Route("api/General/Users")]
        public string Users(int top, int skip)
        {
            return "Get the numbers of user list from {skip}";
        }

        [Route("api/General/Tenant/{TenantId}")]
        public string Tenant(int tenantId)
        {
            return "Get specified tenant info";
        }

        [Route("api/General/Tenants")]
        public string Tenants(int top, int skip)
        {
            return "Get the numbers of tenant list from {skip}";
        }

        [Route("api/General/Users/{UserId}/Emails/{Email}")]
        public string Emails(int userId, int email)
        {
            return "Activating the user by email with guid provided";
        }

        [Route("api/General/Emails")]
        public string Emails()
        {
            return "Generate a active email to user";
        }

        [Route("api/General/Users/{UserId}/Info")]
        public string Info(int userId)
        {
            return "Update user info, like profile";
        }

        [Route("api/General/Users/{UserId}/Password")]
        public string Password(int userId)
        {
            return "Update user password";
        }
    }
}