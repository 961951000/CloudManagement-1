using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CloudManagement.DatabaseContext;
using CloudManagement.Models;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Data.Entity;

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

        public async Task<HttpResponseMessage> GetUserList()
        {
            var result = _db.User.ToList();
            foreach (var item in result)
            {
                item.UserDetail = _db.UserDetail.Single(x => x.UserDetailId == item.UserDetailId);
            }
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(new User { UserDetail = new UserDetail() })));
        }

        public async Task<HttpResponseMessage> GetUser(int id)
        {
            var result = _db.User.Single(x => x.UserId == id);
            result.UserDetail = _db.UserDetail.Single(x => x.UserDetailId == result.UserDetailId);
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result)));
        }

        public async Task<HttpResponseMessage> Register(UserDetail userDetail)
        {
            return await Add(new User { UserDetail = userDetail });
        }

        public async Task<HttpResponseMessage> Add(User user)
        {
            _db.User.Add(user);
            var result = _db.SaveChanges();
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, Json(user.UserId)));
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var user = _db.User.Single(x => x.UserId == id);
            _db.User.Remove(user);
            var result = _db.SaveChanges();
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, Json(result)));
        }

        public async Task<HttpResponseMessage> Update(int id, User user)
        {
            user.UserId = id;
            _db.Entry(user).State = EntityState.Modified;
            var result = _db.SaveChanges();
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, Json(result)));
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Login(string username, string password)
        {
            //Basic Y2FpeGlhbmd3ZWlAYmV5b25kc29mdC5jb206Y2FpeGlhbmd3ZWkyMDE3MTAwMQ==
            var token = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            var response = await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, token));
            response.Headers.Add("Authorization", token);
            return response;
        }
    }
}
