using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CloudManagement.DatabaseContext;

namespace CloudManagement.Controllers
{
    //[AllowAnonymous]
    public class UserController : ApiController
    {
        private readonly SqlServerContext _db;

        public UserController() : this(new SqlServerContext()) { }

        internal UserController(SqlServerContext db)
        {
            _db = db;
        }

        public async Task<HttpResponseMessage> Get()
        {
            var result = _db.User.ToList();
            foreach (var item in result)
            {
                item.UserDetail = _db.UserDetail.Single(x => x.UserDetailId == item.UserDetailId);
            }
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, result));
        }
    }
}
