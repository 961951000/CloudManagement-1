using CloudManagement.DatabaseContext;
using CloudManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using CloudManagement.Helper;

namespace CloudManagement.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    //[AllowAnonymous]
    public class UserController : ApiController
    {
        private readonly SqlServerContext _db;
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserController() : this(new SqlServerContext()) { }

        internal UserController(SqlServerContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns>用户列表</returns>
        public async Task<HttpResponseMessage> GetUserList()
        {
            var result = _db.User;
            foreach (var user in result)
            {
                user.UserDetail = await _db.UserDetail.SingleAsync(x => x.UserDetailId == user.UserDetailId);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由用户编号获取用户信息
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns>用户信息</returns>
        public async Task<HttpResponseMessage> GetUserByUserId(int id)
        {
            var result = await _db.User.SingleAsync(x => x.UserGroupId == id);
            result.UserDetail = await _db.UserDetail.SingleAsync(x => x.UserDetailId == result.UserDetailId);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由用户名获取用户信息
        /// </summary>
        /// <param name="userPrincipalName">用户名（英文名@域名）</param>
        /// <returns>用户信息</returns>
        public async Task<HttpResponseMessage> GetUserByUserPrincipalName(string userPrincipalName)
        {
            var userDetail = await _db.UserDetail.SingleAsync(x => x.UserPrincipalName == userPrincipalName);
            var result = await _db.User.SingleAsync(x => x.UserDetailId == userDetail.UserDetailId);
            result.UserDetail = userDetail;

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }
        /// <summary>
        /// 由租户获取用户列表
        /// </summary>
        /// <param name="id">租户编号</param>
        /// <returns>租户用户列表</returns>
        public async Task<HttpResponseMessage> GetUserListByTenant(int id)
        {
            var result = _db.User.Where(x => x.TenantId == id);
            foreach (var user in result)
            {
                user.UserDetail = await _db.UserDetail.SingleAsync(x => x.UserDetailId == user.UserDetailId);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户添加用户
        /// </summary>
        /// <param name="id">租户编号</param>
        /// <param name="userDetail">用户详细信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddUser(int id, UserDetail userDetail)
        {
            _db.User.Add(new User
            {
                Token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userDetail.UserPrincipalName}:{userDetail.Password}")),
                CreateTime = DateTime.Now,
                UserDetail = userDetail,
                Tenant = await _db.Tenant.SingleAsync(x => x.TenantId == id)
            });
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户移入用户
        /// </summary>
        /// <param name="id">租户编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveInUserByTenant(int id, int userId)
        {
            var user = await _db.User.SingleAsync(x => x.UserId == userId);
            user.TenantId = id;
            user.UpdateTime = DateTime.Now;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户移出用户
        /// </summary>
        /// <param name="id">租户编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveOutUserByTenant(int id, int userId)
        {
            var user = await _db.User.SingleAsync(x => x.TenantId == id && x.UserId == userId);
            user.TenantId = null;
            user.UpdateTime = DateTime.Now;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户导入用户
        /// </summary>
        /// <param name="id">租户编号</param>
        /// <param name="userIdList">用户编号列表</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ImportUserByTenant(int id, IList<int> userIdList)
        {
            var userList = await _db.User.Where(x => userIdList.Contains((int)x.UserId)).ToListAsync();
            userList.ForEach(x =>
            {
                x.TenantId = id;
                x.UpdateTime = DateTime.Now;
            });
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户导出用户
        /// </summary>
        /// <param name="id">租户编号</param>
        /// <param name="userIdList">用户编号列表</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ExportUserByTenant(int id, IQueryable<int> userIdList)
        {
            var userList = await _db.User.Where(x => x.TenantId == id && userIdList.Contains((int)x.UserId)).ToListAsync();
            userList.ForEach(x =>
            {
                x.TenantId = null;
                x.UpdateTime = DateTime.Now;
            });
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由分组获取用户列表
        /// </summary>
        /// <param name="userGroup">用户分组</param>
        /// <returns>分组用户列表</returns>
        public async Task<HttpResponseMessage> GetUserListByUserGroup(UserGroup userGroup)
        {
            var result = _db.User.Where(x => x.UserGroupId == userGroup.UserGroupId);
            foreach (var user in result)
            {
                user.UserDetail = await _db.UserDetail.SingleAsync(x => x.UserDetailId == user.UserDetailId);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由分组移入用户
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveInUserByUserGroup(int id, int userId)
        {
            var user = await _db.User.SingleAsync(x => x.UserId == userId);
            user.UserGroupId = id;
            user.UpdateTime = DateTime.Now;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由分组移出用户
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveOutUserByUserGroup(int id, int userId)
        {
            var user = await _db.User.SingleAsync(x => x.UserGroupId == id && x.UserId == userId);
            user.UserGroupId = null;
            user.UpdateTime = DateTime.Now;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由分组导入用户
        /// </summary>
        /// <param name="id">用户分组编号</param>
        /// <param name="userIdList">用户编号列表</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ImportUserByUserGroup(int id, IQueryable<int> userIdList)
        {
            var userList = await _db.User.Where(x => userIdList.Contains((int)x.UserId)).ToListAsync();
            userList.ForEach(x =>
            {
                x.UserGroupId = id;
                x.UpdateTime = DateTime.Now;
            });
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由分组导出用户
        /// </summary>
        /// <param name="id">用户分组编号</param>
        /// <param name="userIdList">用户编号列表</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ExportUserByUserGroup(int id, IQueryable<int> userIdList)
        {
            var userList = await _db.User.Where(x => x.UserGroupId == id && userIdList.Contains((int)x.UserId)).ToListAsync();
            userList.ForEach(x =>
            {
                x.UserGroupId = null;
                x.UpdateTime = DateTime.Now;
            });
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userDetail">用户详细信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddUser(UserDetail userDetail)
        {
            //Basic Y2FpeGlhbmd3ZWlAYmV5b25kc29mdC5jb206Y2FpeGlhbmd3ZWkyMDE3MTAwMQ==
            var user = new User
            {
                Token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userDetail.UserPrincipalName}:{userDetail.Password}")),
                CreateTime = DateTime.Now,
                UserDetail = userDetail
            };
            _db.User.Add(user);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="user">用户信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Update(int id, User user)
        {
            user.UserId = id;
            user.Token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user.UserDetail.UserPrincipalName}:{user.UserDetail.Password}"));
            user.UpdateTime = DateTime.Now;
            _db.Entry(user).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var user = await _db.User.SingleAsync(x => x.UserId == id);
            _db.User.Remove(user);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 用户名密码登陆登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>用户编号</returns>
        public async Task<HttpResponseMessage> Login(string username, string password)
        {
            var result = await _db.User.Join(
                _db.UserDetail.Where(x => x.UserPrincipalName == username && x.Password == password),
                x => x.UserDetailId,
                y => y.UserDetailId,
                (x, y) => x).SingleAsync();
            var response = Request.CreateResponse(HttpStatusCode.OK, Json(result.UserId));
            response.Headers.Add(HttpExtensionMethods.AuthenticationScheme, HttpExtensionMethods.AuthenticationType + result.Token);

            return response;
        }

        /// <summary>
        /// 令牌登录
        /// </summary>
        /// <param name="token">令牌</param>
        /// <returns>用户编号</returns>
        public async Task<HttpResponseMessage> LoginByToken(string token)
        {
            if (token.StartsWith(HttpExtensionMethods.AuthenticationType))
            {
                token = token.Substring(HttpExtensionMethods.AuthenticationType.Length);
            }
            var result = await _db.User.SingleAsync(x => x.Token == token);
            var response = Request.CreateResponse(HttpStatusCode.OK, Json(result.UserId));
            response.Headers.Add(HttpExtensionMethods.AuthenticationScheme, HttpExtensionMethods.AuthenticationType + result.Token);

            return response;
        }
    }
}
