using System.Web.Http;

namespace CloudManagement.Controllers
{
    public class UploadController : ApiController
    {
        public string Image()
        {
            return "Upload image";
        }

        public string File()
        {
            return "Upload File";
        }
    }
}