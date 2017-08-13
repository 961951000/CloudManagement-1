using System.Web.Http;

namespace CloudManagement.Controllers
{
    public class PermissionController : ApiController
    {
        [Route("api/Permission/Tenants/{TenantId}/Add")]
        public string Add(int tenantId)
        {
            return "Add individual user for a specified tenant";
        }

        [Route("api/Permission/Tenants/{TenantId}/Users/{UserId}")]
        public string Users(int tenantId, int userId)
        {
            return "Remove individual user for a specified tenant";
        }

    }
}