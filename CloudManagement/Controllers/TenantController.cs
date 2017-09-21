using CloudManagement.DatabaseContext;
using CloudManagement.Filters.Authentication;
using CloudManagement.Helpers;
using CloudManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CloudManagement.Controllers
{
    /// <summary>
    /// 租户控制器
    /// </summary>
    public class TenantController : ApiController
    {
        private readonly SqlServerContext _db;
        private readonly string _endpoint;

        /// <summary>
        /// 构造函数
        /// </summary>
        public TenantController() : this(new SqlServerContext(), HttpContext.Current.Request.Url.Host) { }

        internal TenantController(SqlServerContext db, string endpoint)
        {
            _db = db;
            _endpoint = endpoint;
        }

        public async Task<HttpResponseMessage> Get()
        {
            var result = _db.Tenant.ToList();
            foreach (var item in result)
            {
                item.TenantDetail = _db.TenantDetail.Single(x => x.TenantDetailId == item.TenantDetailId);
                item.CreateByUser = _db.User.Single(x => x.UserId == item.CreateByUserId);
            }
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(new User { UserDetail = new UserDetail() })));
        }

        public async Task<HttpResponseMessage> Register(TenantDetail tenantDetail)
        {
            return await Add(new Tenant { TenantDetail = tenantDetail });
        }

        public async Task<HttpResponseMessage> Add(Tenant tenant)
        {
            _db.Tenant.Add(tenant);
            var result = _db.SaveChanges();
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, Json(tenant.TenantId)));
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var tenant = _db.Tenant.Single(x => x.TenantId == id);
            _db.Tenant.Remove(tenant);
            var result = _db.SaveChanges();
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, Json(result)));
        }

        public async Task<HttpResponseMessage> Update(int id, Tenant tenant)
        {
            tenant.TenantId = id;
            _db.Entry(tenant).State = EntityState.Modified;
            var result = _db.SaveChanges();
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, Json(result)));
        }

        public async Task<HttpResponseMessage> AddUser(UserDetail userDetail)
        {
            var requestUrl = "User/Register";
            var token = Request.Headers.Authorization.Parameter;

            var response = await requestUrl.ExecutePostServiceCall(token, _endpoint, userDetail).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync();

            var createByUser = _db.User.Single(x => x.Token == token);
            var tenant = _db.Tenant.Single(x => x.CreateByUserId == createByUser.UserId);
            tenant.User = _db.User.Where(x => x.TenantId == tenant.TenantId).ToList();
            var user = new User { UserDetail = userDetail };
            tenant.User.Add(user);
            _db.Entry(tenant).State = EntityState.Modified;
            var result = _db.SaveChanges();
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, Json(result)));
        }

        public async Task<HttpResponseMessage> MoveInUser(int id)
        {
            var token = Request.Headers.Authorization.Parameter;
            var createByUser = _db.User.Single(x => x.Token == token);
            var tenant = _db.Tenant.Single(x => x.CreateByUserId == createByUser.UserId);
            tenant.User = _db.User.Where(x => x.TenantId == tenant.TenantId).ToList();
            var user = _db.User.Single(x => x.UserId == id);
            tenant.User.Add(user);
            _db.Entry(tenant).State = EntityState.Modified;
            var result = _db.SaveChanges();
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, Json(result)));
        }

        public async Task<HttpResponseMessage> MoveOnUser(int id)
        {
            var token = Request.Headers.Authorization.Parameter;
            var createByUser = _db.User.Single(x => x.Token == token);
            var tenant = _db.Tenant.Single(x => x.CreateByUserId == createByUser.UserId);
            tenant.User = _db.User.Where(x => x.TenantId == tenant.TenantId && x.UserId != id).ToList();
            _db.Entry(tenant).State = EntityState.Modified;
            var result = _db.SaveChanges();
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, Json(result)));
        }
    }
}
