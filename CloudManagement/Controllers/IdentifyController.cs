using System.Web.Http;

namespace CloudManagement.Controllers
{
    public class IdentifyController : ApiController
    {
        [Route("api/Identify/Users/{UserId}/Tokens")]
        public string Tokens(int userId)
        {
            return "Binding token for user's service, like wps, adobe, office365, etc.";
        }

        [Route("api/Identify/Users/{UserId}/Bindings")]
        public string Bindings(int userId)
        {
            return "Binding token for user's service, like wechat, alipay, etc.";
        }
    }
}