using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CloudManagement.Controllers
{
    //[AllowAnonymous]
    public class TestController : ApiController
    {
        public string Get()
        {
            return "呵呵哒...";
        }
    }
}
