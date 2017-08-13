using System.Web.Http;

namespace CloudManagement.Controllers
{
    public class LoginController : ApiController
    {
        public new string User()
        {
            return "User login by password";
        }

        public string Tenant()
        {
            return "Tenant login by password";
        }
    }
}