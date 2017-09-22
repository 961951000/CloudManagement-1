using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CloudManagement.Models;
using System.Data.Entity;
using CloudManagement.DatabaseContext;
using System.Collections.Generic;
using System;
using System.Text;

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
        /// 由租户获取用户列表
        /// </summary>
        /// <param name="tenant">租户</param>
        /// <returns>租户用户列表</returns>
        public async Task<HttpResponseMessage> GetUserListByTenant(Tenant tenant)
        {
            var result = _db.User.Where(x => x.TenantId == tenant.TenantId);
            foreach (var user in result)
            {
                user.UserDetail = await _db.UserDetail.SingleAsync(x => x.UserDetailId == user.UserDetailId);
            }

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
        /// 由用户编号获取用户信息
        /// </summary>
        /// <param name="user">用户编号</param>
        /// <returns>用户信息</returns>
        public async Task<HttpResponseMessage> GetUserById(User user)
        {
            var result = await _db.User.SingleAsync(x => x.UserGroupId == user.UserId);
            result.UserDetail = await _db.UserDetail.SingleAsync(x => x.UserDetailId == user.UserDetailId);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由用户名获取用户信息
        /// </summary>
        /// <param name="userDetail">用户名</param>
        /// <returns>用户信息</returns>
        public async Task<HttpResponseMessage> GetUserById(UserDetail userDetail)
        {
            userDetail = await _db.UserDetail.SingleAsync(x => x.UserPrincipalName == userDetail.UserPrincipalName);
            var result = await _db.User.SingleAsync(x => x.UserDetailId == userDetail.UserDetailId);
            result.UserDetail = userDetail;

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
            _db.User.Add(new User
            {
                Token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userDetail.UserPrincipalName}:{userDetail.Password}")),
                UserDetail = userDetail
            });
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user">
        /// 1.用户信息
        /// 2.用户编号是必需的
        /// </param>
        /// <param name="userDetail">用户详细信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Update(User user, UserDetail userDetail)
        {
            user = _db.User.Single(x => x.UserId == user.UserId);
            user.Token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userDetail.UserPrincipalName}:{userDetail.Password}"));
            user.UserDetail = userDetail;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由用户编号添加用户
        /// </summary>
        /// <param name="userDetail">用户详细信息</param>
        /// <param name="tenant">租户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddUser(UserDetail userDetail, Tenant tenant)
        {
            _db.User.Add(new User
            {
                Token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userDetail.UserPrincipalName}:{userDetail.Password}")),
                UserDetail = userDetail,
                Tenant = await _db.Tenant.SingleAsync(x => x.TenantId == tenant.TenantId)
            });
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户移入用户
        /// </summary>
        /// <param name="user">用户编号</param>
        /// <param name="tenant">租户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveInUserByTenant(User user, Tenant tenant)
        {
            tenant = await _db.Tenant.SingleAsync(x => x.TenantId == tenant.TenantId);
            tenant.User = await _db.User.Where(x => x.TenantId == tenant.TenantId).ToListAsync();
            user = await _db.User.SingleAsync(x => x.UserId == user.UserId);
            tenant.User.Add(user);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户移出用户
        /// </summary>
        /// <param name="user">用户编号</param>
        /// <param name="tenant">租户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveOutUserByTenant(User user, Tenant tenant)
        {
            tenant = await _db.Tenant.SingleAsync(x => x.TenantId == tenant.TenantId);
            tenant.User = await _db.User.Where(x => x.TenantId == tenant.TenantId && x.UserId != user.UserId).ToListAsync();
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户导入用户
        /// </summary>
        /// <param name="userList">用户编号列表</param>
        /// <param name="tenant">租户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ImportUserByTenant(IQueryable<User> userList, Tenant tenant)
        {
            tenant = await _db.Tenant.SingleAsync(x => x.TenantId == tenant.TenantId);
            tenant.User = await _db.User.Where(x => x.TenantId == tenant.TenantId).ToListAsync();
            foreach (var user in userList)
            {
                tenant.User.Add(await _db.User.SingleAsync(x => x.UserId == user.UserId));
            }
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户导出用户
        /// </summary>
        /// <param name="user">用户编号</param>
        /// <param name="tenant">租户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ExportUserByTenant(User user, Tenant tenant)
        {
            tenant = await _db.Tenant.SingleAsync(x => x.TenantId == tenant.TenantId);
            tenant.User = await _db.User.Where(x => x.TenantId == tenant.TenantId && !new int?[] { 1, 2, 3, 4, 5, 6 }.Contains(x.UserDetailId)).ToListAsync();
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由分组移入用户
        /// </summary>
        /// <param name="user">用户编号</param>
        /// <param name="userGroup">用户组编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveInUserByUserGroup(User user, UserGroup userGroup)
        {
            userGroup = await _db.UserGroup.SingleAsync(x => x.UserGroupId == userGroup.UserGroupId);
            userGroup.User = await _db.User.Where(x => x.UserGroupId == userGroup.UserGroupId).ToListAsync();
            user = await _db.User.SingleAsync(x => x.UserId == user.UserId);
            userGroup.User.Add(user);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由分组移出用户
        /// </summary>
        /// <param name="user">用户编号</param>
        /// <param name="userGroup">租户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveOutUserByUserGroup(User user, UserGroup userGroup)
        {
            userGroup = await _db.UserGroup.SingleAsync(x => x.UserGroupId == userGroup.UserGroupId);
            userGroup.User = await _db.User.Where(x => x.UserGroupId == userGroup.UserGroupId && x.UserId != user.UserId).ToListAsync();
            user = await _db.User.SingleAsync(x => x.UserId == user.UserId);
            userGroup.User.Add(user);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户导入用户
        /// </summary>
        /// <param name="userList">用户编号列表</param>
        /// <param name="userGroup">租户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ImportUserByUserGroup(IQueryable<User> userList, UserGroup userGroup)
        {
            userGroup = await _db.UserGroup.SingleAsync(x => x.UserGroupId == userGroup.UserGroupId);
            userGroup.User = await _db.User.Where(x => x.UserGroupId == userGroup.UserGroupId).ToListAsync();
            foreach (var user in userList)
            {
                userGroup.User.Add(await _db.User.SingleAsync(x => x.UserId == user.UserId));
            }
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户导出用户
        /// </summary>
        /// <param name="user">用户编号</param>
        /// <param name="userGroup">租户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ExportUserByUserGroup(User user, UserGroup userGroup)
        {
            userGroup = await _db.UserGroup.SingleAsync(x => x.UserGroupId == userGroup.UserGroupId);
            userGroup.User = await _db.User.Where(x => x.UserGroupId == userGroup.UserGroupId && !new int?[] { 1, 2, 3, 4, 5, 6 }.Contains(x.UserDetailId)).ToListAsync();
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user">用户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Delete(User user)
        {
            user = _db.User.Single(x => x.UserId == user.UserId);
            _db.User.Remove(user);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userDetail">
        /// 1.用户详细信息。
        /// 2.用户名和密码是必需的。
        /// </param>
        /// <returns>用户编号</returns>
        public async Task<HttpResponseMessage> Login(UserDetail userDetail)
        {
            var authenticationScheme = "Authorization";
            var authenticationType = "Basic ";
            var result = await _db.User.Join(
                _db.UserDetail.Where(x => x.UserPrincipalName == userDetail.UserPrincipalName && x.Password == userDetail.Password),
                x => x.UserDetailId,
                y => y.UserDetailId,
                (x, y) => x).SingleAsync();
            var response = Request.CreateResponse(HttpStatusCode.OK, result.UserId);
            response.Headers.Add(authenticationScheme, authenticationType + result.Token);

            return response;
        }

        /// <summary>
        /// 由令牌用户登录
        /// </summary>
        /// <param name="user">
        /// 1.用户信息。
        /// 2.令牌是必需的。
        /// </param>
        /// <returns>用户编号</returns>
        public async Task<HttpResponseMessage> LoginByToken(User user)
        {
            var authenticationScheme = "Authorization";
            var authenticationType = "Basic ";
            if (user.Token.StartsWith(authenticationType))
            {
                user.Token = user.Token.Substring(authenticationType.Length);
            }
            var result = await _db.User.SingleAsync(x => x.Token == user.Token);
            var response = Request.CreateResponse(HttpStatusCode.OK, result.UserId);
            response.Headers.Add(authenticationScheme, authenticationType + result.Token);

            return response;
        }
    }
}
