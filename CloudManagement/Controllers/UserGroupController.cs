using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CloudManagement.DatabaseContext;
using CloudManagement.Models;

namespace CloudManagement.Controllers
{
    /// <summary>
    /// 用户组控制器
    /// </summary>
    public class UserGroupController : ApiController
    {
        private readonly SqlServerContext _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserGroupController() : this(new SqlServerContext()) { }

        internal UserGroupController(SqlServerContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取用户组列表
        /// </summary>
        /// <returns>用户组列表</returns>
        public async Task<HttpResponseMessage> GetUserGroupList()
        {
            var result = await _db.UserGroup.ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由用户组编号获取用户组信息
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <returns>用户组信息</returns>
        public async Task<HttpResponseMessage> GetUserGroupByUserGroupId(int id)
        {
            var result = await _db.UserGroup.SingleAsync(x => x.UserGroupId == id);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由创建用户获取用户组列表
        /// </summary>
        /// <param name="id">创建用户编号</param>
        /// <returns>用户组列表</returns>
        public async Task<HttpResponseMessage> GetUserGroupListByCreateByUser(int id)
        {
            var result = await _db.UserGroup.Where(x => x.CreateByUserId == id).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由角色获取用户组列表
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <returns>用户组列表</returns>
        public async Task<HttpResponseMessage> GetUserGroupListByRole(int id)
        {
            var result = await _db.UserGroupRoleMapping.Where(x => x.RoleId == id).Select(x => x.UserGroup).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由用户组名称获取用户组列表
        /// </summary>
        /// <param name="userGroupName">用户组名称</param>
        /// <returns>用户组列表</returns>
        public async Task<HttpResponseMessage> GetGroupListByUserGroupName(string userGroupName)
        {
            var result = await _db.UserGroup.Where(x => x.UserGroupName == userGroupName).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 添加用户组
        /// </summary>
        /// <param name="id">创建人用户编号</param>
        /// <param name="userGroup">用户组信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddUserGroup(int id, UserGroup userGroup)
        {
            userGroup.CreateByUserId = id;
            userGroup.CreateTime = DateTime.Now;
            _db.UserGroup.Add(userGroup);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 更新用户组信息
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <param name="userGroup">用户组信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Update(int id, UserGroup userGroup)
        {
            userGroup.UserGroupId = id;
            userGroup.UpdateTime = DateTime.Now;
            _db.Entry(userGroup).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var userGroup = await _db.UserGroup.SingleAsync(x => x.UserGroupId == id);
            _db.UserGroup.Remove(userGroup);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }
    }
}
