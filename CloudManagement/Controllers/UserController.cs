using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CloudManagement.Controllers
{
    public class UserController : ApiController
    {
        public async Task<string> Get()
        {
            return await Task.FromResult("呵呵哒");
        }
    }
}
