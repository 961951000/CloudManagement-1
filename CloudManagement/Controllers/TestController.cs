using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace CloudManagement.Controllers
{
    //[AllowAnonymous]
    /// <summary>
    /// 测试控制器
    /// </summary>
    public class TestController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var result = "呵呵哒...";

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(new { result }));
        }
    }
}
