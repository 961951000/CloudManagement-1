using System.Web.Http;

namespace CloudManagement.Controllers
{
    public class PrivilegeController : ApiController
    {
        [Route("api/Privilege/Users/{UserId}")]
        public string Users(int userId)
        {
            return "Remove individual user by user id";
        }

        [Route("api/Privilege/Users/Active")]
        public string Active()
        {
            return "Active individual user by user id";
        }

        [Route("api/Privilege/Users/Deactive")]
        public string Deactive()
        {
            return "Deactive individual user by user id";
        }
    }
}