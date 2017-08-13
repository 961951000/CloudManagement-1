using System.Web.Http;

namespace CloudManagement.Controllers
{
    public class RegisterController : ApiController
    {
        public new string User()
        {
            return "User register by user info";
        }

        public string Tenant()
        {
            return "Tenant register by tenant info";
        }
    }
}