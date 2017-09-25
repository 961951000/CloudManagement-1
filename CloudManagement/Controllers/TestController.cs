using System.Web.Http;

namespace CloudManagement.Controllers
{
    //[AllowAnonymous]
    /// <summary>
    /// 测试控制器
    /// </summary>
    public class TestController : ApiController
    {
        public string Get()
        {
            return "呵呵哒...";
        }
    }
}
